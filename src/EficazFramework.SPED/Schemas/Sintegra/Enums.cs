
namespace EficazFramework.SPED.Schemas.Sintegra
{
    public enum CodigoIDArquivo
    {
        [System.ComponentModel.Description("Estrutura conforme Convênio ICMS 57/95 na versão do Convênio ICMS 31/99")]
        Convenio_31_99 = 1,
        [System.ComponentModel.Description("Estrutura conforme Convênio ICMS 57/95 na versão atual")]
        Convenio_57_95 = 2,
        [System.ComponentModel.Description("Estrutura conforme Convênio ICMS 57/95 na versão do Convênio ICMS 76/03 e 20/04")]
        Convenio_76_03_e_20_04 = 3
    }

    public enum NaturezaOperacoes
    {
        [System.ComponentModel.Description("Interestaduais somente operações sujeitas ao regime de Substituição Tributária")]
        InterestaduaisST = 1,
        [System.ComponentModel.Description("Interestaduais – operações com ou sem Substituição Tributária")]
        InterestaduaisSTCS = 2,
        [System.ComponentModel.Description("Totalidade das operações do informante")]
        Totalidade = 3
    }

    public enum FinalidadeApresentacao
    {
        [System.ComponentModel.Description("Normal")]
        Normal = 1,
        [System.ComponentModel.Description("Retificação total de arquivo: substituição total de informações prestadas pelo contribuinte referentes a este período")]
        RetificacaoTotal = 2,
        [System.ComponentModel.Description("Retificação aditiva de arquivo: acréscimo de informação não incluída em arquivos já apresentados")]
        RetificacaoAditiva = 3,
        [System.ComponentModel.Description("Desfazimento: arquivo de informação referente a operações/prestações não efetivadas . Neste caso, o arquivo deverá conter, além dos registros tipo 10 e tipo 90, apenas os registros referentes as operações/prestações não efetivadas")]
        Desfazimento = 5
    }
}