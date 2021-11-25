using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI
{

    /// <summary>
    /// Volume de Vendas
    /// </summary>
    /// <remarks></remarks>
    public class Registro1320 : Primitives.Registro
    {
        public Registro1320() : base("1320")
        {
        }

        public Registro1320(string linha, string versao) : base(linha, versao)
        {
        }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|1320|"); // 1
            writer.Append(NumeroBico + "|"); // 2
            writer.Append(NumeroIntervencao + "|");  // 3
            writer.Append(MotivoIntervencao + "|"); // 4
            writer.Append(NomeInterventor + "|"); // 5
            writer.Append(CNPJEmpresaIntervencao + "|");  // 6
            writer.Append(CPFTecnicoIntervencao + "|");  // 7
            writer.Append(string.Format("{0:0.###}", ValorFechamento) + "|");  // 8
            writer.Append(string.Format("{0:0.###}", ValorAbertura) + "|");  // 9
            writer.Append(string.Format("{0:0.###}", VolumeAfericoes) + "|"); // 10
            writer.Append(string.Format("{0:0.###}", VolumeVendas) + "|");  // 11
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NumeroBico = data[2].ToNullableInteger();
            NumeroIntervencao = data[3];
            MotivoIntervencao = data[4].ToNullableDouble();
            NomeInterventor = data[5];
            CNPJEmpresaIntervencao = data[6];
            CPFTecnicoIntervencao = data[7];
            ValorFechamento = data[8].ToNullableDouble();
            ValorAbertura = data[9].ToNullableDouble();
            VolumeAfericoes = data[10].ToNullableDouble();
            VolumeVendas = data[11].ToNullableDouble();
        }

        public int? NumeroBico { get; set; } = default; // 2
        public string NumeroIntervencao { get; set; } = null; // 3
        public double? MotivoIntervencao { get; set; } = default; // 4
        public string NomeInterventor { get; set; } = null; // 5
        public string CNPJEmpresaIntervencao { get; set; } = null; // 6
        public string CPFTecnicoIntervencao { get; set; } = null; // 7
        public double? ValorFechamento { get; set; } = default; // 8
        public double? ValorAbertura { get; set; } = default; // 9
        public double? VolumeAfericoes { get; set; } = default; // 10
        public double? VolumeVendas { get; set; } = default; // 11


        // Registros Filhos
        public List<Registro1310> Registros1310 { get; set; } = new List<Registro1310>();
        // Property RegistrosC114 As New List(Of RegistroC114)
        // Property RegistrosC120 As New List(Of RegistroC120)
        // Property RegistrosC190 As New List(Of RegistroC190)
        // Property RegistrosC195 As New List(Of RegistroC195)

    }
}