// NOTA: Este registro nunca sofreu alteração desde o primeiro ano da escrituração.
// Não será preciso avaliar qual é a versão do arquivo para diferenciar a forma
// de escrita/leitura.

using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Obrigatoriedade dos Registros do Bloco 1
    /// </summary>
    /// <remarks></remarks>
    public class Registro1010 : Primitives.Registro
    {
        public Registro1010() : base("1010")
        {
        }

        public Registro1010(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1010|"); // 1
            if (AverbacaoExportacao == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 2
            if (CreditoICMSControladoSefaz == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 3
            if (ComCombustiveisPeriodo == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 4
            if (UsinaAcucarAlcoolPeriodo == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 5
            if (ValoresUF == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 6
            if (DistrEnergiaOutraUF == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 7
            if (VendasCartao == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 8
            if (EmissaoDocFiscalPapel == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 9
            if (TransAereo == true)
                writer.Append("S|");
            else
                writer.Append("N|"); // 10
            if (Conversions.ToInteger(Versao) >= 13)
            {
                if (GIAF1 == true)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 11
                if (GIAF3 == true)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 12
                if (GIAF4 == true)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 13
            }

            if (Conversions.ToInteger(Versao) >= 14)
            {
                if (RessarcimentoOuComplementoICMS == true)
                    writer.Append("S|");
                else
                    writer.Append("N|"); // 11
            }

            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            if (data[2] == "S")
                AverbacaoExportacao = true;
            if (data[3] == "S")
                CreditoICMSControladoSefaz = true;
            if (data[4] == "S")
                ComCombustiveisPeriodo = true;
            if (data[5] == "S")
                UsinaAcucarAlcoolPeriodo = true;
            if (data[6] == "S")
                ValoresUF = true;
            if (data[7] == "S")
                DistrEnergiaOutraUF = true;
            if (data[8] == "S")
                VendasCartao = true;
            if (data[9] == "S")
                EmissaoDocFiscalPapel = true;
            if (data[10] == "S")
                TransAereo = true;
            if (Conversions.ToInteger(Versao) >= 13)
            {
                if (data[11] == "S")
                    GIAF1 = true;
                if (data[12] == "S")
                    GIAF3 = true;
                if (data[13] == "S")
                    GIAF4 = true;
            }

            if (Conversions.ToInteger(Versao) >= 14)
            {
                if (data[14] == "S")
                    RessarcimentoOuComplementoICMS = true;
            }
        }

        /// <summary>
        /// Ocorreu averbação (conclusão) de exportação no período?
        /// </summary>
        public bool AverbacaoExportacao { get; set; } = false;
        /// <summary>
        /// Existem informações acerca de créditos de ICMS a serem controlados, definidos pela Sefaz?
        /// </summary>
        public bool CreditoICMSControladoSefaz { get; set; } = false;
        /// <summary>
        /// É comercio varejista de combustíveis com movimentação e/ou estoque no período?
        /// </summary>
        public bool ComCombustiveisPeriodo { get; set; } = false;
        /// <summary>
        /// Usinas de açúcar e/álcool – O estabelecimento é produtor de açúcar e/ou álcool carburante com movimentação e/ou estoque no período?
        /// </summary>
        public bool UsinaAcucarAlcoolPeriodo { get; set; } = false;
        /// <summary>
        /// Sendo o registro obrigatório em sua Unidade de Federação, existem informações a serem prestadas neste registro?
        /// </summary>
        public bool ValoresUF { get; set; } = false;
        /// <summary>
        /// A empresa é distribuidora de energia e ocorreu fornecimento de energia elétrica para consumidores de outra UF?
        /// </summary>
        public bool DistrEnergiaOutraUF { get; set; } = false;
        /// <summary>
        /// Realizou vendas com Cartão de Crédito ou de débito?
        /// </summary>
        public bool VendasCartao { get; set; } = false;
        /// <summary>
        /// Foram emitidos documentos fiscais em papel no período  em unidade da federação que exija o controle de utilização de documentos fiscais?
        /// </summary>
        public bool EmissaoDocFiscalPapel { get; set; } = false;
        /// <summary>
        /// A empresa prestou serviços de transporte aéreo de cargas e de passageiros?
        /// </summary>
        public bool TransAereo { get; set; } = false;
        /// <summary>
        /// Reg. 1960 - Possui informações GIAF1?
        /// </summary>
        public bool GIAF1 { get; set; } = false;
        /// <summary>
        /// Reg. 1970 - Possui informações GIAF3?
        /// </summary>
        public bool GIAF3 { get; set; } = false;
        /// <summary>
        /// Reg. 1980 - Possui informações GIAF4?
        /// </summary>
        public bool GIAF4 { get; set; } = false;
        /// <summary>
        /// Possui informações consolidadas de saldos de restituição, ressarcimento e complementação do ICMS?
        /// </summary>
        /// <returns></returns>
        public bool RessarcimentoOuComplementoICMS { get; set; } = false;
    }
}