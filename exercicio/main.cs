using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class TesteCalculadora
{
    [TestMethod]
    public void Somar_ComDoisNumerosPositivos_DeveRetornarSomaCorreta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Somar(2, 3);
        Assert.AreEqual(5, resultado);
    }
}
    [TestMethod]
    public void Subtrair_ComDoisNumerosPositivos_DeveRetornarSubtra��oCerta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Subtracao(2, 3);
        Assert.AreEqual(5, resultado);
}
    [TestMethod]
    public void Multiplicar_ComDoisNumeros_DeveRetornarMultiplica��oCerta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Multiplicacao(2, 3);
        Assert.AreEqual(5, resultado);

}
    [TestMethod]
    public void Dividir_ComDoisNumeros_DeveRetornarDivis�oCerta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Divisao((10, 2);
        Assert.AreEqual(12, resultado);
}
    [TestMethod]
    public void Eprimo_RetornarCorretamente()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.EPrimo(7);
        Assert.IsTrue(resultado)
}

public class Calculadora
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }
    }
        public int Subtracao(int a, int b)
        {
            return a - b;
        }   

        public int Multiplicacao(int a, int b)
        {
            return a * b;
        }

        public int Divisao(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }

        return a / b;
    }

    public bool EPrimo(int number)
    {
        if (number <= 1)
        {
            return false;
        }

        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        // Testando opera��es matem�ticas
        Console.WriteLine("Soma: " + calculadora.Soma(5, 3));
        Console.WriteLine("Subtra��o: " + calculadora.Subtracao(5, 3));
        Console.WriteLine("Multiplica��o: " + calculadora.Multiplicacao(5, 3));
        Console.WriteLine("Divis�o: " + calculadora.Divisao(10, 2));

        // Testando n�mero primo
        Console.WriteLine("� primo? " + calculadora.EPrimo(7));
    }
}