using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EficazFrameworkCore.SPED.Schemas.Primitives
{
    public abstract class Escrituracao : INotifyPropertyChanged
    {
        public Escrituracao()
        {
            _RegistroTotalizadorStringFormat = "|" + RegistroTotalizadorCodigo + "|{0}|{1}|";
        }

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /// <summary>
        /// Cria uma nova instância de Escrituração Digital
        /// </summary>
        /// <param name="name"></param>
        /// <remarks></remarks>
        public Escrituracao(string name)
        {
            _RegistroTotalizadorStringFormat = "|" + RegistroTotalizadorCodigo + "|{0}|{1}|";
            if (string.IsNullOrEmpty(name) & string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("O nome da escrituraçao não pode ser nulo.");
            }
            Name = name;
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private readonly string Name = null;
        private bool _isWorking = false;
        internal bool _mustStop = false;
        private string _blocoTotalizador = "9";
        private string _codigoRegTotalizador = "9900";
        private string _RegistroTotalizadorStringFormat;
        private System.Text.Encoding _encoding = System.Text.Encoding.UTF8;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public Collections.ObservableDictionary<string, Bloco> Blocos { get; } = new Collections.ObservableDictionary<string, Bloco>();

        public string Versao { get; set; } = "001";

        public int Progresso { get; private set; } = 0;

        public List<string> RegistrosIgnorados { get; } = new List<string>();

        public bool IsLoading
        {
            get
            {
                return _isWorking;
            }

            set
            {
                _isWorking = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsLoading"));
            }
        }

        public string RegistroAtual { get; private set; } = null;

        internal HeaderPosition HeaderPosition { get; } = new HeaderPosition();

        public string BlocoTotalizador
        {
            get
            {
                return _blocoTotalizador;
            }

            set
            {
                _blocoTotalizador = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("BlocoTotalizador"));
            }
        }

        public string RegistroTotalizadorCodigo
        {
            get
            {
                return _codigoRegTotalizador;
            }

            set
            {
                _codigoRegTotalizador = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegistroTotalizadorCodigo"));
            }
        }

        public string RegistroTotalizadorStringFormat
        {
            get
            {
                return _RegistroTotalizadorStringFormat;
            }

            set
            {
                _RegistroTotalizadorStringFormat = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegistroTotalizadorStringFormat"));
            }
        }

        public System.Text.Encoding Encoding
        {
            get
            {
                return _encoding;
            }

            set
            {
                _encoding = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Encoding"));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public async Task LeArquivo(System.IO.Stream stream)
        {
            // Try
            IsLoading = true;
            using (var reader = new System.IO.StreamReader(stream, Encoding))
            {
                while (!reader.EndOfStream)
                {
                    if (_mustStop == true)
                        break;
                    string linha = await reader.ReadLineAsync();
                    if (linha.Length < HeaderPosition.Index + HeaderPosition.Lenght)
                        continue; // 02/04/2018: anti blank-line exception
                    string reg = linha.Substring(HeaderPosition.Index, HeaderPosition.Lenght);
                    if ((reg ?? "") != (RegistroAtual ?? ""))
                    {
                        SetCurrent(reg);
                    }

                    if (!RegistrosIgnorados.Contains(reg))
                    {
                        await Task.Run(() => ProcessaLinha(linha));
                    }

                    if (reader.BaseStream.Length > 0L)
                    {
                        int per = (int)(reader.BaseStream.Position / (double)reader.BaseStream.Length * 100d);
                        SetPercent(per);
                    }
                }

                reader.Dispose();
            }
            // Catch ex As Exception

            // End Try
            IsLoading = false;
            SetCurrent(null);
        }

        private void SetPercent(int percent)
        {
            Progresso = percent;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Progresso"));
        }

        private void SetCurrent(string reg)
        {
            RegistroAtual = reg;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("RegistroAtual"));
        }

        public async Task EscreveArquivo(System.IO.Stream stream) // As String
        {
            SetPercent(0);
            int i = 0;
            using (var writer = new System.IO.StreamWriter(stream, Encoding))
            {

                // ## Geração Automátiva dos Registros Totalizadores
                if (BlocoTotalizador != null)
                {
                    if (!Blocos.ContainsKey(BlocoTotalizador))
                        throw new ArgumentException(string.Format("O Bloco {0} não foi adicionado à escrituração.", BlocoTotalizador));
                    foreach (var preReg in PrefixoBlocoEncerramento())
                        Blocos[BlocoTotalizador].Registros.Add(preReg);
                    foreach (var bl in Blocos)
                    {
                        if ((bl.Key ?? "") == (BlocoTotalizador ?? ""))
                            continue;
                        var results = bl.Value.GeraRegistrosTotalizadores(RegistroTotalizadorCodigo, RegistroTotalizadorStringFormat);
                        foreach (var tot in results)
                            Blocos[BlocoTotalizador].Registros.Add(tot);
                    }

                    foreach (var postReg in SufixoBlocoEncerramento())
                        Blocos[BlocoTotalizador].Registros.Add(postReg);
                };

                // ## Obtenção do total de registros para progress bar:
                long total_registros = Blocos.Values.Select(v => v.Registros.Count).Sum();
                ContagemRegistroConcluida?.Invoke(this, new ContagemRegistroEventArgs(total_registros));

                // ## Escrita dos Registros
                foreach (var bl in Blocos.Values)
                {
                    foreach (var o in bl.Registros)
                    {
                        i += 1;
                        o.OverrideVersao(Versao);
                        await writer.WriteLineAsync(o.EscreveLinha());
                        SetPercent((int)((double)i / (double)total_registros * 100d));
                    }
                }

                // '## Escrita personalizada final
                await EncerraArquivo(writer);

                // ## Liberação de recursos
                await writer.FlushAsync();
                writer.Dispose();
            }
        }

        public virtual Registro[] PrefixoBlocoEncerramento()
        {
            return null;
        }

        public virtual Registro[] SufixoBlocoEncerramento()
        {
            return null;
        }

        public virtual async Task EncerraArquivo(System.IO.StreamWriter writer)
        {
            await Task.Delay(1);
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /// <summary>
        /// Método executado durante a LEITURA do arquivo digital
        /// </summary>
        /// <param name="linha"></param>
        /// <remarks></remarks>

        public abstract void ProcessaLinha(string linha);

        /// <summary>
        /// Retorna o CNPJ do informante do arquivo.
        /// </summary>
        /// <param name="stream"></param>
        public abstract Task<string> LeEmpresaArquivo(System.IO.Stream stream);

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public override string ToString()
        {
            var writer = new System.Text.StringBuilder();
            foreach (var bl in Blocos.Values)
                writer.Append(bl.EscreveLinha());
            return writer.ToString();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;
        public event ContagemRegistroEventHandler ContagemRegistroConcluida;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    public class HeaderPosition
    {
        public int Index { get; set; } = 1;
        public int Lenght { get; set; } = 4;
    }

    public class ContagemRegistroEventArgs
    {
        public ContagemRegistroEventArgs(long contagem)
        {
            TotalRegistro = contagem;
        }

        public long TotalRegistro { get; private set; }
    }

    public delegate void ContagemRegistroEventHandler(object sender, ContagemRegistroEventArgs e);
}