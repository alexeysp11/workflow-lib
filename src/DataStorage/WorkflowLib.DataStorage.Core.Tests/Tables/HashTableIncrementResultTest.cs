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
        }
    }
}
