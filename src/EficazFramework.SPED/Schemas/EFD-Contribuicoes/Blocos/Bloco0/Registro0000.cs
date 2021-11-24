using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.EFD_Contribuicoes
{

    /// <summary>
    /// Abertura do Arquivo Digital e Identificação da entidade
    /// </summary>
    /// <remarks></remarks>
    public class Registro0000 : Primitives.Registro
    {
        public Registro0000() : base("0000")
        {
        }

        public Registro0000(string linha, string versao) : base(linha, versao)
        {
        }
        // Campos
        public TipoEscritur TipoEscrit { get; set; } = TipoEscritur.Original;
        public SituacaoEspecial SituacaoEspecial { get; set; } = SituacaoEspecial.Vazio;
        public string NumeroReciboAnterior { get; set; } = null; // tamanho 41'
        public DateTime? DataInicial { get; set; } // ddMMaaaa'
        public DateTime? DataFinal { get; set; } // ddMMaaaa'
        public string NomeEmpresarial { get; set; } = null; // tamanho 100'
        public string NumeroCnpj { get; set; } = null; // tamanho 14'
        public string UF { get; set; } = null; // tamanho 2'
        public string CodigoMunicipio { get; set; } = null; // tamanho 7 conforme tabela do IBGE'
        public string Suframa { get; set; } = null; // tamanho 9'
        public IndicadorNaturezaPJ IndicadorNaturezaPJ { get; set; } = IndicadorNaturezaPJ.PessoaJuridicaGeral;
        public IndicadorTipoAtividadePreponderante IndicadorTipoAtividadePreponderante { get; set; } = IndicadorTipoAtividadePreponderante.IndustrialEquiparadoIndustrial;

        // Registros Filhos

        public Registro0001 Registro0001 { get; set; } = null;
        public Registro0990 Registro0990 { get; set; } = null;

        // tEXTO = sTRING
        // 'numero inteiro até 2mi = integer?
        // numero inteiro curto até 32768 = short?
        // numero inteiro longo até 9bi = Long?
        // datas = Date?
        // tempo

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0000|");
            writer.Append(Versao + "|");
            writer.Append(((int)TipoEscrit).ToString() + "|");
            if (SituacaoEspecial != SituacaoEspecial.Vazio)
                writer.Append(((int)SituacaoEspecial).ToString() + "|");
            else
                writer.Append("|");
            writer.Append(NumeroReciboAnterior + "|");
            writer.Append(DataInicial.ToSpedString() + "|");
            writer.Append(DataFinal.ToSpedString() + "|");
            writer.Append(NomeEmpresarial + "|");
            writer.Append(NumeroCnpj + "|");
            writer.Append(UF + "|");
            writer.Append(CodigoMunicipio + "|");
            writer.Append(Suframa + "|");
            writer.Append(string.Format("{0:00}", (int)IndicadorNaturezaPJ) + "|");
            writer.Append(((int)IndicadorTipoAtividadePreponderante).ToString() + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            TipoEscrit = (TipoEscritur)data[3].ToEnum<TipoEscritur>(TipoEscritur.Original);
            SituacaoEspecial = (SituacaoEspecial)data[4].ToEnum<SituacaoEspecial>(SituacaoEspecial.Vazio);
            NumeroReciboAnterior = data[5];
            DataInicial = data[6].ToDate();
            DataFinal = data[7].ToDate();
            NomeEmpresarial = data[8];
            NumeroCnpj = data[9];
            UF = data[10];
            CodigoMunicipio = data[11];
            Suframa = data[12];
            IndicadorNaturezaPJ = (IndicadorNaturezaPJ)data[13].ToEnum<IndicadorNaturezaPJ>(IndicadorNaturezaPJ.PessoaJuridicaGeral);
            IndicadorTipoAtividadePreponderante = (IndicadorTipoAtividadePreponderante)data[14].ToEnum<IndicadorTipoAtividadePreponderante>(IndicadorTipoAtividadePreponderante.IndustrialEquiparadoIndustrial);
        }
    }
}