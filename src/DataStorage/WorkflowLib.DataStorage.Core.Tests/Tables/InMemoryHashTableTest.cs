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
    }
}