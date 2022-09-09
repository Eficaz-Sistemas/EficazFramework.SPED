using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.LCDPR.Bloco0;

public class Registro0040 : Tests.BaseTest
{
    [Test]
    public void Construtor()
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0040();
        reg.Codigo.Should().Be("0040");
    }

    
    [TestCase("0040|145|BR|BRL|26726181|1234567890000468|0011234560201|Fazenda São João|Fazenda São João|1||Zona Rural|MG|3129707|37990000|1|10000")]
    public void Construtor(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0040(linha, versao);
        InternalRead(reg, versao);
    }


    [TestCase("0040|145|BR|BRL|26726181|1234567890000468|0011234560201|Fazenda São João|Fazenda São João|1||Zona Rural|MG|3129707|37990000|1|10000")]
    public void Escrita(string result, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0040("", versao)
        {
            IDImovel = 145,
            Pais = "BR",
            Moeda = "BRL",
            NIRF = "26726181",
            CAEPF = "1234567890000468",
            InscricaoEstadual = "0011234560201",
            NomeImovel = "Fazenda São João",
            Endereco = "Fazenda São João",
            Numero = "1",
            Complemento = "",
            Bairro = "Zona Rural",
            UF = "MG",
            CodigoMunicipio = "3129707",
            CEP = "37990000",
            TipoExploracao = TipoExploracao.Individual,
            Percentual = 100d,
        };
        reg.ToString().Should().Be(result);

    }


    [TestCase("0040|145|BR|BRL|26726181|1234567890000468|0011234560201|Fazenda São João|Fazenda São João|1||Zona Rural|MG|3129707|37990000|1|10000")]
    public void Leitura(string linha, string versao = "0013")
    {
        var reg = new EficazFramework.SPED.Schemas.LCDPR.Registro0040("", versao);
        reg.IDImovel.Should().Be(null);
        reg.Pais.Should().Be("BR"); //default
        reg.Moeda.Should().Be("BRL"); //default
        reg.NIRF.Should().Be(null);
        reg.InscricaoEstadual.Should().Be(null);
        reg.CAEPF.Should().Be(null);
        reg.NomeImovel.Should().Be(null);
        reg.Endereco.Should().Be(null);

        reg.LeParametros(linha.Split('|'));
        InternalRead(reg, versao);
    }


    private void InternalRead(EficazFramework.SPED.Schemas.LCDPR.Registro0040 reg, string versao = "0013")
    {
        reg.Codigo.Should().Be("0040");
        reg.Versao.Should().Be(versao);
        reg.IDImovel.Should().Be(145);
        reg.Pais.Should().Be("BR");
        reg.Moeda.Should().Be("BRL");
        reg.NIRF.Should().Be("26726181");
        reg.CAEPF.Should().Be("1234567890000468");
        reg.InscricaoEstadual.Should().Be("0011234560201");
        reg.NomeImovel.Should().Be("Fazenda São João");
        reg.Endereco.Should().Be("Fazenda São João");
        reg.Numero.Should().Be("1");
        reg.Complemento.Should().BeEmpty();
        reg.Bairro.Should().Be("Zona Rural");
        reg.UF.Should().Be("MG");
        reg.CodigoMunicipio.Should().Be("3129707");
        reg.CEP.Should().Be("37990000");
        reg.TipoExploracao.Should().Be(TipoExploracao.Individual);
        reg.Percentual.Should().Be(100d);
    }

}
