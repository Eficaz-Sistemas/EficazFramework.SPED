namespace EficazFramework.SPED.Schemas.NFe;

[XmlInclude(typeof(ev110110))]
[XmlInclude(typeof(ev110111))]
[XmlInclude(typeof(ev112110))]
[XmlInclude(typeof(ev112120))]
[XmlInclude(typeof(ev112130))]
[XmlInclude(typeof(ev112140))]
[XmlInclude(typeof(ev112150))]
[XmlInclude(typeof(ev211110))]
[XmlInclude(typeof(ev211120))]
[XmlInclude(typeof(ev211124))]
[XmlInclude(typeof(ev211128))]
[XmlInclude(typeof(ev211130))]
[XmlInclude(typeof(ev211140))]
[XmlInclude(typeof(ev211150))]
[XmlInclude(typeof(ev212110))]
[XmlInclude(typeof(ev212120))]
[XmlInclude(typeof(ev412120))]
[XmlInclude(typeof(ev412130))]
[XmlInclude(typeof(DetalheEventoNaoMapeado))]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
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