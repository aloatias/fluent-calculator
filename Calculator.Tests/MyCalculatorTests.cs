using Calculator.App;
using Xunit;

namespace Calculator.Tests
{
    public class MyCalculatorTests
    {
        [Fact]
        public void Plus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 30;

            // Act
            var actualResult = calculator
                .Seed(10)
                .Plus(10)
                .Plus(10)
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Minus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 10;

            // Act
            var actualResult = calculator.Seed(30)
                .Minus(10)
                .Minus(10)
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Undo_Minus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 50;

            // Act
            var actualResult = calculator
                .Seed(50)
                .Minus(10) // 40
                .Minus(20) // 20
                .Undo() // 40
                .Undo() // 50
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Undo_Plus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 30;

            // Act
            var actualResult = calculator
                .Seed(expectedResult)
                .Plus(10)
                .Plus(20)
                .Undo()
                .Undo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Undo_PlusAndMinus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 55;

            // Act
            var actualResult = calculator
                .Seed(expectedResult)
                .Plus(10)
                .Minus(10)
                .Plus(20)
                .Minus(15)
                .Undo()
                .Undo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Redo_Minus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 0;

            // Act
            var actualResult = calculator.Seed(60)
                .Minus(10)
                .Minus(50)
                .Undo()
                .Redo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Redo_Plus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 160;

            // Act
            var actualResult = calculator
                .Seed(100)
                .Plus(10)
                .Plus(50)
                .Undo()
                .Redo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Redo_PlusAndMinus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 155;

            // Act
            var actualResult = calculator
                .Seed(100)
                .Plus(10) // 110
                .Minus(5) // 105
                .Plus(50) // 155
                .Minus(20) // 135
                .Undo() // 155
                .Undo() // 105
                .Redo() // 155
                .Result(); // 155

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Undo_SeveralPlusAndMinusAndUndo_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 185;

            // Act
            var actualResult = calculator.Seed(30)
                .Plus(10)
                .Minus(5)
                .Plus(50)
                .Minus(20)
                .Undo()
                .Plus(100)
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Redo_SeveralPlusAndMinusAndUndo_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 115;

            // Act
            var actualResult = calculator.Seed(30)
                .Plus(10) // 40
                .Minus(5) // 35
                .Undo() // 40
                .Minus(20) // 20
                .Redo() // 15
                .Plus(100) // 115
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        // http://www.tddbuddy.com/katas/Fluent%20Calculator.pdf
        [Fact]
        public void TDDBudy_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 11;

            // Act
            var actualResult = calculator
                .Seed(10)
                .Plus(1)
                .Undo()
                .Redo() // -> 15
                .Result(); // -> result = 15

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        // http://www.tddbuddy.com/katas/Fluent%20Calculator.pdf
        [Fact]
        public void TDDBudy_Save_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 11;

            // Act
            var actualResult = calculator
                .Seed(10)
                .Plus(1)
                .Undo()
                .Redo() // -> 11
                .Save() // 11
                .Undo()
                .Redo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        // http://www.tddbuddy.com/katas/Fluent%20Calculator.pdf
        [Fact]
        public void TDDBudy_SaveAndPlus_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 15;

            // Act
            var actualResult = calculator
                .Seed(10)
                .Plus(1)
                .Undo()
                .Redo() // -> 11
                .Save() // 11
                .Undo()
                .Plus(4)
                .Redo()
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void MultipleSeedingsIgnored_ReturnsOkResult()
        {
            // Arrange 
            var calculator = new MyCalculator();
            var expectedResult = 15;

            // Act
            var actualResult = calculator
                .Seed(10)
                .Plus(1)
                .Undo()
                .Redo() // -> 11
                .Save() // 11
                .Plus(4)
                .Result();

            // Assert
            Assert.Equal(expectedResult, actualResult);
        }
    }
}