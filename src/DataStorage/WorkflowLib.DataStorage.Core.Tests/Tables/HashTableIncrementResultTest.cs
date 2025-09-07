using WorkflowLib.DataStorage.Core.Tables;

namespace WorkflowLib.DataStorage.Core.Tests.Tables
{
    public class HashTableIncrementResultTest
    {
        [Fact]
        public void CreateUsingDefaultConstructor()
        {
            // Arrange
            HashTableIncrementResult incrementResult = new();

            // Act & Assert
            Assert.Null(incrementResult.Value);
            Assert.Equal("Value: '', Success: False", incrementResult.ToString());
        }

        [Theory]
        [InlineData(null)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(-10)]
        [InlineData(200)]
        [InlineData(-423)]
        [InlineData(4932)]
        public void CreateUsingParameterizedConstructor(int? value)
        {
            // Arrange
            HashTableIncrementResult incrementResult = new(value);

            // Act & Assert
            Assert.Equal(value, incrementResult.Value);
            Assert.Equal($"Value: '{value}', Success: {value.HasValue}", incrementResult.ToString());
        }

        [Fact]
        public void CreateTwoEqualObjects()
        {
            // Arrange
            HashTableIncrementResult incrementResult1 = new(200);
            HashTableIncrementResult incrementResult2 = new(200);

            // Act & Assert
            Assert.Equal(incrementResult1.Value, incrementResult2.Value);
            Assert.Equal(incrementResult1.Success, incrementResult2.Success);
            Assert.Equal(incrementResult1.GetHashCode(), incrementResult2.GetHashCode());
            Assert.True(incrementResult1.Equals(incrementResult2));
            Assert.True(incrementResult2.Equals(incrementResult1));
            Assert.True(incrementResult1 == incrementResult2);
            Assert.False(incrementResult1 != incrementResult2);
            Assert.Equal(incrementResult1, incrementResult2);
        }

        [Fact]
        public void CreateTwoUnequalObjects()
        {
            // Arrange
            HashTableIncrementResult incrementResult1 = new(-423);
            HashTableIncrementResult incrementResult2 = new(2);

            // Act & Assert
            Assert.NotEqual(incrementResult1.Value, incrementResult2.Value);
            Assert.Equal(incrementResult1.Success, incrementResult2.Success);
            Assert.False(incrementResult1.Equals(incrementResult2));
            Assert.False(incrementResult2.Equals(incrementResult1));
            Assert.False(incrementResult1 == incrementResult2);
            Assert.True(incrementResult1 != incrementResult2);
            Assert.NotEqual(incrementResult1, incrementResult2);
        }
    }
}
