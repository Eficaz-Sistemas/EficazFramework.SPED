import os, re

def parse_cs(file_path):
    with open(file_path, "r", encoding="utf-8") as f:
        content = f.read()
    
    props = []
    # match public Type Name { get; set; }
    matches = re.finditer(r"public\s+([^\s]+)\s+([^\s]+)\s*{\s*get;\s*set;\s*}", content)
    for m in matches:
        props.append((m.group(1), m.group(2)))
        
    return props

def generate_test(registro, bloco, props):
    test_code = f"""using System;
using EficazFramework.SPED.Schemas.ECD;
using FluentAssertions;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.ECD.{bloco};

public class {registro}Test : BaseTest
{{
    [Test]
    public void Construtor()
    {{
        var reg = new {registro}();
        reg.Codigo.Should().Be("{registro[8:]}");
    }}
"""
    
    # Check if empty
    if not props:
        test_code += f"""
    [TestCase("|{registro[8:]}|", "900")]
    public void Escrita(string result, string versao)
    {{
        var reg = new {registro}();
        reg.ToString().Should().Be(result);
    }}
}}"""
        return test_code

    test_code += f"""
    [TestCase("", "900")]
    public void Construtor(string linha, string versao)
    {{
        var reg = new {registro}(linha, versao);
        InternalRead(reg, versao);
    }}

    [TestCase("", "900")]
    public void Escrita(string result, string versao)
    {{
        var reg = new {registro}()
        {{
"""
    for t, n in props:
        test_code += f"            // {n} = ...,\n"
    
    test_code += f"""        }};
        reg.ToString().Should().Be(result);
    }}

    [TestCase("", "900")]
    public void Leitura(string linha, string versao)
    {{
        var reg = new {registro}();
        reg.LeParametros(linha.Split("|"));
        InternalRead(reg, versao);
    }}

    private void InternalRead({registro} reg, string versao)
    {{
"""
    for t, n in props:
        test_code += f"        // reg.{n}.Should().Be(...);\n"

    test_code += "    }\n}"
    return test_code


