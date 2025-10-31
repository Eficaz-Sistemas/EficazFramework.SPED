namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Carta de Correção Eletrônica
/// </summary>
public class ev110110 : DetalheEvento
{
    [XmlElement("xCorrecao")]
    public string? Correcao { get; set; }

    [XmlElement("xCondUso")]
    public string? CondicaoUso { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoEvento Versao { get; set; }


    public const string CondicaoUsoOpt1 = "A Carta de Correção é disciplinada pelo § 1º-A do art. 7º do Convênio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularização de erro ocorrido na emissão de documento fiscal, desde que o erro não esteja relacionado com: I - as variáveis que determinam o valor do imposto tais como: base de cálculo, alíquota, diferença de preço, quantidade, valor da operação ou da prestação; II - a correção de dados cadastrais que implique mudança do remetente ou do destinatário; III - a data de emissão ou de saída.";
    public const string CondicaoUsoOpt2 = "A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de emissao ou de saida.";
}
