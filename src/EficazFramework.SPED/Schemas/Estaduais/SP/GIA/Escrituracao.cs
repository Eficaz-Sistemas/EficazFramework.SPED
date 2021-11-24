using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFrameworkCore.SPED.Schemas.SP.GIA
{
    public class Escrituracao : Primitives.Escrituracao
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Escrituracao() : base("Arquivo Eletrônico GIA SP")
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
        public override void ProcessaLinha(string linha)
        {
            Primitives.Registro reg = null;
            switch (linha.Substring(0, 2) ?? "")
            {
                case "01":
                    {
                        Versao = linha.Substring(22, 4);
                        reg = new Registro01(linha, Versao);
                        break;
                    }

                case "05":
                    {
                        reg = new Registro05(linha, Versao);
                        break;
                    }

                case "07":
                    {
                        reg = new Registro07(linha, Versao);
                        var reg05 = Registros05.LastOrDefault();
                        if (reg05 != null)
                        {
                            reg05.Registros07.Add((Registro07)reg);
                        }

                        break;
                    }

                case "10":
                    {
                        reg = new Registro10(linha, Versao);
                        var reg05 = Registros05.LastOrDefault();
                        if (reg05 != null)
                        {
                            reg05.Registros10.Add((Registro10)reg);
                        }

                        break;
                    }

                case "14":
                    {
                        reg = new Registro14(linha, Versao);
                        var reg10 = Registros10.LastOrDefault();
                        if (reg10 != null)
                        {
                            reg10.Registros14.Add((Registro14)reg);
                        }

                        break;
                    }

                case "18":
                    {
                        reg = new Registro18(linha, Versao);
                        var reg14 = Registros14.LastOrDefault();
                        if (reg14 != null)
                        {
                            reg14.Registros18.Add((Registro18)reg);
                        }

                        break;
                    }

                case "20":
                    {
                        reg = new Registro20(linha, Versao);
                        var reg05 = Registros05.LastOrDefault();
                        if (reg05 != null)
                        {
                            reg05.Registros20.Add((Registro20)reg);
                        }

                        break;
                    }

                case "25":
                    {
                        reg = new Registro25(linha, Versao);
                        var reg20 = Registros20.LastOrDefault();
                        if (reg20 != null)
                        {
                            reg20.Registros25.Add((Registro25)reg);
                        }

                        break;
                    }

                case "26":
                    {
                        reg = new Registro26(linha, Versao);
                        var reg20 = Registros20.LastOrDefault();
                        if (reg20 != null)
                        {
                            reg20.Registros25.Add((Registro25)reg);
                        }

                        break;
                    }

                case "27":
                    {
                        reg = new Registro27(linha, Versao);
                        var reg20 = Registros20.LastOrDefault();
                        if (reg20 != null)
                        {
                            reg20.Registros25.Add((Registro25)reg);
                        }

                        break;
                    }

                case "28":
                    {
                        reg = new Registro28(linha, Versao);
                        var reg20 = Registros20.LastOrDefault();
                        if (reg20 != null)
                        {
                            reg20.Registros25.Add((Registro25)reg);
                        }

                        break;
                    }

                case "30":
                    {
                        reg = new Registro30(linha, Versao);
                        var reg05 = Registros05.LastOrDefault();
                        if (reg05 != null)
                        {
                            reg05.Registros30.Add((Registro30)reg);
                        }

                        break;
                    }

                case "31":
                    {
                        reg = new Registro31(linha, Versao);
                        var reg05 = Registros05.LastOrDefault();
                        if (reg05 != null)
                        {
                            reg05.Registros31.Add((Registro31)reg);
                        }

                        break;
                    }
            }

            if (reg != null)
                Blocos["U"].Registros.Add(reg);
            if (string.IsNullOrEmpty(linha) == false & string.IsNullOrWhiteSpace(linha) == false)
            {
                if (reg != null)
                    reg.LeParametros(linha.Split("#|#n/a#|#"));
            }
        }

        public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream)
        {
            string cnpj = string.Empty;
            using (var reader = new System.IO.StreamReader(stream, Encoding))
            {
                while (!reader.EndOfStream)
                {
                    string linha = await reader.ReadLineAsync();
                    if (linha.Substring(0, 2) == "05")
                    {
                        cnpj = cnpj + linha.Substring(0, 0) + "|";
                    }
                }

                reader.Dispose();
            }

            return cnpj;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Registro01 Registro01
        {
            get
            {
                return (Registro01)(from r in Blocos["U"].Registros
                                    where r.Codigo == "01"
                                    select r).FirstOrDefault();
            }
        }

        public IEnumerable<Registro05> Registros05
        {
            get
            {
                return (from r in Blocos["U"].Registros
                        where r.Codigo == "05"
                        select r).Cast<Registro05>();
            }
        }

        public IEnumerable<Registro07> Registros07
        {
            get
            {
                return (from r in Blocos["U"].Registros
                        where r.Codigo == "07"
                        select r).Cast<Registro07>();
            }
        }

        public IEnumerable<Registro10> Registros10
        {
            get
            {
                return (from r in Blocos["U"].Registros
                        where r.Codigo == "10"
                        select r).Cast<Registro10>();
            }
        }

        public IEnumerable<Registro14> Registros14
        {
            get
            {
                return (from r in Blocos["U"].Registros
                        where r.Codigo == "14"
                        select r).Cast<Registro14>();
            }
        }

        public IEnumerable<Registro20> Registros20
        {
            get
            {
                return (from r in Blocos["U"].Registros
                        where r.Codigo == "20"
                        select r).Cast<Registro20>();
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}