using VelocipedeUtils.DataStorage.Core.Indexes;

namespace VelocipedeUtils.DataStorage.Core.Tests.Indexes
{
    public class HashIndexTest
    {
        [Fact]
        public void AddElement_NewKey_AddsElementToTable()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";
            int value = 1;

            // Act
            index.AddElement(key, value);

            // Assert
            Assert.Equal(value, index.SearchElement(key));
        }

        [Fact]
        public void AddElement_ExistingKey_UpdatesElementInTable()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";
            int initialValue = 1;
            int updatedValue = 2;
            index.AddElement(key, initialValue);

            // Act
            index.AddElement(key, updatedValue);

            // Assert
            Assert.Equal(updatedValue, index.SearchElement(key));
        }

        [Fact]
        public void RemoveElement_ExistingKey_RemovesElementFromTable()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";
            int value = 1;
            index.AddElement(key, value);

            // Act
            bool result = index.RemoveElement(key);

            // Assert
            Assert.True(result);
            Assert.Equal(default(int), index.SearchElement(key));
        }

        [Fact]
        public void RemoveElement_NonExistingKey_ReturnsFalse()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";

            // Act
            bool result = index.RemoveElement(key);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void SearchElement_ExistingKey_ReturnsValue()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";
            int value = 1;
            index.AddElement(key, value);

            // Act
            int result = index.SearchElement(key);

            // Assert
            Assert.Equal(value, result);
        }

        [Fact]
        public void SearchElement_NonExistingKey_ReturnsDefault()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";

            // Act
            int result = index.SearchElement(key);

            // Assert
            Assert.Equal(default(int), result); // Compare to default(TValue) for type safety
        }

        [Fact]
        public void AddAndRemoveMultipleElements_WorksCorrectly()
        {
            // Arrange
            var index = new HashIndex<int, string>();

            // Act
            index.AddElement(1, "one");
            index.AddElement(2, "two");
            index.AddElement(3, "three");

            // Assert
            Assert.Equal("one", index.SearchElement(1));
            Assert.Equal("two", index.SearchElement(2));
            Assert.Equal("three", index.SearchElement(3));

            // Act
            index.RemoveElement(2);

            // Assert
            Assert.Equal("one", index.SearchElement(1));
            Assert.Equal(default(string), index.SearchElement(2));
            Assert.Equal("three", index.SearchElement(3));

            index.RemoveElement(1);
            Assert.Equal(default(string), index.SearchElement(1));
            Assert.Equal("three", index.SearchElement(3));

            index.RemoveElement(3);
            Assert.Equal(default(string), index.SearchElement(3));
        }

        [Fact]
        public void AddElement_DifferentTypes_WorksCorrectly()
        {
            var index = new HashIndex<Guid, DateTime>();
            Guid key1 = Guid.NewGuid();
            DateTime value1 = DateTime.Now;

            index.AddElement(key1, value1);

            Assert.Equal(value1, index.SearchElement(key1));
        }

        [Fact]
        public async Task AddElement_ParallelAdds_NoDataLoss()
        {
            // Arrange
            var index = new HashIndex<int, int>();
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
                        index.AddElement(taskId * numElementsPerTask + j, taskId * numElementsPerTask + j);
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
                    Assert.Equal(key, index.SearchElement(key));
                }
            }
        }

        [Fact]
        public async Task RemoveElement_ParallelRemoves_NoExceptions()
        {
            // Arrange
            var index = new HashIndex<int, int>();
            int numTasks = 100;
            int numElementsPerTask = 100;

            // Populate the table first
            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                index.AddElement(i, i);
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
                        index.RemoveElement(taskId * numElementsPerTask + j);
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert
            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                Assert.Equal(default(int), index.SearchElement(i));
            }
        }

        [Fact]
        public async Task AddAndRemoveElement_ParallelAddAndRemove_NoCorruption()
        {
            // Arrange
            var index = new HashIndex<int, int>();
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
                        index.AddElement(key, key);
                        lock (lockObj)
                        {
                            addedKeys.Add(key);
                        }
                        index.RemoveElement(key);

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
            Assert.Equal(default(int), index.SearchElement(key));
            }

            for (int i = 0; i < numTasks * numElementsPerTask; i++)
            {
                Assert.Equal(default(int), index.SearchElement(i));
            }
        }

        [Fact]
        public async Task Add_Remove_Search_Parallel()
        {
            // Arrange
            var index = new HashIndex<int, string>();
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
                            index.AddElement(key, $"Value_{key}");
                        }
                        else if (rnd.Next(0, 3) == 1) // Simulate remove
                        {
                            index.RemoveElement(key);
                        }
                        else // Simulate search
                        {
                            index.SearchElement(key); // Just call it; we don't assert on it directly here
                        }
                    }
                }));
            }

            await Task.WhenAll(tasks);

            // Assert:  Hard to assert definitively due to the randomness.  A "did not crash" is sufficient
            //          Can add more sophisticated checks if needed, but this demonstrates the general approach.
        }

        [Fact]
        public void ContainsElement_ExistingKey_ReturnsTrue()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";
            int value = 1;
            index.AddElement(key, value);

            // Act
            bool result = index.ContainsElement(key);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void ContainsElement_NonExistingKey_ReturnsFalse()
        {
            // Arrange
            var index = new HashIndex<string, int>();
            string key = "one";

            // Act
            bool result = index.ContainsElement(key);

            // Assert
            Assert.False(result);
        }
    }
}