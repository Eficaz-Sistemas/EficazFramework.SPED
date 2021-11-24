using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Informacao Complementar - Operações de Importação
    /// </summary>
    /// <remarks></remarks>

    public class RegistroA120 : Primitives.Registro
    {
        public RegistroA120() : base("A120")
        {
        }

        public RegistroA120(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalServicoPFouPJExterior { get; set; }
        public double? VrBaseCalculoPis { get; set; }
        public double? VrPisImportacao { get; set; }
        public DateTime? DataPgtoPisImportacao { get; set; }
        public double? VrBaseCalculoCofins { get; set; }
        public double? VrCofinsImportacao { get; set; }
        public DateTime? DataPgtoCofinsImportacao { get; set; }
        public LocalExecucaoServico LocalExecucaoServico { get; set; } = LocalExecucaoServico.ExecutadoPais;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|A120|");
            writer.Append(VrTotalServicoPFouPJExterior + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(VrPisImportacao + "|");
            writer.Append(DataPgtoPisImportacao.ToSpedString() + "|");
            writer.Append(VrBaseCalculoCofins + "|");
            writer.Append(VrCofinsImportacao + "|");
            writer.Append(DataPgtoCofinsImportacao.ToSpedString() + "|");
            writer.Append(((int)LocalExecucaoServico).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalServicoPFouPJExterior = data[2].ToNullableDouble();
            VrBaseCalculoPis = data[3].ToNullableDouble();
            VrPisImportacao = data[4].ToNullableDouble();
            DataPgtoPisImportacao = data[5].ToDate();
            VrBaseCalculoCofins = data[6].ToNullableDouble();
            VrCofinsImportacao = data[7].ToNullableDouble();
            DataPgtoCofinsImportacao = data[8].ToDate();
            LocalExecucaoServico = (LocalExecucaoServico)data[9].ToEnum<LocalExecucaoServico>(LocalExecucaoServico.ExecutadoPais);
        }
    }
}