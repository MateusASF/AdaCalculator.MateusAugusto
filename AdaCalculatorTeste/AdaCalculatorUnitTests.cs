using AdaCalculator;
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

        #region Teste Com Mock e Com valor

        [Theory]
        [InlineData("multiply", 100, 2, 200)]
        [InlineData("multiply", 100, -2, -200)]
        [InlineData("multiply", 100, -3, -300)]
        [InlineData("multiply", 100, 0, 0)]
        public void CalcultatorMachine_MultiplicacaoDeNumeros_CalculoEChamadaCorreta(string op, double num1, double num2, double resultado)
        {
            CalculatorMachine cf = new CalculatorMachine();
            var lala = cf.Calculate(op, num1, num2);

            _sut.Calculate(op, num1, num2);

            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((lala));

            Assert.Equal(op, lala.operation);
            Assert.Equal(resultado, lala.result);

            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }


        [Theory]
        [InlineData("sum", 100, 2, 102)]
        [InlineData("sum", 100, -2, 98)]
        [InlineData("sum", 100, 0, 100)]
        public void CalcultatorMachine_SomaDeNumeros_CalculoEChamadaCorreta(string op, double num1, double num2, double resultado)
        {
            CalculatorMachine cf = new CalculatorMachine();
            var lala = cf.Calculate(op, num1, num2);

            _sut.Calculate(op, num1, num2);

            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((lala));

            Assert.Equal(op, lala.operation);
            Assert.Equal(resultado, lala.result);

            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }

        [Theory]
        [InlineData("subtract", 100, 40, 60)]
        [InlineData("subtract", 100, -2, 102)]
        [InlineData("subtract", 100, 0, 100)]
        public void CalcultatorMachine_SubtracaoDeNumeros_CalculoEChamadaCorreta(string op, double num1, double num2, double resultado)
        {
            CalculatorMachine cf = new CalculatorMachine();
            var lala = cf.Calculate(op, num1, num2);

            _sut.Calculate(op, num1, num2);

            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((lala));

            Assert.Equal(op, lala.operation);
            Assert.Equal(resultado, lala.result);

            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }

        [Theory]
        [InlineData("divide", 100, 2, 50)]
        [InlineData("divide", 100, -2, -50)]
        [InlineData("divide", 100, 0, double.PositiveInfinity)]
        public void CalcultatorMachine_DivisaoDeNumeros_CalculoEChamadaCorreta(string op, double num1, double num2, double resultado)
        {
            CalculatorMachine cf = new CalculatorMachine();
            var lala = cf.Calculate(op, num1, num2);

            _sut.Calculate(op, num1, num2);

            _mock.Setup(x => x.Calculate(op, num1, num2)).Returns((lala));

            Assert.Equal(op, lala.operation);
            Assert.Equal(resultado, lala.result);

            _mock.Verify(x => x.Calculate(op, num1, num2), Times.Once);
        }
        #endregion

        #region Testes com Mock
        [Fact]
        public void CalculatorMachine_SomaDeNumeros_ChamadaCorretaComMock()
        {
            _mock.Setup(x => x.Calculate("sum", 2, 2)).Returns(("sum", 4));
            _sut.Calculate("sum", 2, 2);
            _mock.Verify(x => x.Calculate("sum", 2, 2), Times.Once);
        }


        [Fact]
        public void CalculatorMachine_SubtracaoDeNumeros_ChamadaCorretaComMock()
        {
            _mock.Setup(x => x.Calculate("subtract", 2, 2)).Returns(("subtract", 0));
            _sut.Calculate("subtract", 2, 2);
            _mock.Verify(x => x.Calculate("subtract", 2, 2), Times.Once);
        }


        [Fact]
        public void CalculatorMachine_MultiplicacaoDeNumeros_ChamadaCorretaComMock()
        {
            _mock.Setup(x => x.Calculate("multiply", 2, 2)).Returns(("multiply", 4));
            _sut.Calculate("multiply", 2, 2);
            _mock.Verify(x => x.Calculate("multiply", 2, 2), Times.Once);
        }


        [Fact]
        public void CalculatorMachine_DivisaoDeNumeros_ChamadaCorretaComMock()
        {
            _mock.Setup(x => x.Calculate("divide", 2, 2)).Returns(("divide", 1));
            _sut.Calculate("divide", 2, 2);
            _mock.Verify(x => x.Calculate("divide", 2, 2), Times.Once);
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