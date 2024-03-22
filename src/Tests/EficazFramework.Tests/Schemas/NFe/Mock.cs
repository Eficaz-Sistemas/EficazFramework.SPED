namespace EficazFramework.SPED.Schemas.Mock;

internal static class NFe
{
    /// <summary>
    /// Iremos preencher sempre a mesma NFe aqui ¬¬
    /// </summary>
    /// <returns></returns>
    public static EficazFramework.SPED.Schemas.NFe.NFe PreencheNFeFake()
    {
        return new()
        {
            InformacoesNFe = new()
            {
                Id = $"NFe{31}{DateTime.Now.Year:00}{DateTime.Now.Month:00}10608025000126550010000000011123456781",
                Versao = "4.00",
                IdentificacaoOperacao = new()
                {
                    UF = Schemas.NFe.OrgaoIBGE.MG,
                    Chave = "12345678",
                    NaturezaOperacao = "Teste de homologação de autorização de NFe",
                    Modelo = Schemas.NFe.ModeloDocumento.NFe,
                    Serie = 1,
                    Numero = 1,
                    DataHoraEmissao = DateTime.Now,
                    DataHoraSaidaEntrada = DateTime.Now,
                    TipoOperacao = Schemas.NFe.OperacaoNFe.Saida,
                    DestinoOperacao = Schemas.NFe.DestinoOperacao.Interna,
                    CodigoMunicipio = "3129707",
                    TipoImpressao = Schemas.NFe.TipoImpressao.Retrato,
                    FormaEmissao = Schemas.NFe.FormaEmissao.Normal,
                    ChaveDigitoVerificador = "1",
                    Ambiente = Schemas.NFe.Ambiente.Homologacao,
                    Finalidade = Schemas.NFe.FinalidadeEmissao.Normal,
                    ConsumidorFinal = false,
                    TipoAtendimento = Schemas.NFe.TipoAtendimento.NaoPresencial_Outros,
                    VersaoProcessoEmissao = typeof(Schemas.NFe.NFe).Assembly.ImageRuntimeVersion,
                },
                Emitente = new()
                {
                    CNPJ_CPF = "10608025000126",
                    RazaoSocial = "Teste Emitente Homologação S/A",
                    Endereco = new()
                    {
                        Logradouro = "Rua de Teste",
                        Numero = "123",
                        Bairro = "Centro",
                        MunicipioCodigo = "3129707",
                        MunicipioNome = "Ibiraci",
                        UF = Schemas.NFe.Estado.MG,
                        CEP = "37990000",
                        PaisCodigo = "1058",
                        PaisNome = "Brasil"
                    },
                    InscricaoEstadual = "0011074240030",
                    RegimeTributario = Schemas.NFe.RegimeTributario.SimplesNacional
                },
                Destinatario = new()
                {
                    CNPJ_CPF = "18398117000130",
                    RazaoSocial = "Teste Destinatário Ltda",
                    Endereco = new()
                    {
                        Logradouro = "Rua de Teste",
                        Numero = "123",
                        Bairro = "Centro",
                        MunicipioCodigo = "3129707",
                        MunicipioNome = "Ibiraci",
                        UF = Schemas.NFe.Estado.MG,
                        CEP = "37990000",
                        PaisCodigo = "1058",
                        PaisNome = "Brasil",
                        Fone = "3535440001"
                    },
                    IndicadorInscricaoEstDestinatorio = Schemas.NFe.IndicadorIeDestinatario.NaoContribuinte,
                    InscricaoEstadual = "0648480792506"
                },
                Items =
                [
                    new()
                    {
                        NumeroSequencial = "1",
                        Dados = new()
                        {
                            Codigo = "ABC",
                            GTIN = "789000000000",
                            Descricao = "Guaraná Fantástica 2L",
                            NCM = "22021000",
                            CEST = "0301000",
                            CFOP = "5405",
                            UnidadeComercial = "Un",
                            QuantidadeComercial = 9,
                            ValorUnitarioComercial = 9.99,
                            ValorDesconto = 9.91,
                            ValorTotalBruto = 80,
                            GTIN_Tributavel = "789000000000",
                            UnidadeTributavel = "Un",
                            ValorUnitarioTributavel = 9.99,
                            IndicadorComposicaoTotal = Schemas.NFe.IndicadorTotal.CompoeTotal
                        },
                        Imposto = new()
                        {
                            ValorTotalTributos = 6.28,
                            IcmsIpiIssqnIi =
                            [
                                new Schemas.NFe.DetalhamentoICMS()
                                {
                                    TributacaoIndentifier = Schemas.NFe.Tributacao_ICMS_Identifier.ICMS60,
                                    Tributacao = new()
                                    {
                                        Origem = Schemas.NFe.OrigemMercadoria.Nacional,
                                        CST = Schemas.NFe.CST_ICMS.CST_60,
                                        vBCSTRet = 132.17,
                                        pST = 18,
                                        vICMSSTRet = 23.79,
                                    }
                                }
                            ],
                            PIS = new Schemas.NFe.DetalhamentoPIS()
                            {
                                TributacaoIndentifier = Schemas.NFe.Tributacao_PIS_Identifier.PISOutr,
                                Tributacao = new()
                                {
                                    CST = Schemas.NFe.CST_PIS.OutrasOpSaidas,
                                    pPIS = 0.0,
                                    vBC = 0.0,
                                    vPIS = 0.0
                                }
                            },
                            COFINS = new Schemas.NFe.DetalhamentoCOFINS()
                            {
                                TributacaoIndentifier = Schemas.NFe.Tributacao_COFINS_Identifier.COFINSOutr,
                                Tributacao = new()
                                {
                                    CST = Schemas.NFe.CST_COFINS.OutrasOpSaidas,
                                    pCOFINS = 0.0,
                                    vBC = 0.0,
                                    vCOFINS = 0.0
                                }
                            }
                        }
                    }
                ],
                Totais = new()
                {
                    ICMS = new()
                    {
                        BaseDeCalculo = 0.0,
                        ICMS = 0.0,
                        BaseDeCalculoST = 0.0,
                        ICMSST = 0.0,
                        Produtos = 89.91,
                        Desconto = 9.91,
                        Frete = 0.0,
                        Seguros = 0.0,
                        II = 0.0,
                        IPI = 0.0,
                        vIPIDevol = 0.0,
                        PIS = 0.0,
                        COFINS = 0.0,
                        Outros = 0.0,
                        TotalNF = 80
                    }
                }
            }
        };
    }

}
