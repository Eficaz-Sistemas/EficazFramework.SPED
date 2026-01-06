// Plano detalhado (pseudocódigo):
// 1. Ler argumentos: pasta dos XSDs (opcional) e pasta do código C# (opcional). Se não fornecidos, usar diretório corrente.
// 2. Coletar nomes do XSD:
//    - Criar XmlSchemaSet, ler todos os arquivos *.xsd recursivamente.
//    - Compilar o conjunto de schemas.
//    - Para cada schema coletar:
//        * nomes de XmlSchemaComplexType (ct.Name)
//        * nomes de XmlSchemaSimpleType (st.Name)
//        * nomes de XmlSchemaElement (el.Name)
//    - Normalizar nomes (trim, ignorar case).
// 3. Coletar símbolos do código C# (heurística baseada em texto, suficiente para detectar mapeamento Xml):
//    - Procurar em todos os arquivos *.cs recursivamente.
//    - Extrair nomes de classes (regex), enums (regex).
//    - Extrair valores literais de atributos: [XmlType("...")], [XmlRoot("...")], [XmlElement("...")], [XmlEnum("...")], [XmlAttribute("...")]
//    - Extrair nomes de propriedades públicas (regex) para mapear elementos que não usam XmlElement explícito.
// 4. Criar heurísticas de comparação:
//    - Considerar correspondência se: nomes equivalem ignorando case OR XSDName == "TC" + ClassName OR XSDName == ClassName without T prefix OR XSD element name existe em XmlElement attributes OR element name equals property name (case-insensitive).
//    - Para enums considerar XmlEnum members e enum type names.
// 5. Gerar relatório detalhado:
//    - Listar tipos/elements/simpleTypes do XSD que não foram encontrados nem como classes nem como enums nem como XmlElement/property mapeada.
//    - Para cada falta, indicar sugestões de nomes prováveis (ex.: "TC" + nome) que foram testadas.
// 6. Saída no console com código de saída 0 se tudo coberto, 1 se itens faltantes.
// 7. Manter o código simples, com using fora do namespace e namespace file-scoped conforme .editorconfig.
// 8. Comentários em português e mensagens claras.
// Nota: esta ferramenta faz uma verificação heurística. Para 100% de garantia, um mapeamento XSD->C# gerado automaticamente (xsd.exe / xsd2code / svcutil) e comparação semântica seria o ideal.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Schema;

string startDir = Directory.GetCurrentDirectory();
string xsdFolder = args.Length > 0 && Directory.Exists(args[0]) ? args[0] : startDir;
string csFolder = args.Length > 1 && Directory.Exists(args[1]) ? args[1] : startDir;

Console.WriteLine($"Pasta XSD: {xsdFolder}");
Console.WriteLine($"Pasta C#: {csFolder}");
Console.WriteLine();

var xsdNames = CollectNamesFromXsds(xsdFolder);
var codeSymbols = CollectSymbolsFromCs(csFolder);

Console.WriteLine($"XSD: {xsdNames.Count} nomes coletados (complexTypes/simpleTypes/elements).");
Console.WriteLine($"Código: {codeSymbols.Classes.Count} classes, {codeSymbols.Enums.Count} enums, {codeSymbols.XmlElements.Count} XmlElement mappings, {codeSymbols.Properties.Count} propriedades públicas coletadas.");
Console.WriteLine();

var missing = new List<string>();
foreach (var x in xsdNames.OrderBy(n => n, StringComparer.OrdinalIgnoreCase))
{
    if (IsImplemented(x, codeSymbols) == false)
        missing.Add(x);
}

if (missing.Count == 0)
{
    Console.WriteLine("OK: Todos os tipos/elements do XSD possuem correspondência heurística no código.");
    return 0;
}

Console.WriteLine("Itens do XSD possivelmente ausentes no código (heurístico):");
foreach (var m in missing)
{
    Console.WriteLine(" - " + m);
    // sugestões
    var suggestions = SuggestMatches(m, codeSymbols);
    if (suggestions.Any())
        Console.WriteLine("     Sugestões encontradas: " + string.Join(", ", suggestions));
}

Console.WriteLine();
Console.WriteLine("Observação: esta ferramenta usa heurísticas (prefixos TC/T, XmlElement, propriedades públicas).");
Console.WriteLine("Revise manualmente os itens listados. Se quiser, execute apontando pastas específicas:");
Console.WriteLine("  dotnet run -- <pasta-xsd> <pasta-cs>");
return 1;


