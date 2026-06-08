using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Services.NFSe.Nacional;

public record RetornoProcessamento(
    StatusProcessamentoEnum StatusProcessamento,
    List<LoteDFeItem> LoteDFe,
    List<MensagemProcessamento> Alertas,
    List<MensagemProcessamento> Erros,
    TipoAmbienteEnum TipoAmbiente,
    string VersaoAplicativo,
    DateTime DataHoraProcessamento
);

public record LoteDFeItem(
    int NSU,
    string ChaveAcesso,
    string TipoDocumento,
    string TipoEvento,
    string ArquivoXml,
    DateTime DataHoraGeracao
);

public record MensagemProcessamento(
    object Mensagem,
    List<string> Parametros,
    string Codigo,
    string Descricao,
    string Complemento
);

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum StatusProcessamentoEnum
{
    REJEICAO,
    NENHUM_DOCUMENTO_LOCALIZADO,
    DOCUMENTOS_LOCALIZADOS
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TipoAmbienteEnum
{
    PRODUCAO,
    HOMOLOGACAO
}
