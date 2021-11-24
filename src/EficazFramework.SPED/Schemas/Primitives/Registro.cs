
namespace EficazFrameworkCore.SPED.Schemas.Primitives
{
    public abstract class Registro
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Registro(string linha, string versao)
        {
            if (linha != null)
            {
                _versao = versao;
                if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
                {
                    var data = linha.Split("|");
                    if (data.Length > 1)
                    {
                        _codigo = data[1];
                    }
                    else
                    {
                        _codigo = GetType().Name.Replace("Registro", string.Empty);
                    }
                }
            }
        }

        public Registro(string codigo)
        {
            _codigo = codigo;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string _codigo;
        private string _versao = "011";

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string Codigo
        {
            get
            {
                return _codigo;
            }
        }

        public string Versao
        {
            get
            {
                return _versao;
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal void OverrideVersao(string novaVersao)
        {
            _versao = novaVersao;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public abstract void LeParametros(string[] data);
        public abstract string EscreveLinha();

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override string ToString()
        {
            // Return MyBase.ToString()
            return EscreveLinha();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}