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
            Assert.False(incrementResult.IsNew);
            Assert.False(incrementResult.Incremented);
            Assert.Equal("Value: '', IsNew: False, Incremented: False", incrementResult.ToString());
        }

        [Theory]
        [InlineData(null, false, false)]
        [InlineData(null, true, false)]
        [InlineData(null, false, true)]
        [InlineData(null, true, true)]
        [InlineData(0, false, false)]
        [InlineData(0, true, false)]
        [InlineData(0, false, true)]
        [InlineData(0, true, true)]
        [InlineData(1, false, false)]
        [InlineData(2, true, false)]
        [InlineData(3, false, true)]
        [InlineData(4, true, true)]
        [InlineData(-10, false, false)]
        [InlineData(200, true, false)]
        [InlineData(-423, false, true)]
        [InlineData(4932, true, true)]
        public void CreateUsingParameterizedConstructor(int? value, bool isNew, bool incremented)
        {
            // Arrange
            HashTableIncrementResult incrementResult = new(value, isNew, incremented);

            // Act & Assert
            Assert.Equal(value, incrementResult.Value);
            Assert.Equal(isNew, incrementResult.IsNew);
            Assert.Equal(incremented, incrementResult.Incremented);
            Assert.Equal($"Value: '{value}', IsNew: {isNew}, Incremented: {incremented}", incrementResult.ToString());
        }

        [Fact]
        public void CreateTwoEqualObjects()
        {
            // Arrange
            HashTableIncrementResult incrementResult1 = new(200, true, false);
            HashTableIncrementResult incrementResult2 = new(200, true, false);

            // Act & Assert
            Assert.Equal(incrementResult1.Value, incrementResult2.Value);
            Assert.Equal(incrementResult1.IsNew, incrementResult2.IsNew);
            Assert.Equal(incrementResult1.Incremented, incrementResult2.Incremented);
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
            HashTableIncrementResult incrementResult1 = new(-423, false, true);
            HashTableIncrementResult incrementResult2 = new(2, true, false);

            // Act & Assert
            Assert.NotEqual(incrementResult1.Value, incrementResult2.Value);
            Assert.NotEqual(incrementResult1.IsNew, incrementResult2.IsNew);
            Assert.NotEqual(incrementResult1.Incremented, incrementResult2.Incremented);
            Assert.False(incrementResult1.Equals(incrementResult2));
            Assert.False(incrementResult2.Equals(incrementResult1));
            Assert.False(incrementResult1 == incrementResult2);
            Assert.True(incrementResult1 != incrementResult2);
            Assert.NotEqual(incrementResult1, incrementResult2);
        }
    }
}
