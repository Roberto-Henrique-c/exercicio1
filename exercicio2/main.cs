using System;
using System.Net;
using System.Net.Mail;

public class ValidadorEmail
{
    public bool FormatoEmailValido(string email)
    {
        try
        {
            MailAddress enderecoEmail = new MailAddress(email);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public bool DominioAtivo(string email)
    {
        try
        {
            string dominio = email.Split('@')[1];
            IPHostEntry entradaHost = Dns.GetHostEntry(dominio);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public bool ServidorEmailRespondendo(string email)
    {
        try
        {
            string dominio = email.Split('@')[1];
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

_________________________________________

using NUnit.Framework;

[TestFixture]
public class TestesValidadorEmail
{
    private ValidadorEmail validador;

    [SetUp]
    public void Configurar()
    {
        validador = new ValidadorEmail();
    }

    [Test]
    public void FormatoEmailValido_EmailValido_RetornaTrue()
    {
        // Arrange
        string email = "exemplo@exemplo.com";

        // Act
        bool resultado = validador.FormatoEmailValido(email);

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void FormatoEmailValido_EmailInvalido_RetornaFalse()
    {
        // Arrange
        string email = "emailinvalido";

        // Act
        bool resultado = validador.FormatoEmailValido(email);

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void DominioAtivo_DominioAtivo_RetornaTrue()
    {
        // Arrange
        string email = "exemplo@exemplo.com";

        // Act
        bool resultado = validador.DominioAtivo(email);

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void DominioAtivo_DominioInexistente_RetornaFalse()
    {
        // Arrange
        string email = "exemplo@dominioinexistente.com";

        // Act
        bool resultado = validador.DominioAtivo(email);

        // Assert
        Assert.IsFalse(resultado);
    }

    [Test]
    public void ServidorEmailRespondendo_ServidorRespondendo_RetornaTrue()
    {
        // Arrange
        string email = "exemplo@exemplo.com";

        // Act
        bool resultado = validador.ServidorEmailRespondendo(email);

        // Assert
        Assert.IsTrue(resultado);
    }

    [Test]
    public void ServidorEmailRespondendo_ServidorNaoRespondendo_RetornaFalse()
    {
        // Arrange
        string email = "exemplo@dominioinexistente.com";

        // Act
        bool resultado = validador.ServidorEmailRespondendo(email);

        // Assert
        Assert.IsFalse(resultado);
    }
}
//ROBERTO HENRIQUE E AGATHA MOURA
//DSI02-T
