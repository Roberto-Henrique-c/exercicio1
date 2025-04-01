using System;
using System.Net;
using System.Net.Mail;

public interface IValidadorEmail
{
	bool FormatoEmailValido(string email);
	bool DominioAtivo(string email);
	bool ServidorEmailRespondendo(string email);
}

public class ValidadorEmail : IValidadorEmail
{
	private readonly IServicoDns _servicoDns;
	private readonly IServicoSmtp _servicoSmtp;

	public ValidadorEmail(IServicoDns servicoDns, IServicoSmtp servicoSmtp)
	{
		_servicoDns = servicoDns;
		_servicoSmtp = servicoSmtp;
	}

	public bool FormatoEmailValido(string email)
	{
		try
		{
			var enderecoEmail = new MailAddress(email);
			return true;
		}
		catch (FormatException)
		{
			return false;
		}
	}

	public bool DominioAtivo(string email)
	{
		string dominio = email.Split('@')[1];
		return _servicoDns.DominioAtivo(dominio);
	}

	public bool ServidorEmailRespondendo(string email)
	{
		string dominio = email.Split('@')[1];
		return _servicoSmtp.ServidorEmailRespondendo(dominio);
	}
}

public interface IServicoDns
{
	bool DominioAtivo(string dominio);
}

public class ServicoDns : IServicoDns
{
	public bool DominioAtivo(string dominio)
	{
		try
		{
			Dns.GetHostEntry(dominio);
			return true;
		}
		catch (Exception)
		{
			return false;
		}
	}
}

public interface IServicoSmtp
{
	bool ServidorEmailRespondendo(string dominio);
}

public class ServicoSmtp : IServicoSmtp
{
	public bool ServidorEmailRespondendo(string dominio)
	{
		try
		{
			using (var clienteSmtp = new SmtpClient(dominio))
			{
				clienteSmtp.Port = 25;
				clienteSmtp.Timeout = 5000;
				clienteSmtp.Send(new MailMessage());
				return true;
			}
		}
		catch (Exception)
		{
			return false;
		}
	}
}

// ------------------ Testes ------------------
using NUnit.Framework;
using Moq;

[TestFixture]
public class TestesValidadorEmail
{
	private ValidadorEmail _validador;
	private Mock<IServicoDns> _mockDns;
	private Mock<IServicoSmtp> _mockSmtp;

	[SetUp]
	public void Configurar()
	{
		_mockDns = new Mock<IServicoDns>();
		_mockSmtp = new Mock<IServicoSmtp>();
		_validador = new ValidadorEmail(_mockDns.Object, _mockSmtp.Object);
	}

	[Test]
	public void FormatoEmailValido_EmailValido_RetornaTrue()
	{
		Assert.IsTrue(_validador.FormatoEmailValido("exemplo@exemplo.com"));
	}

	[Test]
	public void FormatoEmailValido_EmailInvalido_RetornaFalse()
	{
		Assert.IsFalse(_validador.FormatoEmailValido("emailinvalido"));
	}

	[Test]
	public void DominioAtivo_DominioAtivo_RetornaTrue()
	{
		_mockDns.Setup(d => d.DominioAtivo(It.IsAny<string>())).Returns(true);
		Assert.IsTrue(_validador.DominioAtivo("exemplo@exemplo.com"));
	}

	[Test]
	public void DominioAtivo_DominioInexistente_RetornaFalse()
	{
		_mockDns.Setup(d => d.DominioAtivo(It.IsAny<string>())).Returns(false);
		Assert.IsFalse(_validador.DominioAtivo("exemplo@dominioinexistente.com"));
	}

	[Test]
	public void ServidorEmailRespondendo_ServidorRespondendo_RetornaTrue()
	{
		_mockSmtp.Setup(s => s.ServidorEmailRespondendo(It.IsAny<string>())).Returns(true);
		Assert.IsTrue(_validador.ServidorEmailRespondendo("exemplo@exemplo.com"));
	}

	[Test]
	public void ServidorEmailRespondendo_ServidorNaoRespondendo_RetornaFalse()
	{
		_mockSmtp.Setup(s => s.ServidorEmailRespondendo(It.IsAny<string>())).Returns(false);
		Assert.IsFalse(_validador.ServidorEmailRespondendo("exemplo@dominioinexistente.com"));
	}
}
//ROBERTO HENRIQUE E AGATHA MOURA
//DSI02-T