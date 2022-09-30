using AdaCalculator;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Utilities;
using Moq;
using Shouldly;

namespace AdaCalculatorTeste
{
    public class AdaCalculatorUnitTests
    {
        private readonly CalculatorMachine _sut;
        private readonly Mock<ICalculator> _mock;
        public AdaCalculatorUnitTests()
        {
            _mock = new Mock<ICalculator>();
            _sut = new CalculatorMachine(_mock.Object);
        }

        #region Testes com Mock
        [Theory]
        [InlineData("sum", 100, 2, 102)]
        [InlineData("sum", 100, -2, 98)]
        [InlineData("sum", 100, 0, 100)]
        public void CalculatorMachine_SomaDeNumerosInteiros_ResultadoValidoComMock(string op, double num1, double num2, double resultado)
        {
            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((op, resultado));
            _sut.Calculate(op, num1, num2);
            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }


        [Theory]
        [InlineData("subtract", 100, 40, 60)]
        [InlineData("subtract", 100, -2, 102)]
        [InlineData("subtract", 100, 0, 100)]
        public void CalculatorMachine_SubtracaoDeNumerosInteiros_ResultadoValidoComMock(string op, double num1, double num2, double resultado)
        {
            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((op, resultado));
            _sut.Calculate(op, num1, num2);
            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }


        [Theory]
        [InlineData("multiply", 100, 2, 200)]
        [InlineData("multiply", 100, -2, 200)]
        [InlineData("multiply", 100, -3, -300)]
        [InlineData("multiply", 100, 0, 0)]
        public void CalculatorMachine_MultiplicacaoDeNumerosInteiros_ResultadoValidoComMock(string op, double num1, double num2, double resultado)
        {
            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((op, resultado));
            _sut.Calculate(op, num1, num2);
            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }


        [Theory]
        [InlineData("divide", 100, 2, 50)]
        [InlineData("divide", 100, -2, -50)]
        [InlineData("divide", 100, 0, double.PositiveInfinity)]
        public void CalculatorMachine_DivisaoDeNumeros_ResultadoValidoComMock(string op, double num1, double num2, double resultado)
        {
            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((op, resultado));
            _sut.Calculate(op, num1, num2);
            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }
        #endregion

        #region Testes SEM Mock
        [Theory]
        [InlineData("sum", 100, 2, 102)]
        [InlineData("sum", 100, -2, 98)]
        [InlineData("sum", -2, -2, -4)]
        [InlineData("sum", -4, 2, -2)]
        [InlineData("sum", 100, 0, 100)]
        public void CalculoMachine_SomaDeNumeros_ResultadoValido(string op, double num1, double num2, double resultado)
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate(op, num1, num2);
            result.ShouldBe((op, resultado));
        }


        [Theory]
        [InlineData("subtract", 100, 40, 60)]
        [InlineData("subtract", 100, -2, 102)]
        [InlineData("subtract", -2, -2, 0)]
        [InlineData("subtract", -4, 2, -6)]
        [InlineData("subtract", 100, 0, 100)]
        public void CalculoMachine_SubtracaoDeNumeros_ResultadoValido(string op, double num1, double num2, double resultado)
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate(op, num1, num2);
            result.ShouldBe((op, resultado));
        }


        [Theory]
        [InlineData("multiply", 100, 2, 200)]
        [InlineData("multiply", 100, -2, -200)]
        [InlineData("multiply", -2, -2, 4)]
        [InlineData("multiply", -4, 2, -8)]
        [InlineData("multiply", 100, -3, -300)]
        [InlineData("multiply", 100, 0, 0)]
        public void CalculoMachine_MultiplicacaoDeNumeros_ResultadoValido(string op, double num1, double num2, double resultado)
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate(op, num1, num2);
            result.ShouldBe((op, resultado));
        }

        [Theory]
        [InlineData("divide", 100, 2, 50)]
        [InlineData("divide", 100, -2, -50)]
        [InlineData("divide", -100, -2, 50)]
        [InlineData("divide", -100, 2, -50)]
        [InlineData("divide", 0, 0, double.NaN)]
        [InlineData("divide", 100, 0, double.PositiveInfinity)]
        public void CalculoMachine_DivisaoDeNumeros_ResultadoValido(string op, double num1, double num2, double resultado)
        {
            var sut = new CalculatorMachine();
            var result = sut.Calculate(op, num1, num2);
            result.ShouldBe((op, resultado));
        }
        #endregion
    }
}