namespace EficazFramework.SPED.Schemas.NFe;

public abstract class DetalheEvento
{
    [XmlElement("descEvento")]
    public string? Descricao { get; set; }


    [XmlAttribute("versao")]
    public Schemas.NFe.VersaoServicoEvento Versao { get; set; } = VersaoServicoEvento.Versao_1_00;
}

public class DetalheEventoNaoMapeado : DetalheEvento
{
    [XmlElement("descEvento")]
    public string? EventoDescricao { get; set; }

}