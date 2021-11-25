
namespace EficazFramework.SPED.Schemas.CNAB240
{

    /// <summary>
    /// Registro Detalhe
    /// </summary>
    public abstract class Registro3 : Primitives.Registro
    {
        public Registro3() : base("3")
        {
        }

        public Registro3(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            return "";
        }

        public override void LeParametros(string[] data)
        {
        }
    }

    /// <summary>
    /// Registro Detalhe: Tipo de Movimento
    /// </summary>
    public abstract class Registro3N_AnexoC : Primitives.Registro
    {
        public Registro3N_AnexoC() : base("3")
        {
        }

        public Registro3N_AnexoC(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            return "";
        }

        public override void LeParametros(string[] data)
        {
        }
    }
}