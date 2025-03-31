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
    public class Calculadora
    {
        public int Somar(int a, int b)
        {
            return a + b;
        }
    }
    public int Subtract(int a, int b)
    {
        return a - b;
    }

    public int Multiply(int a, int b)
    {
        return a * b;
    }

    public int Divide(int a, int b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException("Cannot divide by zero");
        }

        return a / b;
    }

    public bool IsPrime(int number)
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
        Console.WriteLine("Soma: " + calculator.Add(5, 3));
        Console.WriteLine("Subtração: " + calculator.Subtract(5, 3));
        Console.WriteLine("Multiplicação: " + calculator.Multiply(5, 3));
        Console.WriteLine("Divisão: " + calculator.Divide(10, 2));

        // Testando número primo
        Console.WriteLine("É primo? " + calculator.IsPrime(7));
    }
}