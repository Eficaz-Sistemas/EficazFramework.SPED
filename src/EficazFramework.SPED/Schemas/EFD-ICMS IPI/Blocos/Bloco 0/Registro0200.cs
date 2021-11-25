using System;
using System.Collections.Generic;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Tabela de Identificação do Item (Produtos e Serviços)
    /// </summary>
    /// <remarks></remarks>
    public class Registro0200 : Primitives.Registro
    {
        public Registro0200() : base("0200")
        {
        }

        public Registro0200(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0200|"); // 1
            writer.Append(ID + "|"); // 2
            writer.Append(Descricao.RemoveAccents() + "|"); // 3
            writer.Append(CodigoBarras + "|"); // 4
            writer.Append(IDAnterior + "|"); // 5
            writer.Append(UnidadeMedida + "|"); // 6
            writer.Append(string.Format("{0:00}", (int)TipoItem) + "|"); // 7
            writer.Append(NCM + "|"); // 8
            writer.Append(EX_IPI + "|"); // 9
            writer.Append(string.Format("{0:00}", Genero) + "|"); // 10
            writer.Append(string.Format("{0:0000}", ID_Servico) + "|"); // 11
            writer.Append(string.Format("{0:0.00}", AliquotaICMS) + "|"); // 12
            if (Conversions.ToInteger(Versao) >= 11)
                writer.Append(CEST + "|"); // 13
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            ID = data[2];
            Descricao = data[3];
            CodigoBarras = data[4];
            IDAnterior = data[5];
            UnidadeMedida = data[6];
            TipoItem = (TipoItem)data[7].ToEnum<TipoItem>(TipoItem.MercadoriaRevenda);
            NCM = data[8];
            EX_IPI = data[9];
            if (data[10].IsNumeric())
            {
                Genero = data[10].ToNullableLong();
            }

            ID_Servico = data[11].ToNullableLong();
            AliquotaICMS = data[12].ToNullableDouble();
        }

        public string ID { get; set; } = null;
        public string Descricao { get; set; } = null;
        public string CodigoBarras { get; set; } = null;
        public string IDAnterior { get; set; } = null;
        public string UnidadeMedida { get; set; } = null;
        public TipoItem TipoItem { get; set; } = TipoItem.MercadoriaRevenda;
        public string NCM { get; set; } = null;
        public string EX_IPI { get; set; } = null;
        public long? Genero { get; set; } = default;
        public long? ID_Servico { get; set; } = default;
        public double? AliquotaICMS { get; set; } = default;
        public string CEST { get; set; } = null;

        // Registros Filhos
        public List<Registro0205> Registros0205 { get; set; } = new List<Registro0205>();
        public Registro0206 Registros0206 { get; set; }
        public List<Registro0220> Registros0220 { get; set; } = new List<Registro0220>();
    }
}