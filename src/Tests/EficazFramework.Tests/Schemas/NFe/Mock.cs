namespace EficazFramework.SPED.Schemas.Mock;

internal static class NFe
{
    /// <summary>
    /// Iremos preencher sempre a mesma NFe aqui ¬¬
    /// </summary>
    /// <returns></returns>
    public static EficazFramework.SPED.Schemas.NFe.NFe PreencheNFeFake()
    {
        string chave43 = $"{31}{DateTime.Now:yy}{DateTime.Now:MM}1060802500012655001000000001100000002";
        string cNF = "00000002";
        string cDV = Utilities.XML.NFe.CalculaDigitoVerificador(chave43);

        return new()
        {
            InformacoesNFe = new()
            {
                Id = $"NFe{chave43}{cDV}",
                Versao = "4.00",
                IdentificacaoOperacao = new()
                {
                    UF = Schemas.NFe.OrgaoIBGE.MG,
                    Chave = cNF,
                    NaturezaOperacao = "Teste de homologação de autorização de NFe",
                    Modelo = Schemas.NFe.ModeloDocumento.NFe,
                    Serie = 1,
                    Numero = 1,
                    DataHoraEmissao = DateTime.Now.AddHours(-5),
                    DataHoraSaidaEntrada = DateTime.Now.AddHours(5),
                    TipoOperacao = Schemas.NFe.OperacaoNFe.Saida,
                    DestinoOperacao = Schemas.NFe.DestinoOperacao.Interna,
                    CodigoMunicipio = "3129707",
                    TipoImpressao = Schemas.NFe.TipoImpressao.Retrato,
                    FormaEmissao = Schemas.NFe.FormaEmissao.Normal,
                    ChaveDigitoVerificador = cDV,
                    Ambiente = Schemas.NFe.Ambiente.Homologacao,
                    Finalidade = Schemas.NFe.FinalidadeEmissao.Normal,
                    ConsumidorFinal = Schemas.NFe.IndicadorConsumidorFinal.Nao,
                    TipoAtendimento = Schemas.NFe.TipoAtendimento.Presencial,
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
                    RazaoSocial = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL",
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
                    IndicadorInscricaoEstDestinatorio = Schemas.NFe.IndicadorIeDestinatario.Contribuinte,
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
                            GTIN = "7891991000826",
                            Descricao = "Guaraná Fantástica 2L",
                            NCM = "22021000",
                            CEST = "0301000",
                            CFOP = "5405",
                            UnidadeComercial = "Un",
                            QuantidadeComercial = 9,
                            ValorUnitarioComercial = 9.99,
                            ValorDesconto = 9.91,
                            ValorTotalBruto = 89.91,
                            GTIN_Tributavel = "7891991000826",
                            QuantidadeTributavel = 9,
                            UnidadeTributavel = "Un",
                            ValorUnitarioTributavel = 9.99,
                            IndicadorComposicaoTotal = Schemas.NFe.IndicadorTotal.CompoeTotal
                        },
                        Imposto = new()
                        {
                            ValorTotalTributos = 6.28,
                            EstaduaisMunicipais =
                            [
                                new Schemas.NFe.DetalhamentoICMS()
                                {
                                    TributacaoIndentifier = Schemas.NFe.Tributacao_ICMS_Identifier.ICMSSN500,
                                    Tributacao = new()
                                    {
                                        Origem = Schemas.NFe.OrigemMercadoria.Nacional,
                                        CSOSN = Schemas.NFe.CSOSN_ICMS.CST500,
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
                        Produtos = 89.91,
                        Desconto = 9.91,
                        TotalNF = 80,
                        TotalTributos = 6.28
                    }
                },
                Transporte = new()
                {
                    Modalidade = Schemas.NFe.ModalidadeFrete.Emitente,
                    Transportadora = new()
                    {
                        CNPJ_CPF = "26396769000164",
                        RazaoSocial = "Transportadora Express",
                        InscricaoEstadual = "1901965978011",
                        Endereco = "Rodovia do Transporte, 123",
                        Municipio = "Ibiraci",
                        UF = Schemas.NFe.Estado.MG,
                        UFSpecified = true
                    },
                    Volumes =
                    [
                        new()
                        {
                            qVol = 60,
                            esp = "VOL",
                            pesoL = 140.4,
                            pesoB = 140.7
                        }
                    ]
                },
                Cobranca = new()
                {
                    fat = new()
                    {
                        nFat = "3145082",
                        vOrig = 89.91,
                        vDesc = 9.91,
                        vLiq = 80
                    },
                    dup =
                    [
                        new()
                        {
                            nDup = "001",
                            dVenc = DateTime.Now.AddMonths(1),
                            vDup = 40
                        },
                        new()
                        {
                            nDup = "002",
                            dVenc = DateTime.Now.AddMonths(2),
                            vDup = 40
                        }

                    ]
                },
                Pagamento = new()
                {
                    DetalhamentoPagamentos =
                    [
                        new()
                        {
                            indPag = Schemas.NFe.FormaDePagamento.Prazo,
                            tPag = Schemas.NFe.FormaPagamento.BoletoBancario,
                            vPag = 40
                        },
                        new()
                        {
                            indPag = Schemas.NFe.FormaDePagamento.Prazo,
                            tPag = Schemas.NFe.FormaPagamento.BoletoBancario,
                            vPag = 40
                        }
                    ]
                }
            }
        };
    }

}
