using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Complemento da Consolidação da Prestação de Serviços
    /// </summary>
    /// <remarks></remarks>

    public class RegistroD601 : Primitives.Registro
    {
        public RegistroD601() : base("D601")
        {
        }

        public RegistroD601(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoClassifItemServComun { get; set; } = null;
        public double? VrAcumItem { get; set; }
        public double? VrAcumDesconto { get; set; }
        public string CstPis { get; set; } = null;
        public double? VrBcPis { get; set; }
        public double? AliquotaPis { get; set; }
        public double? VrPis { get; set; }
        public string CodigoContaContabil { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|D601|");
            writer.Append(CodigoClassifItemServComun + "|");
            writer.Append(VrAcumItem + "|");
            writer.Append(VrAcumDesconto + "|");
            writer.Append(CstPis + "|");
            writer.Append(VrBcPis + "|");
            writer.Append(AliquotaPis + "|");
            writer.Append(VrPis + "|");
            writer.Append(CodigoContaContabil + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoClassifItemServComun = data[2];
            VrAcumItem = data[3].ToNullableDouble();
            VrAcumDesconto = data[4].ToNullableDouble();
            CstPis = data[5];
            VrBcPis = data[6].ToNullableDouble();
            AliquotaPis = data[7].ToNullableDouble();
            VrPis = data[8].ToNullableDouble();
            CodigoContaContabil = data[9];
        }
    }
}