using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Alteração da Tabela de Cadastro do Participante
    /// </summary>
    /// <remarks></remarks>
    public class Registro0175 : Primitives.Registro
    {
        public Registro0175() : base("0175")
        {
        }

        public Registro0175(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0175|"); // 1
            writer.Append(DataAlteracao.ToSpedString() + "|"); // 2
            writer.Append(string.Format("{0:00}", (int)CampoAlterado) + "|"); // 3
            writer.Append(ConteudoAnterior + "|"); // 4
            writer.Append(IDAnterior + "|"); // 5
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            DataAlteracao = data[2].ToDate();
            CampoAlterado = (CampoAlterado)Conversions.ToInteger(Conversions.ToInteger(data[3]));
            ConteudoAnterior = data[4];
            IDAnterior = data[5];
        }

        public DateTime? DataAlteracao { get; set; } = default;
        public CampoAlterado CampoAlterado { get; set; } = CampoAlterado.Nome;
        public string ConteudoAnterior { get; set; } = null;
        /// <summary>
        /// Válido apenas à partir da versao 003 (2010)
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public string IDAnterior { get; set; } = null;
    }
}