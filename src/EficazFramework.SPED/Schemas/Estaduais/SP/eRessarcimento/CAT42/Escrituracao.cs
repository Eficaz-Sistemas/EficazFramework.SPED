using System.Collections.Generic;
using System.Threading.Tasks;

namespace EficazFrameworkCore.SPED.Schemas.SP.eRessarcimento.CAT42
{
    public class Escrituracao : Primitives.Escrituracao
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Escrituracao() : base("Arquivo Eletrônico e-Ressarcimento CAT 42/18 (SP)")
        {
            Blocos.Add("U", new BlocoUnico());
            BlocoTotalizador = null; // "9"
            RegistroTotalizadorCodigo = null; // "9900"
            RegistroTotalizadorStringFormat = null; // Me.RegistroTotalizadorCodigo & "|{0}|{1}"
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override void ProcessaLinha(string linha)
        {
            //Primitives.Registro reg = null;

            // Select Case linha.Substring(1, 4)
            // Case "0000"
            // Me.Versao = linha.Substring(6, 3)
            // reg = New Registro0000(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)

            // Case "0001"
            // reg = New Registro0001(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0000.Registro0001 = reg

            // Case "0005"
            // reg = New Registro0005(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registro0005 = reg

            // Case "0015"
            // reg = New Registro0015(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0015.Add(reg)

            // Case "0100"
            // reg = New Registro0100(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registro0100 = reg

            // Case "0150"
            // reg = New Registro0150(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0150.Add(reg)

            // Case "0175"
            // reg = New Registro0175(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // Dim reg0150 As Registro0150 = DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0150.LastOrDefault
            // If reg0150 IsNot Nothing Then
            // reg0150.Registros0175.Add(reg)
            // End If

            // Case "0190"
            // reg = New Registro0190(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0190.Add(reg)

            // Case "0200"
            // reg = New Registro0200(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0200.Add(reg)

            // Case "0205"
            // reg = New Registro0205(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // Dim reg0200 As Registro0200 = DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0200.LastOrDefault
            // If reg0200 IsNot Nothing Then
            // reg0200.Registros0205.Add(reg)
            // End If

            // Case "0206"
            // reg = New Registro0206(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // Dim reg0200 As Registro0200 = DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0200.LastOrDefault
            // If reg0200 IsNot Nothing Then
            // reg0200.Registros0206 = reg
            // End If

            // Case "0220"
            // reg = New Registro0220(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // Dim reg0200 As Registro0200 = DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0200.LastOrDefault
            // If reg0200 IsNot Nothing Then
            // reg0200.Registros0220.Add(reg)
            // End If

            // Case "0300"
            // reg = New Registro0300(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0300.Add(reg)

            // Case "0305"
            // reg = New Registro0305(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // Dim reg0300 As Registro0300 = DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0300.LastOrDefault
            // If reg0300 IsNot Nothing Then
            // reg0300.Registro0305 = reg
            // End If

            // Case "0400"
            // reg = New Registro0400(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0400.Add(reg)

            // Case "0450"
            // reg = New Registro0450(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0450.Add(reg)

            // Case "0460"
            // reg = New Registro0460(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0460.Add(reg)

            // Case "0500"
            // reg = New Registro0500(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0500.Add(reg)

            // Case "0600"
            // reg = New Registro0600(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0001.Registros0600.Add(reg)

            // Case "0990"
            // reg = New Registro0990(linha, Me.Versao)
            // Me.Blocos("0").Registros.Add(reg)
            // DirectCast(Me.Blocos("0"), Bloco0).Registro0000.Registro0990 = reg

            // Case "C100"
            // reg = New RegistroC100(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)

            // Case "C101"
            // reg = New RegistroC101(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistroC101 = reg
            // End If

            // Case "C113"
            // reg = New RegistroC113(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC113.Add(reg)
            // End If

            // Case "C114"
            // reg = New RegistroC114(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC113.Add(reg)
            // End If

            // Case "C120"
            // reg = New RegistroC120(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC120.Add(reg)
            // End If

            // Case "C130"
            // reg = New RegistroC130(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistroC130 = reg
            // End If

            // Case "C140"
            // reg = New RegistroC140(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistroC140 = reg
            // End If

            // Case "C141"
            // reg = New RegistroC141(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC140 As RegistroC140 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC140.LastOrDefault
            // If regC140 IsNot Nothing Then
            // regC140.RegistrosC141.Add(reg)
            // End If

            // Case "C170"
            // reg = New RegistroC170(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC170.Add(reg)
            // End If

            // Case "C172"
            // reg = New RegistroC172(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC170 As RegistroC170 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC170.LastOrDefault
            // If regC170 IsNot Nothing Then
            // regC170.RegistroC172 = reg
            // End If

            // Case "C176"
            // reg = New RegistroC176(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC170 As RegistroC170 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC170.LastOrDefault
            // If regC170 IsNot Nothing Then
            // regC170.RegistrosC176.Add(reg)
            // End If

            // Case "C190"
            // reg = New RegistroC190(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC190.Add(reg)
            // End If

            // Case "C195"
            // reg = New RegistroC195(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC100 As RegistroC100 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC100.LastOrDefault
            // If regC100 IsNot Nothing Then
            // regC100.RegistrosC195.Add(reg)
            // End If

            // Case "C197"
            // reg = New RegistroC197(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC195 As RegistroC195 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC195.LastOrDefault
            // If regC195 IsNot Nothing Then
            // regC195.RegistrosC197.Add(reg)
            // End If

            // Case "C400"
            // reg = New RegistroC400(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)

            // Case "C405"
            // reg = New RegistroC405(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC400 As RegistroC400 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC400.LastOrDefault
            // If regC400 IsNot Nothing Then
            // regC400.RegistrosC405.Add(reg)
            // End If

            // Case "C490"
            // reg = New RegistroC490(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC405 As RegistroC405 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC405.LastOrDefault
            // If regC405 IsNot Nothing Then
            // regC405.RegistrosC490.Add(reg)
            // End If

            // Case "C500"
            // reg = New RegistroC500(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)

            // Case "C590"
            // reg = New RegistroC590(linha, Me.Versao)
            // Me.Blocos("C").Registros.Add(reg)
            // Dim regC500 As RegistroC500 = DirectCast(Me.Blocos("C"), BlocoC).RegistrosC500.LastOrDefault
            // If regC500 IsNot Nothing Then
            // regC500.RegistrosC590.Add(reg)
            // End If

            // Case "D100"
            // reg = New RegistroD100(linha, Me.Versao)
            // Me.Blocos("D").Registros.Add(reg)

            // Case "D110"
            // reg = New RegistroD110(linha, Me.Versao)
            // Me.Blocos("D").Registros.Add(reg)
            // Dim regD100 As RegistroD100 = DirectCast(Me.Blocos("D"), BlocoD).RegistrosD100.LastOrDefault
            // If regD100 IsNot Nothing Then
            // regD100.RegistrosD110.Add(reg)
            // End If

            // Case "D190"
            // reg = New RegistroD190(linha, Me.Versao)
            // Me.Blocos("D").Registros.Add(reg)
            // Dim regD100 As RegistroD100 = DirectCast(Me.Blocos("D"), BlocoD).RegistrosD100.LastOrDefault
            // If regD100 IsNot Nothing Then
            // regD100.RegistrosD190.Add(reg)
            // End If

            // Case "D500"
            // reg = New RegistroD500(linha, Me.Versao)
            // Me.Blocos("D").Registros.Add(reg)
            // 'DirectCast(Me.Blocos("D"), BlocoD).RegistrosD500.Add(reg)

            // Case "D590"
            // reg = New RegistroD590(linha, Me.Versao)
            // Me.Blocos("D").Registros.Add(reg)
            // Dim regD500 As RegistroD500 = DirectCast(Me.Blocos("D"), BlocoD).RegistrosD500.LastOrDefault
            // If regD500 IsNot Nothing Then regD500.RegistrosD590.Add(reg)

            // Case "E001"
            // reg = New RegistroE001(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)

            // Case "E100"
            // reg = New RegistroE100(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)

            // Case "E110"
            // reg = New RegistroE110(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE100 As RegistroE100 = DirectCast(Me.Blocos("E"), BlocoE).RegistroE100
            // If regE100 IsNot Nothing Then regE100.RegistroE110 = reg

            // Case "E111"
            // reg = New RegistroE111(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE110 As RegistroE110 = DirectCast(Me.Blocos("E"), BlocoE).RegistroE110
            // If regE110 IsNot Nothing Then regE110.RegistrosE111.Add(reg)

            // Case "E112"
            // reg = New RegistroE112(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE111 As RegistroE111 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE111.LastOrDefault
            // If regE111 IsNot Nothing Then regE111.RegistrosE112.Add(reg)

            // Case "E113"
            // reg = New RegistroE113(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE111 As RegistroE111 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE111.LastOrDefault
            // If regE111 IsNot Nothing Then regE111.RegistrosE113.Add(reg)

            // Case "E115"
            // reg = New RegistroE115(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE110 As RegistroE110 = DirectCast(Me.Blocos("E"), BlocoE).RegistroE110
            // If regE110 IsNot Nothing Then regE110.RegistrosE115.Add(reg)

            // Case "E116"
            // reg = New RegistroE116(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE110 As RegistroE110 = DirectCast(Me.Blocos("E"), BlocoE).RegistroE110
            // If regE110 IsNot Nothing Then regE110.RegistrosE116.Add(reg)

            // Case "E200"
            // reg = New RegistroE200(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)

            // Case "E210"
            // reg = New RegistroE210(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE200 As RegistroE200 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE200.LastOrDefault
            // If regE200 IsNot Nothing Then regE200.RegistroE210 = reg

            // Case "E220"
            // reg = New RegistroE220(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE210 As RegistroE210 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE210.LastOrDefault
            // If regE210 IsNot Nothing Then regE210.RegistrosE220.Add(reg)

            // Case "E230"
            // reg = New RegistroE230(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE220 As RegistroE220 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE220.LastOrDefault
            // If regE220 IsNot Nothing Then regE220.RegistrosE230.Add(reg)

            // Case "E240"
            // reg = New RegistroE240(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE220 As RegistroE220 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE220.LastOrDefault
            // If regE220 IsNot Nothing Then regE220.RegistrosE240.Add(reg)

            // Case "E250"
            // reg = New RegistroE250(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE210 As RegistroE210 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE210.LastOrDefault
            // If regE210 IsNot Nothing Then regE210.RegistrosE250.Add(reg)

            // Case "E300"
            // reg = New RegistroE300(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)

            // Case "E310"
            // reg = New RegistroE310(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE300 As RegistroE300 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE300.LastOrDefault
            // If regE300 IsNot Nothing Then regE300.RegistroE310 = reg

            // Case "E311"
            // reg = New RegistroE311(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE310 As RegistroE310 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE310.LastOrDefault
            // If regE310 IsNot Nothing Then regE310.RegistrosE311.Add(reg)

            // Case "E312"
            // reg = New RegistroE312(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE311 As RegistroE311 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE311.LastOrDefault
            // If regE311 IsNot Nothing Then regE311.RegistrosE312.Add(reg)

            // Case "E313"
            // reg = New RegistroE313(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE311 As RegistroE311 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE311.LastOrDefault
            // If regE311 IsNot Nothing Then regE311.RegistrosE313.Add(reg)

            // Case "E316"
            // reg = New RegistroE316(linha, Me.Versao)
            // Me.Blocos("E").Registros.Add(reg)
            // Dim regE310 As RegistroE310 = DirectCast(Me.Blocos("E"), BlocoE).RegistrosE310.LastOrDefault
            // If regE310 IsNot Nothing Then regE310.RegistrosE316.Add(reg)

            // Case "G001"
            // reg = New RegistroG001(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)

            // Case "G110"
            // reg = New RegistroG110(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)

            // Case "G125"
            // reg = New RegistroG125(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)
            // Dim regg110 As RegistroG110 = DirectCast(Me.Blocos("G"), BlocoG).RegistroG110
            // If regg110 IsNot Nothing Then regg110.RegistrosG125.Add(reg)

            // Case "G126"
            // reg = New RegistroG126(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)
            // Dim regg125 As RegistroG125 = DirectCast(Me.Blocos("G"), BlocoG).RegistrosG125.FirstOrDefault
            // If regg125 IsNot Nothing Then regg125.RegistrosG126.Add(reg)

            // Case "G130"
            // reg = New RegistroG130(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)
            // Dim regg125 As RegistroG125 = DirectCast(Me.Blocos("G"), BlocoG).RegistrosG125.FirstOrDefault
            // If regg125 IsNot Nothing Then regg125.RegistrosG130.Add(reg)

            // Case "G140"
            // reg = New RegistroG140(linha, Me.Versao)
            // Me.Blocos("G").Registros.Add(reg)
            // Dim regg130 As RegistroG130 = DirectCast(Me.Blocos("G"), BlocoG).RegistrosG130.FirstOrDefault
            // If regg130 IsNot Nothing Then regg130.RegistrosG140.Add(reg)

            // Case "H001"
            // reg = New RegistroH001(linha, Me.Versao)
            // Me.Blocos("H").Registros.Add(reg)

            // Case "H005"
            // reg = New RegistroH005(linha, Me.Versao)
            // Me.Blocos("H").Registros.Add(reg)

            // Case "H010"
            // reg = New RegistroH010(linha, Me.Versao)
            // Me.Blocos("H").Registros.Add(reg)

            // Case "H020"
            // reg = New RegistroH020(linha, Me.Versao)
            // Me.Blocos("H").Registros.Add(reg)
            // Dim regH010 As RegistroH010 = DirectCast(Me.Blocos("H"), BlocoH).RegistrosH010.LastOrDefault
            // If regH010 IsNot Nothing Then
            // regH010.RegistroH020 = reg
            // End If

            // Case "H990"
            // reg = New RegistroH990(linha, Me.Versao)
            // Me.Blocos("H").Registros.Add(reg)

            // Case "K001"
            // reg = New RegistroK001(linha, Me.Versao)
            // Me.Blocos("K").Registros.Add(reg)

            // Case "K230"
            // reg = New Registrok230(linha, Me.Versao)
            // Me.Blocos("K").Registros.Add(reg)

            // Case "K235"
            // reg = New RegistroK235(linha, Me.Versao)
            // Me.Blocos("K").Registros.Add(reg)
            // Dim reg230 As Registrok230 = DirectCast(Me.Blocos("K"), BlocoK).RegistrosK230.LastOrDefault
            // If reg230 IsNot Nothing Then
            // reg230.RegistrosK235.Add(reg)
            // End If

            // Case "K990"
            // reg = New RegistroK990(linha, Me.Versao)
            // Me.Blocos("K").Registros.Add(reg)

            // Case "9999"
            // _mustStop = True
            // End Select

            // If String.IsNullOrEmpty(linha) = False And String.IsNullOrWhiteSpace(linha) = False Then
            // If reg IsNot Nothing Then
            // reg.LeParametros(linha.Split("|"))
            // End If
            // End If

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
                    var reg0000 = new Registro0000(linha, Versao);
                    reg0000.LeParametros(linha.Split("|"));
                    cnpj = reg0000.CNPJ;
                    break;
                }

                reader.Dispose();
            }

