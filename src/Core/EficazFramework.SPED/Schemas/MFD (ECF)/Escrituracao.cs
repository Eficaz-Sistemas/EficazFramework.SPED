using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.MFD_ECF;

public class Escrituracao : Primitives.Escrituracao
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Escrituracao() : base("Arquivo MFD de Equipamento ECF")
    {
        HeaderPosition.Index = 0;
        HeaderPosition.Lenght = 3;
        Blocos.Add("U", new BlocoUnico());
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    internal static System.Text.StringBuilder _builder = new System.Text.StringBuilder();

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public override void ProcessaLinha(string linha)
    {
        Primitives.Registro reg = null;
        switch (linha[..3] ?? "")
        {
            case "E01":
                {
                    Versao = linha.Substring(151, 15);
                    reg = new RegistroE01(linha, Versao);
                    break;
                }

            case "E02":
                {
                    reg = new RegistroE02(linha, Versao);
                    break;
                }

            case "E12":
                {
                    reg = new RegistroE12(linha, Versao);
                    break;
                }

            case "E13":
                {
                    reg = new RegistroE13(linha, Versao);
                    ((BlocoUnico)Blocos.First().Value).RegistrosE12.LastOrDefault().RegistrosE13.Add((RegistroE13)reg);
                    break;
                }

            case "E14":
                {
                    reg = new RegistroE14(linha, Versao);
                    ((BlocoUnico)Blocos.First().Value).RegistrosE12.LastOrDefault().RegistrosE14.Add((RegistroE14)reg);
                    break;
                }

            case "E15":
                {
                    reg = new RegistroE15(linha, Versao);
                    ((BlocoUnico)Blocos.First().Value).RegistrosE12.LastOrDefault().RegistrosE15.Add((RegistroE15)reg);
                    break;
                }

            case "E18":
                {
                    reg = new RegistroE18(linha, Versao);
                    ((BlocoUnico)Blocos.First().Value).RegistrosE12.LastOrDefault().RegistrosE18.Add((RegistroE18)reg);
                    break;
                }
        }

        if (reg != null)
        {
            Blocos["U"].Registros.Add(reg);
        }

        if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
        {
            if (reg != null)
            {
                reg.LeParametros(linha.Split("|"));

                // vinculando E15 aos E14 pais:
                if (reg is RegistroE15 e)
                {
                    var it14 = (from i14 in ((BlocoUnico)Blocos.First().Value).RegistrosE14
                                where i14.COO == e.COO
                                select i14).FirstOrDefault();
                    if (it14 != null)
                    {
                        it14.RegistrosE15.Add(e);
                    }
                }
            }
        }
    }

    public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream)
    {
        string cnpj = null;
        using (var reader = new System.IO.StreamReader(stream, Encoding))
        {
            while (!reader.EndOfStream)
            {
                string linha = await reader.ReadLineAsync();
                string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                var e01 = new RegistroE01(linha, Versao);
                e01.LeParametros(linha.Split("|"));
                cnpj = e01.CNPJ;
                break;
            }

            reader.Dispose();
        }

        return cnpj;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
