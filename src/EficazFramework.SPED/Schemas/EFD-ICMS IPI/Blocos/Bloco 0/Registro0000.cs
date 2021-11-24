// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using System;
using EficazFrameworkCore.SPED.Extensions;
using EficazFrameworkCore.SPED.Schemas.Primitives;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Abertura do Arquivo Digital e Identificação da entidade
    /// </summary>
    /// <remarks></remarks>
    public class Registro0000 : Registro
    {
        public Registro0000() : base("0000")
        {
        }

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

        public Finalidade Finalidade { get; set; } = Finalidade.Original;
        public DateTime? DataInicial { get; set; } = default;
        public DateTime? DataFinal { get; set; } = default;
        public string RazaoSocial { get; set; } = null;
        public string CNPJ { get; set; } = null;
        public string CPF { get; set; } = null;
        public string UF { get; set; } = null;

        // <CustomValidation(GetType(Registro0000()), "ValidaIE")>
        public string InscricaoEstadual { get; set; } = null;
        public string MunicipioCodigo { get; set; } = null;
        public string InscricaoMunicipal { get; set; } = null;
        public string InscricaoSuframa { get; set; } = null;
        public Perfil Perfil { get; set; } = Perfil.A;
        public TipoAtividade Atividade { get; set; } = TipoAtividade.Outros;


        // Private Shared Sub ValidaIE()

        // End Sub


        // Registros Filhos

        public Registro0001 Registro0001 { get; set; } = null;
        public Registro0990 Registro0990 { get; set; } = null;
    }
}