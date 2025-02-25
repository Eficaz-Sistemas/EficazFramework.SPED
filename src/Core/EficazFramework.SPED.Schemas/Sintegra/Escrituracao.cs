using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

public class Escrituracao : Primitives.Escrituracao
{


    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Escrituracao() : base("Arquivo Eletrônico do Sintegra")
    {
        HeaderPosition.Index = 0;
        HeaderPosition.Lenght = 2;
        Blocos.Add("U", new BlocoUnico());
        BlocoTotalizador = null;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    internal static System.Text.StringBuilder _builder = new System.Text.StringBuilder();

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public override void ProcessaLinha(string linha, CancellationToken cancelationToken = default)
    {
        Primitives.Registro reg = null;
        switch (linha[..2] ?? "")
        {
            case "10":
                {
                    // Me.Versao = linha.Substring(6, 3)
                    reg = new Registro10(linha, Versao);
                    break;
                }

            case "60":
                {
                    switch (linha.Substring(2, 1) ?? "")
                    {
                        case "M":
                            {
                                reg = new Registro60M(linha, Versao);
                                break;
                            }

                        case "A":
                            {
                                reg = new Registro60A(linha, Versao);
                                Registro60M lastM = (Registro60M)(from r in Blocos["U"].Registros
                                                                  where r.Codigo == "60M"
                                                                  select r).LastOrDefault();
                                if (lastM != null)
                                    lastM.Registros60A.Add((Registro60A)reg);
                                break;
                            }

                        case "D":
                            {
                                reg = new Registro60D(linha, Versao);
                                Registro60M lastM = (Registro60M)(from r in Blocos["U"].Registros
                                                                  where r.Codigo == "60M"
                                                                  select r).LastOrDefault();
                                if (lastM != null)
                                    lastM.Registros60D.Add((Registro60D)reg);
                                break;
                            }

                        case "I":
                            {
                                reg = new Registro60I(linha, Versao);
                                Registro60M lastM = (Registro60M)(from r in Blocos["U"].Registros
                                                                  where r.Codigo == "60M"
                                                                  select r).LastOrDefault();
                                if (lastM != null)
                                    lastM.Registros60I.Add((Registro60I)reg);
                                break;
                            }

                        case "R":
                            {
                                reg = new Registro60R(linha, Versao);
                                break;
                            }
                    }

                    break;
                }

            case "75":
                {
                    reg = new Registro75(linha, Versao);
                    break;
                }

            case "88":
                {
                    switch (linha.Substring(2, 3) ?? "")
                    {
                        case "EAN":
                            {
                                reg = new Registro88EAN(linha, Versao);
                                break;
                            }
                    }

                    break;
                }
        }

        if (reg != null)
            Blocos["U"].Registros.Add(reg);
        if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
        {
            if (reg != null)
            {
                reg.LeParametros(linha.Split("|"));
            }
        }
    }

    public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream, CancellationToken cancelationToken = default)
    {
        string cnpj = null;
        using (var reader = new System.IO.StreamReader(stream, Encoding))
        {
            while (!reader.EndOfStream)
            {
                string linha = await reader.ReadLineAsync();
                string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                var reg10 = new Registro10(linha, Versao);
                reg10.LeParametros(linha.Split("|"));
                cnpj = reg10.CNPJ;
                break;
            }

            reader.Dispose();
        }

        return cnpj;
    }

    public override async Task EncerraArquivo(System.IO.StreamWriter writer)
    {
        string declaranteCNPJ = "";
        string declaranteIE = "";
        var reg10 = Blocos["U"].Registros.Where(f => f.Codigo == "10").Cast<Registro10>().FirstOrDefault();
        if (reg10 != null)
        {
            declaranteCNPJ = reg10.CNPJ.ToFixedLenghtString(14, Alignment.Left, "0");
            declaranteIE = reg10.InscricaoEstadual.ToFixedLenghtString(14, Alignment.Right, " ");
        }

        var totais_dict = new Dictionary<string, long>();
        totais_dict.Add("50", Blocos["U"].Registros.Where(f => f.Codigo == "50").Count());
        totais_dict.Add("54", Blocos["U"].Registros.Where(f => f.Codigo == "54").Count());
        totais_dict.Add("60", Blocos["U"].Registros.Where(f => new[] { "60M", "60A", "60D" }.Contains(f.Codigo)).Count());
        totais_dict.Add("61", Blocos["U"].Registros.Where(f => f.Codigo == "61").Count());
        totais_dict.Add("70", Blocos["U"].Registros.Where(f => f.Codigo == "70").Count());
        totais_dict.Add("75", Blocos["U"].Registros.Where(f => f.Codigo == "75").Count());
        totais_dict.Add("88", Blocos["U"].Registros.Where(f => new[] { "88EAN" }.Contains(f.Codigo)).Count());
        var totais = new System.Text.StringBuilder();
        // totais.Append(String.Format("10{0}", 1.ToString.ToFixedLenghtString(8, Alignment.Left, "0")))
        if (totais_dict["50"] > 0L)
            totais.Append(string.Format("50{0}", totais_dict["50"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["54"] > 0L)
            totais.Append(string.Format("54{0}", totais_dict["54"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["60"] > 0L)
            totais.Append(string.Format("60{0}", totais_dict["60"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["61"] > 0L)
            totais.Append(string.Format("61{0}", totais_dict["61"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["70"] > 0L)
            totais.Append(string.Format("70{0}", totais_dict["70"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["75"] > 0L)
            totais.Append(string.Format("75{0}", totais_dict["75"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        if (totais_dict["88"] > 0L)
            totais.Append(string.Format("88{0}", totais_dict["88"].ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        totais.Append(string.Format("99{0}", (Blocos["U"].Registros.Count + 1).ToString().ToFixedLenghtString(8, Alignment.Left, "0")));
        await writer.WriteLineAsync(string.Format("90{0}{1}{2}1", declaranteCNPJ, declaranteIE, totais.ToString().ToFixedLenghtString(95, Alignment.Right, " ")));
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
