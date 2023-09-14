using FluentAssertions;

namespace EficazFramework.SPED.Services.EFD_Reinf;

public class R1000Test : CadastrosEfdReinfTest<Schemas.EFD_Reinf.R1000>
{
    private int _testNumber = 0;

    //[Test]
    //[TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task Envia01Inclusao(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 0;
        _versao = versao;
        _ = await TestaEvento(versao);
    }


    //[Test]
    //[TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task Envia02Alteracao(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 1;
        _versao = versao;
        _ = await TestaEvento(versao);
    }


    //[Test]
    //[TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task Envia03Exclusao(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 2;
        _versao = versao;
        _ = await TestaEvento(versao);
    }


    //[Test]
    //[TestCase(Schemas.EFD_Reinf.Versao.v2_01_02)]
    public async Task Envia04InclusaoRemocaoDados(Schemas.EFD_Reinf.Versao versao)
    {
        _testNumber = 3;
        _versao = versao;
        _ = await TestaEvento(versao);
    }



    // BaseEfdReinfTest overrides
    public override void PreencheCampos(Schemas.EFD_Reinf.R1000 evento, int i)
    {
        evento.Versao = _versao;
        switch (_testNumber)
        {
            case 0:
                Schemas.EFD_Reinf.R1000Test.PreencheCamposInclusao(evento);
                break;
            case 1:
                Schemas.EFD_Reinf.R1000Test.PreencheCamposAlteracao(evento);
                break;
            case 2:
                Schemas.EFD_Reinf.R1000Test.PreencheCamposExclusao(evento);
                break;
            case 3:
                Schemas.EFD_Reinf.R1000Test.PreencheCamposInclusao(evento);
                evento.evtInfoContri.ideEvento.verProc = "RemoverContribuinte";
                ((Schemas.EFD_Reinf.R1000Inclusao)evento.evtInfoContri.infoContri.Item).infoCadastro.classTrib = "00";
                break;
        }
    }

}