            return cnpj;
        }

        public override Primitives.Registro[] PrefixoBlocoEncerramento()
        {
            var regs = new List<Primitives.Registro>();
            // Dim reg As New Registro9001
            // If Me.Blocos("5").Registros.Count <= 0 Then
            // reg.IndicadorMovimento = IndicadorMovimento.SemMovimento
            // Else
            // reg.IndicadorMovimento = IndicadorMovimento.ComMovimento
            // End If
            // regs.Add(reg)
            return regs.ToArray();
        }

        public override Primitives.Registro[] SufixoBlocoEncerramento()
        {
            var regs = new List<Primitives.Registro>();

            // Dim reg9900_9001 As New Registro9900
            // reg9900_9001.Registro = "9001"
            // reg9900_9001.TotalLinhas = 1
            // regs.Add(reg9900_9001)

            // Dim reg9900_9900 As New Registro9900
            // reg9900_9900.Registro = "9900"
            // reg9900_9900.TotalLinhas = (From reg In Me.Blocos(BlocoTotalizador).Registros Where TypeOf reg Is RegistroTotalizador).Count + 4
            // regs.Add(reg9900_9900)

            // Dim reg9900_9990 As New Registro9900
            // reg9900_9990.Registro = "9990"
            // reg9900_9990.TotalLinhas = 1
            // regs.Add(reg9900_9990)

            // Dim reg9900_9999 As New Registro9900
            // reg9900_9999.Registro = "9999"
            // reg9900_9999.TotalLinhas = 1
            // regs.Add(reg9900_9999)

            // Dim reg9990 As New Registro9990
            // reg9990.TotalLinhas = Me.Blocos("9").Registros.Count + 6
            // regs.Add(reg9990)

            // Dim reg9999 As New Registro9999
            // reg9999.TotalLinhas = (From bl In Me.Blocos.Values Select bl.Registros.Count).Sum + 6
            // regs.Add(reg9999)
            return regs.ToArray();
        }


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}