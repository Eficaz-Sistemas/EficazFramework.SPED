namespace EficazFramework.SPED.Schemas.Mock;

internal static class NFSe
{
    /// <summary>
    /// Iremos preencher sempre a mesma NFe aqui ¬¬
    /// </summary>
    /// <returns></returns>
    public static EficazFramework.SPED.Schemas.NFSe.Nacional.DeclaracaoPrestacaoServico PreencheNFSeNacionalDpsFake()
    {
        return new()
        {
            versao = "1.00",
            InfDPS = new()
            {
                Id = "DPS351620021060802500012649999000000000000113",
                Ambiente = Schemas.NFSe.Nacional.Ambiente.Homologacao,
                DataHoraEmissao = new DateTimeOffset(2026, 1, 10, 0, 0, 0, TimeSpan.FromHours(-3)),
                VersaoAplicativo = "SilTecnologia_v1.00",
                Serie = "49999",
                Numero = 113,
                Competencia = "2026-01-01",
                TipoEmitente = EficazFramework.SPED.Schemas.NFSe.Nacional.EmitenteDps.Prestador,
                LocalEmissaoCodigo = "3516200",
                Prestador = new()
                {
                    Cnpj = "10608025000126",
                    InscricaoMunicipal = "000",
                    Telefone = "1681282669",
                    Email = "DANIEL8304@GMAIL.COM",
                    RegimeTributario = new()
                    {
                        OptanteSimplesNacional = 3,
                        regApTribSN = 2,
                        RegimeEspecial = 0
                    }
                },
                Tomador = new()
                {
                    CNPJ = "07170885000116",
                    xNome = "Ataide Marcelino Advogados",
                    Endereco = new()
                    {
                        Nacional = new()
                        {
                            MunicipioCodigo = "3516200",
                            CEP = "14406022"
                        },
                        Logradouro = "Avenida das Seringueiras",
                        Numero = "1000",
                        Bairro = "Residencial Amazonas"
                    }
                },
                Servico = new()
                {
                    LocalPrestacao = new()
                    {
                        Codigo = "3516200"
                    },
                    InfoServico = new()
                    {
                        CodigoTribNacional = "171901",
                        Descricao = "Honorários Contábeis - Serviços de Consultoria Tributária - Mês 12/2025",
                        NBS = "113022100"
                    }
                },
                Valores = new()
                {
                    ValoresPrestacao = new()
                    {
                        ValorServico = 1.00m
                    },
                    Tributos = new()
                    {
                        Municipais = new()
                        {
                            Issqn = "1",
                            TipoRetencao = "1"
                        },
                        tribFed = new(),
                        TotalTributos = new()
                        {
                            ValorTotalTributos = new()
                            {
                                Federais = 0.00m,
                                Estaduais = 0.00m,
                                Municipais = 0.00m
                            }
                        }
                    }
                }
            }
        };
    }

}
