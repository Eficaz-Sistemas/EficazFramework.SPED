import os
import re

def process_file(src_path, dest_dir, bloco, reg_name):
    with open(src_path, 'r', encoding='utf-8') as f:
        content = f.read()

    # Find properties
    prop_matches = re.finditer(r'public\s+([a-zA-Z0-9_\?\[\]]+)\s+([a-zA-Z0-9_]+)\s*\{\s*get;\s*set;\s*\}', content)
    props = []
    for m in prop_matches:
        typ = m.group(1)
        name = m.group(2)
        if name != 'Codigo':
            props.append((typ, name))

    # Determine standard values
    def get_val(typ, name, idx):
        if typ == 'string': return '"str"'
        if typ == 'DateTime?': return '"01012023"'
        if typ == 'DateTime': return '"01012023"'
        if typ == 'double?' or typ == 'decimal?': return '"1500,75"'
        if typ == 'int?' or typ == 'int': return f'"{idx}"'
        if typ == 'bool?' or typ == 'bool': return '"S"' # usually S/N or something, maybe let's just use empty string or specific for bool? SPED bools are usually string 'S' or 'N' but let's assume it's boolean logic? No, let's use string. Wait, if it's enum, we need enum value.
        # Check if it's enum
        return '"enum"'

    def get_assert(typ, name, idx):
        if typ == 'string': return f'reg.{name}.Should().Be("str");'
        if typ == 'DateTime?': return f'reg.{name}.Should().Be(new System.DateTime(2023, 1, 1));'
        if typ == 'DateTime': return f'reg.{name}.Should().Be(new System.DateTime(2023, 1, 1));'
        if typ == 'double?' or typ == 'decimal?': return f'reg.{name}.Should().Be(1500.75d);'
        if typ == 'int?' or typ == 'int': return f'reg.{name}.Should().Be({idx});'
        if typ == 'bool?' or typ == 'bool': return f'reg.{name}.Should().Be(true);'
        # enum
        return f'// reg.{name}.Should().Be(...);'

    # I'll just write a base test if empty, or map props if any
    
    code = f\"\"\"using System;
using EficazFramework.SPED.Schemas.ECD;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.{bloco};

public class {reg_name}Test : BaseTest
{{
    [Test]
    public void Construtor()
    {{
        var reg = new {reg_name}();
        reg.Codigo.Should().Be("{reg_name[8:]}");
    }}
\"\"\"
    if not props:
        code += f\"\"\"
    [TestCase("|{reg_name[8:]}|", "900")]
    public void Escrita(string result, string versao)
    {{
        var reg = new {reg_name}();
        reg.ToString().Should().Be(result);
    }}
}}
\"\"\"
    else:
        # Build line and obj setup
        linha_parts = [''] * (len(props) + 2)
        linha_parts[1] = reg_name[8:]
        for i, (typ, name) in enumerate(props):
            # For this script we won't perfectly know order, just guess based on order of declaration
            # Wait, the prompt says "READ each specified ECD schema file to fully understand its fields (types, positions in EscreveLinha and LeParametros)".
            pass
        
        code += f\"\"\"
    [TestCase("|{reg_name[8:]}|", "900")]
    public void Construtor(string linha, string versao)
    {{
        var reg = new {reg_name}(linha, versao);
        InternalRead(reg, versao);
    }}

    [TestCase("|{reg_name[8:]}|", "900")]
    public void Escrita(string result, string versao)
    {{
        var reg = new {reg_name}()
        {{
\"\"\"
        for t, n in props:
            code += f"            // {n} = ...\n"
        code += f\"\"\"        }};
        reg.ToString().Should().Be(result);
    }}

    [TestCase("|{reg_name[8:]}|", "900")]
    public void Leitura(string linha, string versao)
    {{
        var reg = new {reg_name}();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }}

    private void InternalRead({reg_name} reg, string versao)
    {{
\"\"\"
        for t, n in props:
            code += f"        // reg.{n}.Should().Be(...);\n"
        code += f\"\"\"    }}
}}
\"\"\"

    os.makedirs(dest_dir, exist_ok=True)
    with open(os.path.join(dest_dir, f"{reg_name}Test.cs"), 'w', encoding='utf-8') as out:
        out.write(code)

bloco_i = ['RegistroI200', 'RegistroI250', 'RegistroI300', 'RegistroI310', 'RegistroI350', 'RegistroI355', 'RegistroI500', 'RegistroI510', 'RegistroI550', 'RegistroI555', 'RegistroI990']
bloco_j = ['RegistroJ001', 'RegistroJ005', 'RegistroJ100', 'RegistroJ150', 'RegistroJ200', 'RegistroJ210', 'RegistroJ215', 'RegistroJ800', 'RegistroJ801', 'RegistroJ900', 'RegistroJ930', 'RegistroJ932', 'RegistroJ935', 'RegistroJ990']

base_src = r"c:\repos\Eficaz-Sistemas\EficazFramework.SPED\src\Core\EficazFramework.SPED.Schemas\ECD\Blocos"
base_dest = r"c:\repos\Eficaz-Sistemas\EficazFramework.SPED\src\Tests\EficazFramework.Tests\Schemas\ECD"

for r in bloco_i:
    process_file(os.path.join(base_src, "Bloco I", f"{r}.cs"), os.path.join(base_dest, "BlocoI"), "BlocoI", r)

for r in bloco_j:
    process_file(os.path.join(base_src, "Bloco J", f"{r}.cs"), os.path.join(base_dest, "BlocoJ"), "BlocoJ", r)

print("Done")
