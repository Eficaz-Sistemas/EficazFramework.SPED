using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Identificação do relacionamento com o Participante
    /// </summary>
    /// <remarks></remarks>

    public class Registro0180 : Primitives.Registro
    {
        public Registro0180() : base("0180")
        {
        }

        public Registro0180(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodRelacionamentoTabelaSped { get; set; } = null;
        public DateTime DataInicioRelacionamento { get; set; }
        public DateTime DataTerminoRelacionamento { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0180|");
            writer.Append(CodRelacionamentoTabelaSped + "|");
            writer.Append(DataInicioRelacionamento + "|");
            writer.Append(DataTerminoRelacionamento + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodRelacionamentoTabelaSped = data[2];
            DataInicioRelacionamento = (DateTime)data[3].ToDate();
            DataTerminoRelacionamento = (DateTime)data[4].ToDate();
        }
    }
}