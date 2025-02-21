using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFramework.SPED.Schemas.MG.DAPI;

public class Escrituracao : Primitives.Escrituracao
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Escrituracao() : base("Arquivo Eletrônico DAPI MG")
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

        // Select Case linha.Substring(0, 2)
        // Case "01"
        // Me.Versao = linha.Substring(22, 4)
        // reg = New Registro01(linha, Me.Versao)

        // Case "05"
        // reg = New Registro05(linha, Me.Versao)

        // Case "07"
        // reg = New Registro07(linha, Me.Versao)
        // Dim reg05 As Registro05 = Me.Registros05.LastOrDefault
        // If reg05 IsNot Nothing Then
        // reg05.Registros07.Add(reg)
        // End If

        // Case "10"
        // reg = New Registro10(linha, Me.Versao)
        // Dim reg05 As Registro05 = Me.Registros05.LastOrDefault
        // If reg05 IsNot Nothing Then
        // reg05.Registros10.Add(reg)
        // End If

        // Case "14"
        // reg = New Registro14(linha, Me.Versao)
        // Dim reg10 As Registro10 = Me.Registros10.LastOrDefault
        // If reg10 IsNot Nothing Then
        // reg10.Registros14.Add(reg)
        // End If

        // Case "18"
        // reg = New Registro18(linha, Me.Versao)
        // Dim reg14 As Registro14 = Me.Registros14.LastOrDefault
        // If reg14 IsNot Nothing Then
        // reg14.Registros18.Add(reg)
        // End If

        // Case "20"
        // reg = New Registro20(linha, Me.Versao)
        // Dim reg05 As Registro05 = Me.Registros05.LastOrDefault
        // If reg05 IsNot Nothing Then
        // reg05.Registros20.Add(reg)
        // End If

        // Case "25"
        // reg = New Registro25(linha, Me.Versao)
        // Dim reg20 As Registro20 = Me.Registros20.LastOrDefault
        // If reg20 IsNot Nothing Then
        // reg20.Registros25.Add(reg)
        // End If

        // Case "26"
        // reg = New Registro26(linha, Me.Versao)
        // Dim reg20 As Registro20 = Me.Registros20.LastOrDefault
        // If reg20 IsNot Nothing Then
        // reg20.Registros25.Add(reg)
        // End If

        // Case "27"
        // reg = New Registro27(linha, Me.Versao)
        // Dim reg20 As Registro20 = Me.Registros20.LastOrDefault
        // If reg20 IsNot Nothing Then
        // reg20.Registros25.Add(reg)
        // End If

        // Case "28"
        // reg = New Registro28(linha, Me.Versao)
        // Dim reg20 As Registro20 = Me.Registros20.LastOrDefault
        // If reg20 IsNot Nothing Then
        // reg20.Registros25.Add(reg)
        // End If

        // Case "30"
        // reg = New Registro30(linha, Me.Versao)
        // Dim reg05 As Registro05 = Me.Registros05.LastOrDefault
        // If reg05 IsNot Nothing Then
        // reg05.Registros30.Add(reg)
        // End If

        // Case "31"
        // reg = New Registro31(linha, Me.Versao)
        // Dim reg05 As Registro05 = Me.Registros05.LastOrDefault
        // If reg05 IsNot Nothing Then
        // reg05.Registros31.Add(reg)
        // End If

        // End Select
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
                if (linha[..2] == "00")
                {
                    cnpj = cnpj + linha[..0] + "|";
                }
            }

            reader.Dispose();
        }

        return cnpj;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public Registro00 Registro00
    {
        get
        {
            return (Registro00)(from r in Blocos["U"].Registros
                                where r.Codigo == "00"
                                select r).FirstOrDefault();
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}
