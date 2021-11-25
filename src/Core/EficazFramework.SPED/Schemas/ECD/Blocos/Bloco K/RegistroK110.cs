using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD;

/// <summary>
/// Relação dos Eventos Societários
/// </summary>
/// <remarks></remarks>

public class RegistroK110 : Primitives.Registro
{
    public RegistroK110() : base("K110")
    {
    }

    public RegistroK110(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public EventoSocietario EventoSocietario { get; set; } = EventoSocietario.Alienacao;
    public DateTime? DataEventoSocietario { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|K110|");
        writer.Append(((int)EventoSocietario).ToString() + "|");
        writer.Append(DataEventoSocietario + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        EventoSocietario = (EventoSocietario)data[2].ToEnum<EventoSocietario>(EventoSocietario.Alienacao);
        DataEventoSocietario = data[3].ToDate();
    }
}
