using Class_Calculator;

namespace TestCalculator
{
    public class UnitTest1
    {
        // TIP: Use one shared instance or create a new one in each test.
        private readonly Calculator _calculator = new Calculator();

        [Fact]
        public void Add_ReturnsCorrectSum()
        {
            // TODO Arrange: choose inputs (e.g., 2 and 3)
            int a = 2;
            int b = 3;

            // TODO Act: call _calculator.Add(a, b)
            var result = _calculator.Add(a, b);

            // TODO Assert: verify expected sum (e.g., 5)
            Assert.Equal(5, result);
        }

        [Fact]
        public void Subtract_ReturnsCorrectDifference()
        {
            // TODO Arrange
            int a = 7;
            int b = 5;

            // TODO Act
            var result = _calculator.Subtract(a, b);

            // TODO Assert
            Assert.Equal(2, result);
        }

        [Fact]
        public void Multiply_ReturnsCorrectProduct()
        {
            // TODO Arrange
            int a = 2;
            int b = 3;

            // TODO Act
             var result = _calculator.Multiply(a, b);

            // TODO Assert
            Assert.Equal(6, result);
        }

        [Fact]
        public void Divide_ReturnsCorrectQuotient()
        {
            // TODO Arrange
            int a = 10;
            int b = 2;

            // TODO Act
            double result = _calculator.Divide(a, b);

            // TODO Assert
            // Use precision argument for floating-point comparisons.
            // Assert.Equal(expected: ..., actual: result, precision: 3);
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            // TODO Arrange
            int a = 5;
             int b = 0;

            // TODO Assert (no Act step needed when using Assert.Throws)
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(a, b));
        }

        // OPTIONAL: Convert simple cases to a Theory with InlineData
        // [Theory]
        // [InlineData(2, 3, 5)]
        // [InlineData(-1, 1, 0)]
        // public void Add_Theory_Works(int a, int b, int expected)
        // {
        //     var result = _calculator.Add(a, b);
        //     Assert.Equal(expected, result);
        // }
    }

}

