using System.Globalization;
using System.Text;

namespace EficazFramework.SPED.Documents.Common;

/// <summary>Código de barras Code 128 (subconjunto C) usado na chave de acesso do DANFE e do DACTE.</summary>
internal static class Code128
{
    // Padrões do Code 128 (larguras alternadas barra/espaço, começando por barra). Índices 0-105 = valores
    // de símbolo, 106 = stop.
    private static readonly string[] Padroes =
    [
        "212222", "222122", "222221", "121223", "121322", "131222", "122213", "122312", "132212", "221213",
        "221312", "231212", "112232", "122132", "122231", "113222", "123122", "123221", "223211", "221132",
        "221231", "213212", "223112", "312131", "311222", "321122", "321221", "312212", "322112", "322211",
        "212123", "212321", "232121", "111323", "131123", "131321", "112313", "132113", "132311", "211313",
        "231113", "231311", "112133", "112331", "132131", "113123", "113321", "133121", "313121", "211331",
        "231131", "213113", "213311", "213131", "311123", "311321", "331121", "312113", "312311", "332111",
        "314111", "221411", "431111", "111224", "111422", "121124", "121421", "141122", "141221", "112214",
        "112412", "122114", "122411", "142112", "142211", "241211", "221114", "413111", "241112", "134111",
        "111242", "121142", "121241", "114212", "124112", "124211", "411212", "421112", "421211", "212141",
        "214121", "412121", "111143", "111341", "131141", "114113", "114311", "411113", "411311", "113141",
        "114131", "311141", "411131", "211412", "211214", "211232", "2331112"
    ];

    /// <summary>
    /// Gera, em SVG, o código de barras Code 128-C de uma sequência numérica de quantidade par de dígitos
    /// (a chave de acesso, 44 dígitos). Retorna null quando a entrada não for válida.
    /// </summary>
    internal static string? SvgSubconjuntoC(string digitos)
    {
        if (string.IsNullOrEmpty(digitos) || digitos.Length % 2 != 0 || !digitos.All(char.IsAsciiDigit))
            return null;

        const int inicioC = 105, parada = 106;
        var simbolos = new List<int> { inicioC };
        for (var i = 0; i < digitos.Length; i += 2)
            simbolos.Add(int.Parse(digitos.AsSpan(i, 2), CultureInfo.InvariantCulture));

        var soma = inicioC;
        for (var i = 1; i < simbolos.Count; i++)
            soma += simbolos[i] * i;
        simbolos.Add(soma % 103);
        simbolos.Add(parada);

        var caminho = new StringBuilder();
        var x = 0;
        foreach (var simbolo in simbolos)
        {
            var barra = true;
            foreach (var largura in Padroes[simbolo].Select(d => d - '0'))
            {
                if (barra)
                    caminho.Append(CultureInfo.InvariantCulture, $"M{x} 0h{largura}v34h-{largura}z");
                x += largura;
                barra = !barra;
            }
        }

        return $"<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 {x} 34\" preserveAspectRatio=\"none\" " +
               $"shape-rendering=\"crispEdges\"><path d=\"{caminho}\" fill=\"#000000\"/></svg>";
    }
}
