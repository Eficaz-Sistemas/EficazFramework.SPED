using FluentAssertions;
using NUnit.Framework;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI;

internal class BlocoC
{

    [Test]
    public void RegistroC500()
    {
        var reg = new EficazFramework.SPED.Schemas.EFD_ICMS_IPI.RegistroC500("", "002")
        {
            Operacao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorOperacao.Entrada,
            Emissao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorEmitente.Terceiros,
            CodigoParticipante = "123",
            EspecieDocumento = "06",
            SituacaoDocumento = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.SituacaoDocumento.Regular,
            Serie = "U1",
            CodigoConsumo = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.CodigoConsumoEnEletricaOuGas.Comercial,
            Numero = 12345678,
            DataEmissao = new System.DateTime(2021,6,18),
            DataEntradaSaida = new System.DateTime(2021, 6, 18),
            ValorTotalDocumento = 539.8d,
            ValorFornecidoOuConsumido = 530d,
            ValorDespesasAcessorias = 9.8d,
            ValorBaseCalculoICMS = 539.8d,
            ValorICMS = 100d,
            ValorPIS = 6d,
            ValorCofins = 42d,
            TipoLigacao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.TipoLigacaoEnEletrica.Trifasico,
            CodigoGrupoTensao = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.GrupoTensao.A1,
            ChaveDocE = "5555",
            CompetenciaDocumentoReferenciado = new System.DateTime(2021, 12, 25)
        };
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|");

        reg.OverrideVersao("003");
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|");

        reg.OverrideVersao("014");
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||");

        reg.OverrideVersao("015");
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||");

        reg.OverrideVersao("016");
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555||||||||||122021|||");

        reg.DestinatarioIndicador = EficazFramework.SPED.Schemas.EFD_ICMS_IPI.IndicadorDestinatario.ContribIsentoICMS;
        reg.ToString().Should().Be("|C500|0|1|123|06|00|U1||01|12345678|18062021|18062021|539,8||530|||9,8|539,8|100||||6|42|3|01|5555|||2|||||||122021|||");
    }
}