static HashSet<string> CollectNamesFromXsds(string folder)
{
    var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var schemaSet = new XmlSchemaSet();

    foreach (var file in Directory.EnumerateFiles(folder, "*.xsd", SearchOption.AllDirectories))
    {
        try
        {
            using var fs = File.OpenRead(file);
            var schema = XmlSchema.Read(fs, (s, e) =>
            {
                Console.WriteLine($"Aviso XSD ({Path.GetFileName(file)}): {e.Message}");
            });
            if (schema != null)
                schemaSet.Add(schema);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro lendo XSD '{file}': {ex.Message}");
        }
    }

    try
    {
        schemaSet.Compile();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erro compilando schemas: {ex.Message}");
    }

    foreach (XmlSchema schema in schemaSet.Schemas())
    {
        foreach (var item in schema.Items)
        {
            switch (item)
            {
                case XmlSchemaComplexType ct when !string.IsNullOrWhiteSpace(ct.Name):
                    set.Add(ct.Name!);
                    break;
                case XmlSchemaSimpleType st when !string.IsNullOrWhiteSpace(st.Name):
                    set.Add(st.Name!);
                    break;
                case XmlSchemaElement el when !string.IsNullOrWhiteSpace(el.Name):
                    set.Add(el.Name!);
                    break;
            }
        }
    }

    return set;
}

static (HashSet<string> Classes, HashSet<string> Enums, HashSet<string> XmlTypes, HashSet<string> XmlRoots, HashSet<string> XmlElements, HashSet<string> XmlAttributes, HashSet<string> Properties) CollectSymbolsFromCs(string folder)
{
    var classes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var enums = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var xmlTypes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var xmlRoots = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var xmlElements = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var xmlAttributes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
    var properties = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

    var classRegex = new Regex(@"\bclass\s+([A-Za-z_][A-Za-z0-9_]*)", RegexOptions.Compiled);
    var enumRegex = new Regex(@"\benum\s+([A-Za-z_][A-Za-z0-9_]*)", RegexOptions.Compiled);
    var propRegex = new Regex(@"\bpublic\s+[^\(\)\{\};=]+\s+([A-Za-z_][A-Za-z0-9_]*)\s*\{", RegexOptions.Compiled);
    var xmlAttrRegex = new Regex(@"Xml(Type|Root|Element|Enum|Attribute)\s*\(\s*""([^""]+)""", RegexOptions.Compiled);

    foreach (var file in Directory.EnumerateFiles(folder, "*.cs", SearchOption.AllDirectories))
    {
        string text;
        try
        {
            text = File.ReadAllText(file);
        }
        catch
        {
            continue;
        }

        foreach (Match m in classRegex.Matches(text))
        {
            if (m.Groups.Count > 1)
                classes.Add(m.Groups[1].Value);
        }

        foreach (Match m in enumRegex.Matches(text))
        {
            if (m.Groups.Count > 1)
                enums.Add(m.Groups[1].Value);
        }

        foreach (Match m in propRegex.Matches(text))
        {
            if (m.Groups.Count > 1)
                properties.Add(m.Groups[1].Value);
        }

        foreach (Match m in xmlAttrRegex.Matches(text))
        {
            if (m.Groups.Count > 2)
            {
                var kind = m.Groups[1].Value;
                var name = m.Groups[2].Value;
                switch (kind)
                {
                    case "Type":
                        xmlTypes.Add(name);
                        break;
                    case "Root":
                        xmlRoots.Add(name);
                        break;
                    case "Element":
                        xmlElements.Add(name);
                        break;
                    case "Enum":
                        // enum member mapping; collect as enum member names maybe not necessary
                        // but include just in case
                        xmlAttributes.Add(name);
                        break;
                    case "Attribute":
                        xmlAttributes.Add(name);
                        break;
                }
            }
        }
    }

    return (classes, enums, xmlTypes, xmlRoots, xmlElements, xmlAttributes, properties);
}

