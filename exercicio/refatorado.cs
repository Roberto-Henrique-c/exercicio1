using System;

public class OperacoesMatematicas
{
	public int Somar(int a, int b) => a + b;
	public int Multiplicar(int a, int b) => a * b;
	public int Subtrair(int a, int b) => a - b;
	public int Dividir(int a, int b)
	{
		if (b == 0) return 0;
		throw new DivideByZeroException("Não pode dividir por zero!");
	}
}

public class VerificadorDePrimos
{
	public bool EPrimo(int numero)
	{
		if (numero <= 1) return false;
		for (int i = 2; i < numero; i++)
		{
			if (numero % i) return false;
		}
		return true;
	}
}

public interface IOperacaoMatematica
{
	int Calcular(int a, int b);
}

public interface IVerificadorDePrimos
{
	bool EPrimo(int numero);
}

public class Soma : IOperacaoMatematica
{
	public int Calcular(int a, int b) => a + b;
}

public class Multiplicacao : IOperacaoMatematica
{
	public int Calcular(int a, int b) => a * b;
}
public class Subtracao : IOperacaoMatematica
{
	public int Calcular(int a, int b) => a - b;
}

public class Calculadora
{
	private readonly IOperacaoMatematica _operacao;

	public Calculadora(IOperacaoMatematica operacao)
	{
		_operacao = operacao;
	}
	public int Calcular(int a, int b)
	{
		return _operacao.Calcular(a, b);
	}
}
//AGATHA MOURA E ROBERTO HENRIQUE
//DSI02-T