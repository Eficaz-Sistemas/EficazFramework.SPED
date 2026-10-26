using EficazFramework.SPED.Schemas.eSocial;

namespace EficazFramework.SPED.Services.eSocial;

public class GrupoLoteEventosTests
{
    [Test]
    public void DefineGrupo_EventosDeTabela_Grupo1()
    {
        ESocialServices.DefineGrupo(new S1000()).Should().Be(1);
    }

    [Test]
    public void DefineGrupo_EventosPeriodicos_Grupo3()
    {
        ESocialServices.DefineGrupo(new S1200()).Should().Be(3);
    }

    [Test]
    public void DefineGrupo_EventosNaoPeriodicos_Grupo2()
    {
        ESocialServices.DefineGrupo(new S2306()).Should().Be(2);
        ESocialServices.DefineGrupo(new S2298()).Should().Be(2);
        ESocialServices.DefineGrupo(new S2299()).Should().Be(2);
        ESocialServices.DefineGrupo(new S2399()).Should().Be(2);
    }
}
