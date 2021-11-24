using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{


    /// <summary>
    /// Código de Grupos por Marca Comercial - Refri (Bebidas Frias)
    /// </summary>
    /// <remarks></remarks>

    public class Registro0208 : Primitives.Registro
    {
        public Registro0208() : base("0208")
        {
        }

        public Registro0208(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public CodigoTabelaIncidencia CodigoTabelaIncidencia { get; set; } = CodigoTabelaIncidencia.TabelaI;
        public string CodigoGrupoAnexoIII { get; set; } = null; // tamanho 2'
        public string MarcaComercial { get; set; } = null; // tamanho 60'

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0208|");
            writer.Append(((int)CodigoTabelaIncidencia).ToString() + "|");
            writer.Append(CodigoGrupoAnexoIII + "|");
            writer.Append(MarcaComercial + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoTabelaIncidencia = (CodigoTabelaIncidencia)data[2].ToEnum<CodigoTabelaIncidencia>(CodigoTabelaIncidencia.TabelaI);
            CodigoGrupoAnexoIII = data[3];
            MarcaComercial = data[4];
        }
    }
}