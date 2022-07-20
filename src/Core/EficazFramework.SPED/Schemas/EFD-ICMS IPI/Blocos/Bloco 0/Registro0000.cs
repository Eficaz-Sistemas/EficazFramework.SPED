// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.Primitives;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Abertura do Arquivo Digital e Identificação da entidade
/// </summary>
/// <remarks>
/// Nível hierárquico - 0 <br/>
/// Ocorrência - um por arquivo.
/// </remarks>
public class Registro0000 : Registro
{
    /// <exclude />
    public Registro0000() : base("0000")
    {
    }

    /// <exclude />
    public Registro0000(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {

        // Em caso de mudança de layout neste registro em futuras versões da EFD,
        // Usar o exemplo abaixo para cada versão ou grupo de versões que possuam a
        // mesma estrutura:

        // Select Case Me.Versao
        // Case "001"

        // Case "002"

        // End Select

        var writer = new System.Text.StringBuilder();
        writer.Append("|0000|"); // 1
        writer.Append(Versao + "|"); // 2
        writer.Append(((int)Finalidade).ToString() + "|"); // 3
        writer.Append(DataInicial.ToSpedString() + "|"); // 4
        writer.Append(DataFinal.ToSpedString() + "|"); // 5
        writer.Append(RazaoSocial + "|"); // 6
        writer.Append(CNPJ + "|"); // 7
        writer.Append(CPF + "|"); // 8
        writer.Append(UF + "|"); // 9
        writer.Append(InscricaoEstadual + "|"); // 10
        writer.Append(MunicipioCodigo + "|"); // 11
        writer.Append(InscricaoMunicipal + "|"); // 12
        writer.Append(InscricaoSuframa + "|"); // 13
        writer.Append(Perfil.ToString() + "|"); // 14
        writer.Append(((int)Atividade).ToString() + "|"); // 15
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {

        // Em caso de mudança de layout neste registro em futuras versões da EFD,
        // Usar o exemplo abaixo para cada versão ou grupo de versões que possuam a
        // mesma estrutura:

        // Select Case Me.Versao
        // Case "001"

        // Case "002"

        // End Select

        Finalidade = (Finalidade)data[3].ToEnum<Finalidade>(Finalidade.Original); // CType(CInt(data(3)), Finalidade)
        DataInicial = data[4].ToDate();
        DataFinal = data[5].ToDate();
        RazaoSocial = data[6];
        CNPJ = data[7];
        CPF = data[8];
        UF = data[9];
        InscricaoEstadual = data[10];
        MunicipioCodigo = data[11];
        InscricaoMunicipal = data[12];
        InscricaoSuframa = data[13];
        switch (data[14] ?? "")
        {
            case "A":
                {
                    Perfil = Perfil.A;
                    break;
                }

            case "B":
                {
                    Perfil = Perfil.B;
                    break;
                }

            case "C":
                {
                    Perfil = Perfil.C;
                    break;
                }
        }

        Atividade = (TipoAtividade)data[15].ToEnum<TipoAtividade>(TipoAtividade.Outros); // CType(CInt(data(15)), TipoAtividade)
    }

    /// <summary>
    /// Código da finalidade do arquivo: <br/>
    /// 0 - Remessa do arquivo original <br/>
    /// 1 - Remessa do arquivo substituto <br/>
    /// </summary>
    public Finalidade Finalidade { get; set; } = Finalidade.Original;
    /// <summary>
    /// Data inicial das informações contidas no arquivo
    /// </summary>
    public DateTime? DataInicial { get; set; } = default;
    /// <summary>
    /// Data final das informações contidas no arquivo
    /// </summary>
    public DateTime? DataFinal { get; set; } = default;
    /// <summary>
    /// Nome empresarial da entidade
    /// </summary>
    public string RazaoSocial { get; set; } = null;
    /// <summary>
    /// Número de inscrição da entidade no CNPJ
    /// </summary>
    public string CNPJ { get; set; } = null;
    /// <summary>
    /// Número de inscrição da entidade no CPF
    /// </summary>
    public string CPF { get; set; } = null;
    /// <summary>
    /// Sigla da unidade da federação da entidade
    /// </summary>
    public string UF { get; set; } = null;
    /// <summary>
    /// Inscrição Estadual da entidade
    /// </summary>
    public string InscricaoEstadual { get; set; } = null;
    /// <summary>
    /// Código do município do domicílio fiscal da entidade, conforme a tabela IBGE
    /// </summary>
    public string MunicipioCodigo { get; set; } = null;
    /// <summary>
    /// Inscrição Municipal da entidade
    /// </summary>
    public string InscricaoMunicipal { get; set; } = null;
    /// <summary>
    /// Inscrição da entidade no Suframa
    /// </summary>
    public string InscricaoSuframa { get; set; } = null;
    /// <summary>
    /// Perfil de apresentação do arquivo fiscal:  <br/>
    /// A – Perfil A <br/>
    /// B – Perfil B <br/>
    /// C – Perfil C <br/>
    /// </summary>
    public Perfil Perfil { get; set; } = Perfil.A;
    /// <summary>
    /// Indicador de tipo de atividade: <br/>
    /// 0 – Industrial ou equiparado a industrial  <br/>
    /// 1 – Outros  <br/>
    /// </summary>
    public TipoAtividade Atividade { get; set; } = TipoAtividade.Outros;


    // Private Shared Sub ValidaIE()

    // End Sub


    // Registros Filhos

    public Registro0001 Registro0001 { get; set; } = null;
    public Registro0990 Registro0990 { get; set; } = null;
}
