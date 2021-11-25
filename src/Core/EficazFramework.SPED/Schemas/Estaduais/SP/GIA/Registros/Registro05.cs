using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.SP.GIA;

/// <summary>
/// Cabeçalho do Documento Fiscal
/// </summary>
public class Registro05 : Primitives.Registro
{
    public Registro05() : base("05")
    {
    }

    public Registro05(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("05"); // 1 Código Registro
        writer.Append(InscricaoEstadual.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 3
        writer.Append(CNAE.ToFixedLenghtString(7, Escrituracao._builder, Alignment.Left, "0")); // 4
        writer.Append(((int)RegimeTributario).ToString().PadLeft(2, '0')); // 5
        writer.Append(Competencia.ToSintegraString(Extensions.DateFormat.AAAAMM)); // 6
        if (ReferenciaInicial.HasValue == true)
            writer.Append(ReferenciaInicial.ToSintegraString(Extensions.DateFormat.AAAAMM));
        else
            writer.Append("000000"); // 7
        writer.Append(((int)Tipo).ToString().PadLeft(2, '0')); // 8
        writer.Append(Convert.ToInt32(PossuiMovimeto)); // 9
        writer.Append(Convert.ToInt32(Transmitida)); // 10
        writer.Append(SaldoCredorAnterior.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 11
        writer.Append(SaldoCredorSTAnterior.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(OrigemSoftware.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Left, "0")); // 13
        writer.Append((int)OrigemGIA); // 14
        writer.Append(ICMS_Fixado.ValueToString().ToFixedLenghtString(15, Escrituracao._builder, Alignment.Left, "0")); // 15
        writer.Append(ChaveInterna.ToFixedLenghtString(32, Escrituracao._builder, Alignment.Right, "0")); // 16
                                                                                                          // TODO:Totais de 30 e 31 Filhos
        writer.Append(Registros07.Count.ToString().PadLeft(4, '0')); // 17
        writer.Append(Registros10.Count.ToString().PadLeft(4, '0')); // 18
        writer.Append(Registros20.Count.ToString().PadLeft(4, '0')); // 19
        writer.Append(Registros30.Count.ToString().PadLeft(4, '0')); // 20
        writer.Append(Registros31.Count.ToString().PadLeft(4, '0')); // 21
                                                                     // writer.Append(String.Format(Me.Registros31.Count, "{0:0000}")) '21
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        InscricaoEstadual = linha.Substring(2, 12).Trim();
        CNPJ = linha.Substring(14, 14).Trim();
        CNAE = linha.Substring(28, 7).Trim();
        RegimeTributario = (RegimeTributario)linha.Substring(35, 2).Trim().ToEnum<RegimeTributario>(RegimeTributario.RPA);
        Competencia = linha.Substring(37, 6).Trim().ToDate(Extensions.DateFormat.AAAAMM);
        if (linha.Substring(43, 6) != "000000" & !string.IsNullOrWhiteSpace(linha.Substring(43, 6)))
            ReferenciaInicial = linha.Substring(43, 6).Trim().ToDate(Extensions.DateFormat.AAAAMM);
        Tipo = (TipoGIA)linha.Substring(49, 2).Trim().ToEnum<TipoGIA>(TipoGIA.Normal);
        if (!string.IsNullOrWhiteSpace(linha.Substring(51, 1)))
            PossuiMovimeto = Convert.ToBoolean(Conversions.ToInteger(linha.Substring(51, 1)));
        if (!string.IsNullOrWhiteSpace(linha.Substring(52, 1)))
            Transmitida = Convert.ToBoolean(Conversions.ToInteger(linha.Substring(52, 1)));
        SaldoCredorAnterior = linha.Substring(53, 15).ToNullableDouble(2);
        SaldoCredorSTAnterior = linha.Substring(68, 15).ToNullableDouble(2);
        OrigemSoftware = linha.Substring(83, 14).Trim();
        OrigemGIA = (OrigemPreenchimento)linha.Substring(97, 1).Trim().ToEnum<OrigemPreenchimento>(OrigemPreenchimento.PreFormatadoERP);
        ICMS_Fixado = linha.Substring(98, 15).ToNullableDouble(2);
        ChaveInterna = linha.Substring(113, 32).Trim();
    }

    public string InscricaoEstadual { get; set; } = null;
    public string CNPJ { get; set; } = null;
    /// <summary>
    /// Deixar fixo "0000000"
    /// </summary>
    public string CNAE { get; set; } = "0000000";
    public RegimeTributario RegimeTributario { get; set; } = RegimeTributario.RPA;
    public DateTime? Competencia { get; set; } = default;
    /// <summary>
    /// - RefInicial >=200007
    /// - Se RegTrib = 01 (RPA) , RefInicial IGUAL 000000 (ZEROS)
    /// - Se RegTrib = 02 (RES),  RefInicial MAIOR OU IGUAL Competencia e deve pertencer ao mesmo semestre de Competencia
    /// - Se RegTrib = 03 (RPA-DISPENSADO), RefInicial IGUAL 000000 (ZEROS)
    /// - Se RegTrib = 04 (Simples-ST), RefInicial IGUAL 000000 (ZEROS)
    /// </summary>
    public DateTime? ReferenciaInicial { get; set; } = default;
    public TipoGIA Tipo { get; set; } = TipoGIA.Normal;
    public bool PossuiMovimeto { get; set; } = false;
    public bool Transmitida { get; set; } = false;
    public double? SaldoCredorAnterior { get; set; } = 0;
    /// <summary>
    /// Preencher com ZEROS se RegTrib = 04
    /// </summary>
    public double? SaldoCredorSTAnterior { get; set; } = 0;
    /// <summary>
    /// CNPJ ou CPF do desenvolvedor
    /// </summary>
    public string OrigemSoftware { get; set; } = null;
    public OrigemPreenchimento OrigemGIA { get; set; } = OrigemPreenchimento.PreFormatadoERP;
    /// <summary>
    /// - Se RegTrib = 02 Conteúdo > ZEROS
    /// - Se RegTrib = 01 ou 03 ou 04 , conteúdo = ZEROS
    /// </summary>
    /// <returns></returns>
    public double? ICMS_Fixado { get; set; } = 0;
    public string ChaveInterna { get; set; } = "00000000000000000000000000000000";
    public List<Registro07> Registros07 { get; set; } = new List<Registro07>();
    public List<Registro10> Registros10 { get; set; } = new List<Registro10>();
    public List<Registro20> Registros20 { get; set; } = new List<Registro20>();
    public List<Registro30> Registros30 { get; set; } = new List<Registro30>();
    public List<Registro31> Registros31 { get; set; } = new List<Registro31>();
}
