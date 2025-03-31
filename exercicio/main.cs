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
    public void Subtrair_ComDoisNumerosPositivos_DeveRetornarSubtraçãoCerta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Subtracao(2, 3);
        Assert.AreEqual(5, resultado);
}
    [TestMethod]
    public void Multiplicar_ComDoisNumeros_DeveRetornarMultiplicaçãoCerta()
    {
        var calculadora = new Calculadora();

        int resultado = calculadora.Multiplicacao(2, 3);
        Assert.AreEqual(5, resultado);

}
    [TestMethod]
    public void Dividir_ComDoisNumeros_DeveRetornarDivisãoCerta()
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

        // Testando operações matemáticas
        Console.WriteLine("Soma: " + calculadora.Soma(5, 3));
        Console.WriteLine("Subtração: " + calculadora.Subtracao(5, 3));
        Console.WriteLine("Multiplicação: " + calculadora.Multiplicacao(5, 3));
        Console.WriteLine("Divisão: " + calculadora.Divisao(10, 2));

        // Testando número primo
        Console.WriteLine("É primo? " + calculadora.EPrimo(7));
    }
}