
namespace EficazFrameworkCore.SPED.Extensions.NFe
{
    public class NFe
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public static Schemas.NFe.SituacaoManifestacaoDestinatario ToSituacaoManifesto(Schemas.NFe.CodigoEvento acao)
        {
            switch (acao)
            {
                case Schemas.NFe.CodigoEvento.Ciencia:
                    {
                        return Schemas.NFe.SituacaoManifestacaoDestinatario.Ciencia;
                    }

                case Schemas.NFe.CodigoEvento.Confirmacao:
                    {
                        return Schemas.NFe.SituacaoManifestacaoDestinatario.Confirmada;
                    }

                case Schemas.NFe.CodigoEvento.Desconhecimento:
                    {
                        return Schemas.NFe.SituacaoManifestacaoDestinatario.Desconhecida;
                    }

                case Schemas.NFe.CodigoEvento.NaoRealizada:
                    {
                        return Schemas.NFe.SituacaoManifestacaoDestinatario.NaoRealizada;
                    }

                default:
                    {
                        return Schemas.NFe.SituacaoManifestacaoDestinatario.SemManifestacao;
                    }
            }
        }

        public static Schemas.NFe.CodigoEvento ToAcaoManifesto(Schemas.NFe.SituacaoManifestacaoDestinatario acao)
        {
            switch (acao)
            {
                case Schemas.NFe.SituacaoManifestacaoDestinatario.Ciencia:
                    {
                        return Schemas.NFe.CodigoEvento.Ciencia;
                    }

                case Schemas.NFe.SituacaoManifestacaoDestinatario.Confirmada:
                    {
                        return Schemas.NFe.CodigoEvento.Confirmacao;
                    }

                case Schemas.NFe.SituacaoManifestacaoDestinatario.Desconhecida:
                    {
                        return Schemas.NFe.CodigoEvento.Desconhecimento;
                    }

                case Schemas.NFe.SituacaoManifestacaoDestinatario.NaoRealizada:
                    {
                        return Schemas.NFe.CodigoEvento.NaoRealizada;
                    }

                case Schemas.NFe.SituacaoManifestacaoDestinatario.SemManifestacao:
                    {
                        return Schemas.NFe.CodigoEvento.Ciencia;
                    }

                default:
                    {
                        return Schemas.NFe.CodigoEvento.Ciencia;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}