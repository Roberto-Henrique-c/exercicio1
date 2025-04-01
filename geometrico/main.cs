using System;
using NUnit.Framework;

public interface IFiguraGeometrica
{
    double CalcularArea();
}

public class Retangulo : IFiguraGeometrica
{
    public double Largura { get; }
    public double Altura { get; }

    public Retangulo(double largura, double altura)
    {
        Largura = largura;
        Altura = altura;
    }

    public double CalcularArea() => Largura * Altura;
}

public class Circulo : IFiguraGeometrica
{
    public double Raio { get; }

    public Circulo(double raio)
    {
        Raio = raio;
    }

    public double CalcularArea() => Math.PI * Raio * Raio;
}

public class Triangulo : IFiguraGeometrica
{
    public double Base { get; }
    public double Altura { get; }

    public Triangulo(double @base, double altura)
    {
        Base = @base;
        Altura = altura;
    }

    public double CalcularArea() => (Base * Altura) / 2;
}

[TestFixture]
public class TestesFigurasGeometricas
{
    [Test]
    public void CalcularArea_Retangulo_RetornaAreaCorreta()
    {
        var retangulo = new Retangulo(5, 10);
        Assert.AreEqual(50, retangulo.CalcularArea());
    }

    [Test]
    public void CalcularArea_Circulo_RetornaAreaCorreta()
    {
        var circulo = new Circulo(3);
        Assert.AreEqual(Math.PI * 9, circulo.CalcularArea(), 0.001);
    }

    [Test]
    public void CalcularArea_Triangulo_RetornaAreaCorreta()
    {
        var triangulo = new Triangulo(4, 6);
        Assert.AreEqual(12, triangulo.CalcularArea());
    }
}
