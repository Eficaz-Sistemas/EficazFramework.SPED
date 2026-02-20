using EficazFramework.SPED.Schemas.NFe;

namespace EficazFramework.SPED.Schemas.DFeBase;

public abstract class IbsCbsEventoBase : NFe.DetalheEvento
{
    public OrgaoIBGE cOrgaoAutor { get; set; }

    public string tpAutor { get; set; } = null!;

    public string verAplic { get; set; } = null!;
}
