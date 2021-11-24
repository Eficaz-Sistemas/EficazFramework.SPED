using System.Collections.Generic;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Equipamento ECF
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC400 : Primitives.Registro
    {
        public RegistroC400() : base("C400")
        {
        }

        public RegistroC400(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoModeloDocFiscal { get; set; } = null;
        public string ModeloEquipamento { get; set; } = null;
        public string NumeroSerieFabricacaoECF { get; set; } = null;
        public string NumeroCaixaAtribuidoECF { get; set; } = null;
        public List<RegistroC405> RegistrosC405 { get; set; } = new List<RegistroC405>();
        public List<RegistroC489> RegistrosC489 { get; set; } = new List<RegistroC489>();

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C400|");
            writer.Append(CodigoModeloDocFiscal + "|");
            writer.Append(ModeloEquipamento + "|");
            writer.Append(NumeroSerieFabricacaoECF + "|");
            writer.Append(NumeroCaixaAtribuidoECF + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoModeloDocFiscal = data[2];
            ModeloEquipamento = data[3];
            NumeroSerieFabricacaoECF = data[4];
            NumeroCaixaAtribuidoECF = data[5];
        }
    }
}