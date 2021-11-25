using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace EficazFramework.SPED.Schemas.Primitives
{
    public abstract class Bloco
    {
        public Bloco()
        {

            /* TODO ERROR: Skipped RegionDirectiveTrivia */
            _registros = new System.Collections.ObjectModel.ObservableCollection<Registro>();
        }

        private System.Collections.ObjectModel.ObservableCollection<Registro> __registros;

        private System.Collections.ObjectModel.ObservableCollection<Registro> _registros
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __registros;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__registros != null)
                {

                    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
                    /* TODO ERROR: Skipped RegionDirectiveTrivia */
                    __registros.CollectionChanged -= CollectionChanged;
                }

                __registros = value;
                if (__registros != null)
                {
                    __registros.CollectionChanged += CollectionChanged;
                }
            }
        }

        private Dictionary<string, long> _contagem = new Dictionary<string, long>();

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        /// <summary>
        /// Obtém a listagem de registros da instância de bloco.
        /// </summary>
        public System.Collections.ObjectModel.ObservableCollection<Registro> Registros
        {
            get
            {
                return _registros;
            }
        }

        /// <summary>
        /// Obtém a contagem de um determinado registro da instância de bloco.
        /// </summary>
        /// <value></value>
        public Dictionary<string, long> TotaisRegistros
        {
            get
            {
                return _contagem;
            }
        }


        /// <summary>
        /// Obtém a contagem de um determinado registro da instância de bloco.
        /// </summary>
        /// <param name="registro">Código do Registro desejado</param>
        public long ContagemRegistro(string registro)
        {
            return Registros.Where(r => (r.Codigo ?? "") == (registro ?? "")).Select(r => r.Codigo).LongCount();
        }

        /// <summary>
        /// Obtém uma listagem dos tipos de registros informados na escrituração
        /// </summary>
        /// <value></value>
        [Obsolete("Performance degradation on large files")]
        public Dictionary<string, long> RegistrosGroupBy
        {
            get
            {
                return Registros.OrderBy(r => r.Codigo).GroupBy(r => r.Codigo).ToDictionary(x => x.Key, x => ContagemRegistro(x.Key));
            }
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        foreach (Registro item in e.NewItems)
                        {
                            if (!_contagem.ContainsKey(item.Codigo))
                                _contagem.Add(item.Codigo, 0L);
                            _contagem[item.Codigo] += 1L;
                        }

                        break;
                    }

                case NotifyCollectionChangedAction.Remove:
                    {
                        foreach (Registro item in e.OldItems)
                        {
                            if (!_contagem.ContainsKey(item.Codigo))
                                continue;
                            _contagem[item.Codigo] -= 1L;
                        }

                        break;
                    }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            // Dim ordered As IEnumerable(Of Registro) = (From i In Me._registros Order By i.Codigo).ToList
            foreach (var o in _registros)
            {
                string linha = o.EscreveLinha();
                if (linha != default)
                    writer.AppendLine(linha);
            }

            return writer.ToString();
        }

        public RegistroTotalizador[] GeraRegistrosTotalizadores(string codigo, string stringFormat)
        {
            var l = new List<RegistroTotalizador>();
            // Dim totais As Dictionary(Of String, Integer) = Me.RegistrosGroupBy
            foreach (var c in _contagem.OrderBy(f => f.Key))
                l.Add(new RegistroTotalizador(codigo) { RegistroTotalizado = c.Key, TotalRegistros = (int)c.Value, StringFormat = stringFormat });
            return l.ToArray();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }
}