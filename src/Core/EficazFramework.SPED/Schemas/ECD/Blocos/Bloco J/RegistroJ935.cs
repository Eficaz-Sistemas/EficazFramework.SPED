using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Identificação dos Auditores Independentes
/// </summary>
/// <remarks></remarks>

public class RegistroJ935 : Primitives.Registro
{
    public RegistroJ935() : base("J935")
    {
    }

    // Campos'
    public string CNPJCPFAuditor { get; set; } = null;
    public string NomeAuditor { get; set; } = null;
    public string RegistroAuditorCVM { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|J935|");
        if (Conversions.ToInteger(Versao) / 100d >= 7d)
        {
            writer.Append(CNPJCPFAuditor + "|");
        }

        writer.Append(NomeAuditor + "|");
        writer.Append(RegistroAuditorCVM + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        if (Conversions.ToInteger(Versao) / 100d >= 7d)
        {
            CNPJCPFAuditor = data[2];
            NomeAuditor = data[3];
            RegistroAuditorCVM = data[4];
        }
        else
        {
            NomeAuditor = data[2];
            RegistroAuditorCVM = data[3];
        }
    }
}