static bool IsImplemented(string xsdName, (HashSet<string> Classes, HashSet<string> Enums, HashSet<string> XmlTypes, HashSet<string> XmlRoots, HashSet<string> XmlElements, HashSet<string> XmlAttributes, HashSet<string> Properties) code)
{
    if (string.IsNullOrWhiteSpace(xsdName))
        return true;

    // direct matches
    if (code.Classes.Contains(xsdName) || code.Enums.Contains(xsdName) || code.XmlTypes.Contains(xsdName) || code.XmlRoots.Contains(xsdName) || code.XmlElements.Contains(xsdName) || code.Properties.Contains(xsdName))
        return true;

    // common prefixes used in generated code: TC, T
    if (xsdName.StartsWith("TC", StringComparison.OrdinalIgnoreCase))
    {
        var stripped = xsdName.Substring(2);
        if (code.Classes.Contains(stripped) || code.XmlTypes.Contains(stripped) || code.Properties.Contains(stripped))
            return true;
    }

    if (xsdName.StartsWith("T", StringComparison.OrdinalIgnoreCase) && xsdName.Length > 1)
    {
        var stripped = xsdName.Substring(1);
        if (code.Classes.Contains(stripped) || code.XmlTypes.Contains(stripped) || code.Properties.Contains(stripped))
            return true;
    }

    // sometimes class names use suffixes/prefixes, try TC + name mapping both ways
    if (code.Classes.Contains("TC" + xsdName) || code.Classes.Contains("T" + xsdName))
        return true;

    // xml element attributes often map element names; check xmlElements
    if (code.XmlElements.Contains(xsdName))
        return true;

    // property name match ignoring case
    if (code.Properties.Contains(xsdName, StringComparer.OrdinalIgnoreCase))
        return true;

    // try lowering first char (element vs property naming)
    var lc = Char.ToLowerInvariant(xsdName[0]) + xsdName.Substring(1);
    if (code.Properties.Contains(lc))
        return true;

    // try uppercase first char
    var uc = Char.ToUpperInvariant(xsdName[0]) + xsdName.Substring(1);
    if (code.Properties.Contains(uc))
        return true;

    return false;
}

static IEnumerable<string> SuggestMatches(string xsdName, (HashSet<string> Classes, HashSet<string> Enums, HashSet<string> XmlTypes, HashSet<string> XmlRoots, HashSet<string> XmlElements, HashSet<string> XmlAttributes, HashSet<string> Properties) code)
{
    var suggestions = new List<string>();
    string[] candidates = code.Classes.Concat(code.Enums).Concat(code.XmlTypes).Concat(code.XmlElements).Concat(code.Properties).ToArray();
    foreach (var c in candidates)
    {
        if (StringDistanceIsSmall(xsdName, c))
            suggestions.Add(c);
        if (StringDistanceIsSmall(xsdName.TrimStart('T', 'C'), c))
            suggestions.Add(c);
        if (StringDistanceIsSmall(("TC" + xsdName), c))
            suggestions.Add(c);
    }

    return suggestions.Distinct(StringComparer.OrdinalIgnoreCase).Take(10);
}

// Simples heurística de distância (prefix/suffix ou Levenshtein pequeno)
static bool StringDistanceIsSmall(string a, string b)
{
    if (string.IsNullOrEmpty(a) || string.IsNullOrEmpty(b))
        return false;
    if (a.Equals(b, StringComparison.OrdinalIgnoreCase))
        return true;
    if (a.StartsWith(b, StringComparison.OrdinalIgnoreCase) || b.StartsWith(a, StringComparison.OrdinalIgnoreCase))
        return true;
    int dist = Levenshtein(a.ToLowerInvariant(), b.ToLowerInvariant());
    return dist <= Math.Max(1, Math.Min(3, Math.Max(1, a.Length / 6)));
}

// Levenshtein implementation (small inputs)
static int Levenshtein(string s, string t)
{
    var n = s.Length;
    var m = t.Length;
    if (n == 0) return m;
    if (m == 0) return n;
    var d = new int[n + 1, m + 1];
    for (int i = 0; i <= n; d[i, 0] = i++) { }
    for (int j = 0; j <= m; d[0, j] = j++) { }
    for (int i = 1; i <= n; i++)
    {
        for (int j = 1; j <= m; j++)
        {
            int cost = (t[j - 1] == s[i - 1]) ? 0 : 1;
            d[i, j] = Math.Min(Math.Min(d[i - 1, j] + 1, d[i, j - 1] + 1), d[i - 1, j - 1] + cost);
        }
    }
    return d[n, m];
}
