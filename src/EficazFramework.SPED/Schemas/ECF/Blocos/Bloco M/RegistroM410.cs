
namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Lançamento na Conta da Parte B do e-Lalur e do e-Lacs sem Reflexo na Parte A
    /// </summary>
    public class RegistroM410 : Primitives.Registro
    {
        public RegistroM410() : base("M410")
        {
        }

        public RegistroM410(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CodigoContaParteB { get; set; } = null;
        /// <summary>
        /// I = IRPJ
        /// C = CSLL
        /// </summary>
        public string CodigoTributo { get; set; } = null;
        public double? Valor { get; set; } = default;
        /// <summary>
        /// CR = Crédito
        /// DB = Débito
        /// PR = Prejuízo do Exerício
        /// BC = Base de Cálculo Negativa da CSLL
        /// </summary>
        public string IndicadorRelacao { get; set; } = null;
        /// <summary>
        /// Caso seja necessária a transferência de saldo de uma conta na parte B para outra conta na parte B
        /// </summary>
        public string CodigoContaParteB_Destino { get; set; } = null;
        public string Historico { get; set; } = null;
        public bool LanctoExerciciosAnteriores { get; set; } = false;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|M410|");
            writer.Append(CodigoContaParteB + "|");
            writer.Append(CodigoTributo + "|");
            writer.Append(string.Format("{0:F2}", Valor) + "|");
            writer.Append(IndicadorRelacao + "|");
            writer.Append(CodigoContaParteB_Destino + "|");
            writer.Append(Historico + "|");
            if (LanctoExerciciosAnteriores)
                writer.Append("S|");
            else
                writer.Append("N|"); // 3
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}