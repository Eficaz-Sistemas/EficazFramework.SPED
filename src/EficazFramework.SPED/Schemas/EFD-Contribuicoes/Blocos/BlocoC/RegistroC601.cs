using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da Consolidação Diária
    /// </summary>
    /// <remarks></remarks>

    public class RegistroC601 : Primitives.Registro
    {
        public RegistroC601() : base("C601")
        {
        }

        public RegistroC601(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CstPis { get; set; } = null;
        public double? VrTotaItens { get; set; }
        public double? VrBaseCalculoPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CodContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|C601|");
            writer.Append(CstPis + "|");
            writer.Append(VrTotaItens + "|");
            writer.Append(VrBaseCalculoPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CodContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CstPis = data[2];
            VrTotaItens = data[3].ToNullableDouble();
            VrBaseCalculoPis = data[4].ToNullableDouble();
            AliquotaPis = data[5].ToNullableDouble();
            VrPis = data[6].ToNullableDouble();
            CodContaContabil = data[7];
        }
    }
}