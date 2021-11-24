using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Resumo Diário de Cupom Fiscal Emitido Por ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD350 : Primitives.Registro
    {
        public RegistroD350() : base("D350")
        {
        }

        public RegistroD350(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string ModeloEquipamentoECF { get; set; } = null;
        public string NumeroSerieFabricacaoECF { get; set; } = null;
        public DateTime? DataMovimentoReducaoZ { get; set; }
        public int? ContadorReinicioOperacao { get; set; }
        public int? ContadorReducaoZ { get; set; }
        public int? NumeroContadorOrdemOperacao { get; set; }
        public double? GrandeTotalFinal { get; set; }
        public double? VrVendaBruta { get; set; }
        public string CSTPis { get; set; } = null;
        public double? VrBcPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? BcPisQtde { get; set; }
        public double? AliquotaPisQtde { get; set; }
        public double? VrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? VrBcCofins { get; set; }
        public double? AliquotaCofins { get; set; }
        public double? BcCofinsQtde { get; set; }
        public double? AliquotaCofinsQtde { get; set; }
        public double? VrCofins { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D350|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(ModeloEquipamentoECF + "|");
            writer.Append(NumeroSerieFabricacaoECF + "|");
            writer.Append(DataMovimentoReducaoZ + "|");
            writer.Append(ContadorReinicioOperacao + "|");
            writer.Append(ContadorReducaoZ + "|");
            writer.Append(NumeroContadorOrdemOperacao + "|");
            writer.Append(GrandeTotalFinal + "|");
            writer.Append(VrVendaBruta + "|");
            writer.Append(CSTPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(BcPisQtde + "|");
            writer.Append(AliquotaPisQtde + "|");
            writer.Append(VrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(VrBcCofins + "|");
            writer.Append(AliquotaCofins + "|");
            writer.Append(BcCofinsQtde + "|");
            writer.Append(AliquotaCofinsQtde + "|");
            writer.Append(VrCofins + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocFiscal = data[2];
            ModeloEquipamentoECF = data[3];
            NumeroSerieFabricacaoECF = data[4];
            DataMovimentoReducaoZ = data[5].ToDate();
            ContadorReinicioOperacao = data[6].ToNullableInteger();
            ContadorReducaoZ = data[7].ToNullableInteger();
            NumeroContadorOrdemOperacao = data[8].ToNullableInteger();
            GrandeTotalFinal = data[9].ToNullableDouble();
            VrVendaBruta = data[10].ToNullableDouble();
            CSTPis = data[11];
            VrBcPis = data[12].ToNullableDouble();
            AliquotaPis = data[13].ToNullableDouble();
            BcPisQtde = data[14].ToNullableDouble();
            AliquotaPisQtde = data[15].ToNullableDouble();
            VrPis = data[16].ToNullableDouble();
            CSTCofins = data[17];
            VrBcCofins = data[18].ToNullableDouble();
            AliquotaCofins = data[19].ToNullableDouble();
            BcCofinsQtde = data[20].ToNullableDouble();
            AliquotaCofinsQtde = data[21].ToNullableDouble();
            VrCofins = data[22].ToNullableDouble();
            CodigoContaContabil = data[23];
        }
    }
}