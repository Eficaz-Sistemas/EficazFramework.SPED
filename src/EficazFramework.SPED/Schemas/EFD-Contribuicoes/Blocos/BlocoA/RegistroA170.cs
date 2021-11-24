using EficazFrameworkCore.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento do Documento - Itens do Documento
    /// </summary>
    /// <remarks></remarks>

    public class RegistroA170 : Primitives.Registro
    {
        public RegistroA170() : base("A170")
        {
        }

        public RegistroA170(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public int? NumeroItem { get; set; }
        public string CodigoItem { get; set; } = null;
        public string DescricaoComplementarItem { get; set; } = null;
        public double? VrTotalItem { get; set; }
        public double? VrTotalDesconto { get; set; }
        public NaturezaBaseCalculo NaturezaBCCalculo { get; set; } = NaturezaBaseCalculo.AquisBensRevenda;
        public IndicadorOrigemCredito IndicadorOrigemCredito { get; set; } = IndicadorOrigemCredito.OperacaoMercadoInterno;
        public string CSTPis { get; set; } = null;
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrBaseCalculoCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;
        public string CodigoCentroCusto { get; set; } = null;
        public IndicadorTipoOperacao IndicadorTipoOperacao { get; set; } = IndicadorTipoOperacao.ServicoPrestadoEstabelecimento; // not mapped on TXT

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|A170|");
            writer.Append(NumeroItem + "|");
            writer.Append(CodigoItem + "|");
            writer.Append(DescricaoComplementarItem + "|");
            writer.Append(VrTotalItem + "|");
            writer.Append(VrTotalDesconto + "|");
            if (IndicadorTipoOperacao == IndicadorTipoOperacao.ServicoContratadoEstabelecimento)
                writer.Append(string.Format("{0:00}", (int)NaturezaBCCalculo) + "|");
            else
                writer.Append("|");
            if (IndicadorTipoOperacao == IndicadorTipoOperacao.ServicoContratadoEstabelecimento)
                writer.Append(((int)IndicadorOrigemCredito).ToString() + "|");
            else
                writer.Append("|");
            writer.Append(CSTPis + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrBaseCalculoCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            writer.Append(CodigoCentroCusto + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroItem = data[2].ToNullableInteger();
            CodigoItem = data[3];
            DescricaoComplementarItem = data[4];
            VrTotalItem = data[5].ToNullableDouble();
            VrTotalDesconto = data[6].ToNullableDouble();
            NaturezaBCCalculo = (NaturezaBaseCalculo)data[7].ToEnum<NaturezaBaseCalculo>(NaturezaBaseCalculo.AquisBensRevenda);
            IndicadorOrigemCredito = (IndicadorOrigemCredito)Conversions.ToInteger(data[8]);
            CSTPis = data[9];
            VrBaseCalculoPis = data[10].ToNullableDouble();
            AliquotaPis = data[11].ToNullableDouble();
            VrPis = data[12].ToNullableDouble();
            CSTCofins = data[13];
            VrBaseCalculoCofins = data[14].ToNullableDouble();
            AliquotaCofins = data[15].ToNullableDouble();
            VrCofins = data[16].ToNullableDouble();
            CodigoContaContabil = data[17];
            CodigoCentroCusto = data[18];
        }
    }
}