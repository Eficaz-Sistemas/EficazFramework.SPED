using System;

namespace EficazFrameworkCore.SPED.Schemas.SP.eCredAc.CAT207
{

    /// <summary>
    /// Devolução de Saídas
    /// </summary>
    /// <remarks></remarks>
    public class Registro5320 : Primitives.Registro
    {
        public DateTime? DataSaidaDocPrincipal { get; set; } = default;
        public int? EspecieSaidaDocPrincipal { get; set; }
        public string SerieSaidaDocPrincipal { get; set; } = null;
        public int? NumeroSaidaDocPrincipal { get; set; } = default;

        public Registro5320() : base("5320")
        {
        }

        public Registro5320(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("5320|");
            writer.Append(string.Format("{0:ddMMyyyy}", DataSaidaDocPrincipal) + "|");
            writer.Append(string.Format("{0:00}", EspecieSaidaDocPrincipal) + "|");
            writer.Append(SerieSaidaDocPrincipal + "|");
            writer.Append(NumeroSaidaDocPrincipal);
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}