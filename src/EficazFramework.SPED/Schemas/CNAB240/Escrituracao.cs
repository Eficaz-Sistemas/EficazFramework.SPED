using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.CNAB240
{
    public class Escrituracao : Primitives.Escrituracao
    {


        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Escrituracao() : base("Arquivo Eletrônico CNAB240 padrão Febraban")
        {
            HeaderPosition.Index = 7;
            HeaderPosition.Lenght = 1;
            Blocos.Add("U", new BlocoUnico());
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        internal static System.Text.StringBuilder _builder = new System.Text.StringBuilder();

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private Registro3O last3O_Pai = null;

        public override void ProcessaLinha(string linha)
        {
            Primitives.Registro reg = null;
            switch (linha.Substring(7, 1) ?? "")
            {
                case "0":
                    {
                        // Me.Versao = linha.Substring(6, 3)
                        reg = new Registro0(linha, Versao);
                        break;
                    }

                case "1":
                    {
                        reg = new Registro1(linha, Versao);
                        break;
                    }

                case "3":
                    {
                        switch (linha.Substring(13, 1) ?? "")
                        {
                            case "O":
                                {
                                    reg = new Registro3O(linha, Versao);
                                    last3O_Pai = (Registro3O)reg;
                                    break;
                                }

                            case "N":
                                {
                                    switch (linha[..3] ?? "")
                                    {
                                        // Case "001"
                                        // reg = New Febraban.Registro3N(linha, Me.Versao)

                                        case "341":
                                            {
                                                reg = new Itau.Registro3N(linha, Versao);
                                                break;
                                            }

                                        default:
                                            {
                                                reg = new Febraban.Registro3N(linha, Versao);
                                                break;
                                            }
                                    }

                                    break;
                                }

                            case "W":
                                {
                                    reg = new Registro3W(linha, Versao);
                                    break;
                                }

                            case "Z":
                                {
                                    reg = new Registro3Z(linha, Versao);
                                    if (last3O_Pai != null && last3O_Pai.Detalhamento_Z is null)
                                        last3O_Pai.Detalhamento_Z = (Registro3Z)reg;
                                    break;
                                }
                        }

                        Registro1 last1 = (Registro1)(from r in Blocos["U"].Registros
                                                      where r.Codigo == "1"
                                                      select r).LastOrDefault();
                        if (last1 != null)
                            last1.Registros3.Add((Registro3)reg);
                        break;
                    }

                case "5":
                    {
                        break;
                    }
                    // Select Case linha.Substring(2, 3)
                    // Case "EAN"
                    // reg = New Registro88EAN(linha, Me.Versao)

                    // End Select

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

        public override async Task<string> LeEmpresaArquivo(System.IO.Stream stream)
        {
            string cnpj = null;
            using (var reader = new System.IO.StreamReader(stream, Encoding))
            {
                while (!reader.EndOfStream)
                {
                    string linha = await reader.ReadLineAsync();
                    string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                    var reg0 = new Registro0(linha, Versao);
                    reg0.LeParametros(linha.Split("|"));
                    cnpj = reg0.CNPJ;
                    break;
                }

                reader.Dispose();
            }

            return cnpj;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}