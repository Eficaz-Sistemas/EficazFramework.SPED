using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MFD_ECF;

/// <summary>
/// Relação de Reduções Z
/// </summary>
/// <remarks></remarks>
public class RegistroE12 : Primitives.Registro
{
    public RegistroE12(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("E12"); // 1
        writer.Append(NumeroFabricacaoECF.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append(MFAdicional.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 3
        writer.Append(Modelo.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(NumeroUsuario.ValueToString().ToFixedLenghtString(2, Escrituracao._builder, Alignment.Left, "0")); // 5
        writer.Append(CRZ.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(COO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 7
        writer.Append(CRO.ValueToString().ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 8
        writer.Append(DataMovimento.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 9
        writer.Append(DataEmissao.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 10
        writer.Append("000000"); // 11
        writer.Append(VendaBrutaDiaria.ValueToString(2).ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 12
        if (IncidenciaDesconto == true == true)
            writer.Append('S');
        else
            writer.Append('N'); // 13
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        NumeroFabricacaoECF = linha.Substring(3, 20).Trim();
        MFAdicional = linha.Substring(23, 1).Trim();
        Modelo = linha.Substring(24, 20).Trim();
        NumeroUsuario = linha.Substring(44, 2).ToNullableInteger();
        CRZ = linha.Substring(46, 6).ToNullableInteger();
        COO = linha.Substring(52, 6).ToNullableInteger();
        CRO = linha.Substring(58, 6).Trim().ToNullableInteger();
        DataMovimento = linha.Substring(64, 8).ToDate(Extensions.DateFormat.AAAAMMDD);
        DataEmissao = linha.Substring(72, 8).Trim().ToDate(Extensions.DateFormat.AAAAMMDD);
        // Me.HoraEmissao = Nothing
        VendaBrutaDiaria = linha.Substring(86, 14).Trim().ToNullableDouble(2);
        string desc = linha.Substring(100, 1);
        if (desc == "S")
            IncidenciaDesconto = true;
        else
            IncidenciaDesconto = false;
    }

    public string NumeroFabricacaoECF { get; set; } // campo 2
    public string MFAdicional { get; set; } // 3
    public string Modelo { get; set; } // 4
    public int? NumeroUsuario { get; set; } // 5
    public int? CRZ { get; set; } // 6 Contador de Reduçao Z
    public int? COO { get; set; } // 7 Contador de Ordem de Operação
    public int? CRO { get; set; } // 8 Contador Reinício de Operações
    public DateTime? DataMovimento { get; set; } // 9
    public DateTime? DataEmissao { get; set; } // 10
    public TimeSpan? HoraEmissao { get; set; } // 11 # IGNORAR #
    public double? VendaBrutaDiaria { get; set; } // 12
    public bool? IncidenciaDesconto { get; set; } // 13

    // // Navigation Properties
    public List<RegistroE13> RegistrosE13 { get; set; } = new List<RegistroE13>();
    public List<RegistroE14> RegistrosE14 { get; set; } = new List<RegistroE14>();
    public List<RegistroE15> RegistrosE15 { get; set; } = new List<RegistroE15>();
    public List<RegistroE18> RegistrosE18 { get; set; } = new List<RegistroE18>();
}
