using System.Collections.Generic;
using EficazFrameworkCore.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.SP.eRessarcimento.CAT42
{

    /// <summary>
    /// Tabela de Identificação do Item (Produtos e Serviços)
    /// </summary>
    /// <remarks></remarks>
    public class Registro0200 : Primitives.Registro
    {
        public string ID { get; set; } = null;
        public string Descricao { get; set; } = null;
        public string CodigoBarras { get; set; } = null;
        public string UnidadeInventariada { get; set; } = null;
        public string NCM { get; set; } = null;
        public double? AliquotaICMS { get; set; } = default;
        public string CEST { get; set; } = null;
        public double? MVA { get; set; } = default;
        public double? PautaBC { get; set; } = default;

        // Registros Filhos
        public List<Registro0205> Registros0205 { get; set; } = new List<Registro0205>();

        public Registro0200() : base("0200")
        {
        }

        public Registro0200(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0200|"); // 1
            writer.Append(ID + "|"); // 2
            writer.Append(Descricao ?? "".ToString().GetClearText() + "|"); // 3
            writer.Append(CodigoBarras + "|"); // 4
            writer.Append(UnidadeInventariada + "|"); // 5
            writer.Append(NCM + "|"); // 6
            writer.Append(string.Format("{0:0.00}", AliquotaICMS) + "|"); // 7
            writer.Append(CEST); // 8
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}