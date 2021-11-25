using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Operaçãoes da Atividade imobiliária - custo orçado da unidade imobiliária vendida
    /// </summary>
    /// <remarks></remarks>

    public class RegistroF210 : Primitives.Registro
    {
        public RegistroF210() : base("F210")
        {
        }

        public RegistroF210(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public double? VrTotalCustoOrcadoConcUnidVendida { get; set; }
        public double? VrExcl { get; set; }
        public double? VrBcCredCustoOrcadoAjustado { get; set; }
        public double? VrBcCredCustoOrcadoPeriodoEscr { get; set; }
        public string CSTPis { get; set; } = null;
        public double? AliqPis { get; set; }
        public double? VrCreditoCustoOrcadoPeriodoEscrPis { get; set; }
        public string CSTCofins { get; set; } = null;
        public double? AliqCofins { get; set; }
        public double? VrCreditoCustoOrcadoPeriodoEscrCofins { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|F210|");
            writer.Append(VrTotalCustoOrcadoConcUnidVendida + "|");
            writer.Append(VrExcl + "|");
            writer.Append(VrBcCredCustoOrcadoAjustado + "|");
            writer.Append(VrBcCredCustoOrcadoPeriodoEscr + "|");
            writer.Append(CSTPis + "|");
            writer.Append(AliqPis + "|");
            writer.Append(VrCreditoCustoOrcadoPeriodoEscrPis + "|");
            writer.Append(CSTCofins + "|");
            writer.Append(AliqCofins + "|");
            writer.Append(VrCreditoCustoOrcadoPeriodoEscrCofins + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            VrTotalCustoOrcadoConcUnidVendida = data[2].ToNullableDouble();
            VrExcl = data[3].ToNullableDouble();
            VrBcCredCustoOrcadoAjustado = data[4].ToNullableDouble();
            VrBcCredCustoOrcadoPeriodoEscr = data[5].ToNullableDouble();
            CSTPis = data[6];
            AliqPis = data[7].ToNullableDouble();
            VrCreditoCustoOrcadoPeriodoEscrPis = data[8].ToNullableDouble();
            CSTCofins = data[9];
            AliqPis = data[10].ToNullableDouble();
            VrCreditoCustoOrcadoPeriodoEscrCofins = data[11].ToNullableDouble();
        }
    }
}