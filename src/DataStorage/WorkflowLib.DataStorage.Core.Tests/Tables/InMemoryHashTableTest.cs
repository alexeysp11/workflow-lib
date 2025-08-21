using Xunit;
using System;
using WorkflowLib.DataStorage.Core.Tables;

namespace WorkflowLib.DataStorage.Core.Tests.Tables
{
    public class InMemoryHashTableTest
    {
        [Fact]
        public void AddElement_NewKey_AddsElementToTable()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";
            int value = 1;

            // Act
            table.AddElement(key, value);

            // Assert
            Assert.Equal(value, table.SearchElement(key));
        }

        [Fact]
        public void AddElement_ExistingKey_UpdatesElementInTable()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";
            int initialValue = 1;
            int updatedValue = 2;
            table.AddElement(key, initialValue);

            // Act
            table.AddElement(key, updatedValue);

            // Assert
            Assert.Equal(updatedValue, table.SearchElement(key));
        }

        [Fact]
        public void RemoveElement_ExistingKey_RemovesElementFromTable()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";
            int value = 1;
            table.AddElement(key, value);

            // Act
            bool result = table.RemoveElement(key);

            // Assert
            Assert.True(result);
            Assert.Equal(default(int), table.SearchElement(key));
        }

        [Fact]
        public void RemoveElement_NonExistingKey_ReturnsFalse()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";

            // Act
            bool result = table.RemoveElement(key);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SearchElement_ExistingKey_ReturnsValue()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";
            int value = 1;
            table.AddElement(key, value);

            // Act
            int result = table.SearchElement(key);

            // Assert
            Assert.Equal(value, result);
        }

        [Fact]
        public void SearchElement_NonExistingKey_ReturnsDefault()
        {
            // Arrange
            var table = new InMemoryHashTable<string, int>();
            string key = "one";

            // Act
            int result = table.SearchElement(key);

            // Assert
            Assert.Equal(default(int), result); // Compare to default(TValue) for type safety
        }

        [Fact]
        public void AddAndRemoveMultipleElements_WorksCorrectly()
        {
            // Arrange
            var table = new InMemoryHashTable<int, string>();

            // Act
            table.AddElement(1, "one");
            table.AddElement(2, "two");
            table.AddElement(3, "three");

            // Assert
            Assert.Equal("one", table.SearchElement(1));
            Assert.Equal("two", table.SearchElement(2));
            Assert.Equal("three", table.SearchElement(3));

            // Act
            table.RemoveElement(2);

            // Assert
            Assert.Equal("one", table.SearchElement(1));
            Assert.Equal(default(string), table.SearchElement(2));
            Assert.Equal("three", table.SearchElement(3));

            table.RemoveElement(1);
            Assert.Equal(default(string), table.SearchElement(1));
            Assert.Equal("three", table.SearchElement(3));

            table.RemoveElement(3);
            Assert.Equal(default(string), table.SearchElement(3));
        }

        [Fact]
        public void AddElement_DifferentTypes_WorksCorrectly()
        {
            var table = new InMemoryHashTable<Guid, DateTime>();
            Guid key1 = Guid.NewGuid();
            DateTime value1 = DateTime.Now;

            table.AddElement(key1, value1);

            Assert.Equal(value1, table.SearchElement(key1));
        }

        [Fact]
        public async Task AddElement_ParallelAdds_NoDataLoss()
        {
            // Arrange
            var table = new InMemoryHashTable<int, int>();
            int numTasks = 100;
            int numElementsPerTask = 100;
            var tasks = new List<Task>();

            // Act
            for (int i = 0; i < numTasks; i++)
            {
                int taskId = i; // Capture the loop variable for the task
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < numElementsPerTask; j++)
                    {
                        table.AddElement(taskId * numElementsPerTask + j, taskId * numElementsPerTask + j);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert
            for (int i = 0; i < numTasks; i++)
            {
                for (int j = 0; j < numElementsPerTask; j++)
                {
                    int key = i * numElementsPerTask + j;
                    Assert.Equal(key, table.SearchElement(key));
                }
            }
        }

        [Fact]
        public async Task RemoveElement_ParallelRemoves_NoExceptions()
        {
            // Arrange
            var table = new InMemoryHashTable<int, int>();
            int numTasks = 100;
            int numElementsPerTask = 100;

            // Populate the table first
            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                table.AddElement(i, i);
            }

            var tasks = new List<Task>();

            // Act
            for (int i = 0; i < numTasks; i++)
            {
                int taskId = i;
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < numElementsPerTask; j++)
                    {
                        table.RemoveElement(taskId * numElementsPerTask + j);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert
            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                Assert.Equal(default(int), table.SearchElement(i));
            }
        }

        [Fact]
        public async Task AddAndRemoveElement_ParallelAddAndRemove_NoCorruption()
        {
            // Arrange
            var table = new InMemoryHashTable<int, int>();
            int numTasks = 50;
            int numElementsPerTask = 50;
            var tasks = new List<Task>();
            var addedKeys = new HashSet<int>();
            var lockObj = new object();

            // Act
            for (int i = 0; i < numTasks; i++)
            {
                int taskId = i;
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < numElementsPerTask; j++)
                    {
                        int key = taskId * numElementsPerTask + j;

                        //Simulate add and remove
                        table.AddElement(key, key);
                        lock (lockObj)
                        {
                            addedKeys.Add(key);
                        }
                        table.RemoveElement(key);

                        lock (lockObj)
                        {
                            addedKeys.Remove(key);
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert:  Table should be empty
            foreach (var key in addedKeys)
            {
            Assert.Equal(default(int), table.SearchElement(key));
            }

            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                Assert.Equal(default(int), table.SearchElement(i));
            }
        }

        [Fact]
        public async Task Add_Remove_Search_Parallel()
        {
            // Arrange
            var table = new InMemoryHashTable<int, string>();
            int numTasks = 50;
            int numElements = 100;
            var tasks = new List<Task>();
            Random rnd = new Random();

            // Act
            for (int i = 0; i < numTasks; i++)
            {
                tasks.Add(Task.Run(() =>
                {
                    for (int j = 0; j < numElements; j++)
                    {
                        int key = rnd.Next(0, numElements * numTasks); // Generate a random key

                        if (rnd.Next(0, 3) == 0) // Simulate add
                        {
                            table.AddElement(key, $"Value_{key}");
                        }
                        else if (rnd.Next(0, 3) == 1) // Simulate remove
                        {
                            table.RemoveElement(key);
                        }
                        else // Simulate search
                        {
                            table.SearchElement(key); // Just call it; we don't assert on it directly here
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert:  Hard to assert definitively due to the randomness.  A "did not crash" is sufficient
            //          Can add more sophisticated checks if needed, but this demonstrates the general approach.
        }
    }
}