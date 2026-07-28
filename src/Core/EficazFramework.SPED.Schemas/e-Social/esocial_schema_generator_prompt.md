# Contexto e Instruções para Geração de Classes C# do e-Social (XSD -> C#)

Este artefato define as diretrizes, padrões e convenções de código para parametrizar a criação automática de classes C# a partir de arquivos de esquema XSD do e-Social, no projeto **EficazFramework.SPED**.

---

## 📋 Regras de Arquitetura e Padrões de Código

### 1. Declaração do Namespace e Usings
Todas as classes pertencentes aos schemas do e-Social devem ser declaradas no namespace oficial do framework:

```csharp
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace EficazFramework.SPED.Schemas.eSocial;
```

---

### 2. Classe Principal do Evento
A classe principal representa a raiz do evento (ex: `S1000`, `S1005`, `S1010`, `S1200`, `S2200`).

#### Regras:
- Deve possuir o atributo `[Serializable()]`.
- Deve ser `public partial class <NomeDoEvento> : Evento`.
- **Herança**: Herda obrigatoriamente de `EficazFramework.SPED.Schemas.eSocial.Evento` (definido em [BaseClasses.cs](./BaseClasses.cs)).
- **Docstring**: Deve conter a documentação XML (`<summary>` e `<example>`) descrevendo o evento e fornecendo exemplo de preenchimento dos campos principais.

#### Overrides Obrigatórios na Classe Principal:
```csharp
[Serializable()]
public partial class S1000 : Evento
{
    private S1000InfoEmpregador evtInfoEmpregadorField;
    private SignatureType signatureField;

    /// <remarks/>
    public S1000InfoEmpregador evtInfoEmpregador
    {
        get => evtInfoEmpregadorField;
        set
        {
            evtInfoEmpregadorField = value;
            RaisePropertyChanged(nameof(evtInfoEmpregador));
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }

    // --- Overrides Obrigatórios do Evento ---

    /// <exclude/>
    public override void GeraEventoID() 
        => evtInfoEmpregadorField.Id = string.Format("ID{0}{1}{2}", 
            (int)(evtInfoEmpregadorField?.ideEmpregador?.tpInsc ?? PersonalidadeJuridica.CNPJ), 
            evtInfoEmpregadorField?.ideEmpregador?.NumeroInscricaoTag() ?? "00000000000000", 
            eSocialTimeStampUtils.GetTimeStampIDForEvent());

    /// <exclude/>
    public override string ContribuinteCNPJ() 
        => evtInfoEmpregadorField.ideEmpregador.nrInsc;

    // --- Membros da interface IXmlSignableDocument ---

    /// <exclude/>
    public override string TagToSign => Evento.root;

    /// <exclude/>
    public override string TagId => nameof(evtInfoEmpregador);

    /// <exclude/>
    public override bool EmptyURI => true;

    /// <exclude/>
    public override bool SignAsSHA256 => true;
}
```

---

### 3. Subclasses (Classes de Elementos Complexos e Filhos)
Todas as subclasses auxiliares geradas a partir do XSD (ex: seleções de ação, dados cadastrais, tabelas, identificadores) seguem este padrão:

#### Regras:
- **Herança**: Herda obrigatoriamente de `EficazFramework.SPED.Schemas.eSocial.ESocialBindableObject` (definido em [BaseClasses.cs](./BaseClasses.cs)).
- **Atributo**: Deve incluir a anotação `/// <exclude />` antes da assinatura da classe.
- Deve ser declarada como `public partial class <NomeDaSubclasse> : ESocialBindableObject`.

```csharp
/// <exclude />
public partial class S1000InfoEmpregador : ESocialBindableObject
{
    // ...
}
```

---

### 4. Padrão de Properties, Backing Fields e Notificação de Mudança

#### Regras de Implementação:
1. **Backing Field Privado**: Nomeado como `<propertyName>Field` com visibilidade `private`.
2. **Getter**: Retorna o backing field via expressão Lambda: `get => <propertyName>Field;`
3. **Setter**: Atribui o valor ao backing field e invoca `RaisePropertyChanged(nameof(<propertyName>));`.
4. **Annotations de Serialização XML**:
   - Manter attributes como `[XmlElement]`, `[XmlAttribute]`, `[XmlArray]`, `[XmlArrayItem]`, `[XmlIgnore]`, etc., exatamente conforme especificado no tipo XSD correspondente.
   - Para elementos de tipo data: `[XmlElement(DataType = "date")]`.
   - Para atributos ID do XML: `[XmlAttribute(DataType = "ID")]`.

#### Exemplo Padrão:
```csharp
private string classTribField;
private IndicadorCooperativa indCoopField = IndicadorCooperativa.Nao;
private bool indCoopFieldSpecified = false;

public string classTrib
{
    get => classTribField;
    set
    {
        classTribField = value;
        RaisePropertyChanged(nameof(classTrib));
    }
}

public IndicadorCooperativa indCoop
{
    get => indCoopField;
    set
    {
        indCoopField = value;
        RaisePropertyChanged(nameof(indCoop));
    }
}

[XmlIgnore()]
public bool indCoopSpecified
{
    get => indCoopFieldSpecified;
    set
    {
        indCoopFieldSpecified = value;
        RaisePropertyChanged(nameof(indCoopSpecified));
    }
}
```

---

### 5. Métodos `ShouldSerialize<PropertyName>()`
Para propriedades opcionais, tipos `Nullable<T>` (`DateTime?`, `int?`, `decimal?`, etc.) ou enums com valor opcional, incluir o método `ShouldSerialize<PropertyName>()` para controlar a emissão da tag na serialização XML.

```csharp
public DateTime? dtDou
{
    get => dtDouField;
    set
    {
        dtDouField = value;
        RaisePropertyChanged(nameof(dtDou));
    }
}

public bool ShouldSerializedtDou()
    => dtDou.HasValue;
```

---

### 6. Mapeamento de Tipos Restritos (`xs:restriction` -> `xs:enumeration`) para Enum

#### Regras de Implementação:
1. **Identificação no XSD**: Elementos XSD compostos por `xs:simpleType` com `xs:restriction` (baseados em `xs:byte`, `xs:unsignedByte`, `xs:integer`, `xs:string`, etc.) contendo valores enumerados (`xs:enumeration value="..."`) DEVEM ser implementados como `enum` em C#.
2. **Verificação de Existência Prévia**:
   - **CRÍTICO**: Antes de criar qualquer novo `enum`, VERIFICAR se um `enum` equivalente já existe no arquivo [Enums.cs](./Enums.cs) do namespace `EficazFramework.SPED.Schemas.eSocial`.
   - *Principais Enums Pré-existentes no Framework*:
     - `Ambiente` (1 = Producao, 2 = ProducaoRestrita_DadosReais)
     - `EmissorEvento` (1 = AppEmpregador, 2 = AppGovernamentalDomestico, etc.)
     - `SimNaoByte` (0 = Nao, 1 = Sim)
     - `SimNaoString` (S = Sim, N = Nao)
     - `PersonalidadeJuridica` (1 = CNPJ, 2 = CPF, 4 = CNO)
     - `TipoInscricao` (1 = CNPJ, 2 = CPF)
     - `IndicadorRetificacao` (1 = Original, 2 = Retificacao)
     - `IndicadorApuracao` (1 = Mensal, 2 = AnualDecimoTerceiroSalario)
     - `IndicadorCooperativa` (0 = Nao, 1 = CoopTrabalho, etc.)
     - `OpcaoTributacaoPrevidenciaria` (1 = Comercializacao, 2 = FolhaPagto)
   - Se o enum **já existir**, reutilizá-lo diretamente no tipo da propriedade na classe criada, **sem duplicar a declaração do Enum**.
   - Se o enum **não existir**, declará-lo com os mapeamentos `[XmlEnum("...")]` e `[Description("...")]` (se houver documentação no XSD):

```csharp
public enum TipoExemplo
{
    [XmlEnum("1")]
    [Description("Descrição do Item 1")]
    ItemUm = 1,

    [XmlEnum("2")]
    [Description("Descrição do Item 2")]
    ItemDois = 2
}
```

---

### 7. Cobertura de Campos (Mapeamento do XSD)
Na geração da classe do evento a partir do esquema XSD, é obrigatório conferir se todos os elementos, atributos e campos definidos no XSD original foram devidamente mapeados na classe principal ou em uma de suas subclasses. Nenhum campo do XSD deve ser omitido na modelagem C#.

### 8. Escrita de Testes Unitários de Validação
- **Projeto de Testes**: Todos os eventos devem ter seus testes unitários escritos no projeto [EficazFramework.Tests.csproj](../../../Tests/EficazFramework.Tests/EficazFramework.Tests.csproj).
- **Padrão de Implementação**: O padrão de nomenclatura e estrutura dos testes deve seguir exatamente o adotado no arquivo [S-1000.cs](../../../Tests/EficazFramework.Tests/Schemas/e-Social/S-1000.cs).
- **Preenchimento de Campos**: No método `PreencheCampos()`, preencher, se possível, todos os campos da classe gerada para garantir a validação rigorosa contra o schema XSD (inclusive sub-propriedades e opções opcionais de validação).

### 9. Documentação e Exemplo de Preenchimento
- **Regra**: Na classe principal do evento, utilize a tag XML `<example>` para incluir um exemplo real de preenchimento dos campos.
- **Padrão**: O exemplo fornecido na tag `<example>` deve corresponder fielmente ao conteúdo do método `PreencheCampos()` escrito no teste do respectivo evento, mantendo o padrão demonstrado no arquivo [s-1000.cs](./s-1000.cs).

---

## 🎯 Modelo de Prompt para Geração de Novo Evento e-Social

Para gerar a classe C# a partir de um schema XSD, utilize a seguinte estrutura de prompt:

```markdown
Você é um gerador de código especialista C# para o projeto EficazFramework.SPED.
Gere a classe C# referente ao evento e-Social do arquivo XSD fornecido a seguir, seguindo rigorosamente os padrões definidos abaixo:

1. Namespace: `EficazFramework.SPED.Schemas.eSocial`
2. Classe Principal:
   - Decorada com `[Serializable()]`
   - Herda de `EficazFramework.SPED.Schemas.eSocial.Evento`
   - Implementa os overrides obrigatórios: `GeraEventoID()`, `ContribuinteCNPJ()`, `TagToSign`, `TagId`, `EmptyURI`, `SignAsSHA256`.
3. Subclasses:
   - Decoradas com `/// <exclude />`
   - Herdam de `EficazFramework.SPED.Schemas.eSocial.ESocialBindableObject`
4. Propriedades e Backing Fields:
   - Privado `<propertyName>Field`
   - Setter chamando `RaisePropertyChanged(nameof(<propertyName>));`
   - Atributos XML (`[XmlElement]`, `[XmlAttribute]`, etc.) conforme o XSD.
   - Métodos `ShouldSerialize<propertyName>()` para propriedades nulas/opcionais.
5. Enumerações (`xs:restriction` -> `xs:enumeration`):
   - Mapear em `enum` com `[XmlEnum("...")]`.
   - Verificar se o Enum já existe em `EficazFramework.SPED.Schemas.eSocial` antes de declarar um novo. Se já existir (ex: `SimNaoByte`, `SimNaoString`, `Ambiente`, `PersonalidadeJuridica`, `TipoInscricao`, etc.), reutilizá-lo.
6. Cobertura do XSD:
   - Conferir se absolutamente todos os campos do XSD original ficaram devidamente mapeados na classe ou em uma de suas subclasses.
7. Exemplo de Preenchimento:
   - Na classe principal do evento, preencher a documentação XML na tag `<example>` com o exemplo do código de preenchimento de campos (copiado do método `PreencheCampos()` da classe de teste unitário), seguindo o exemplo de [s-1000.cs](./s-1000.cs).
8. Testes Unitários de Validação:
   - Escrever testes no projeto [EficazFramework.Tests.csproj](../../../Tests/EficazFramework.Tests/EficazFramework.Tests.csproj), seguindo o padrão de [S-1000.cs](../../../Tests/EficazFramework.Tests/Schemas/e-Social/S-1000.cs).
   - Preencher se possível todos os campos no método `PreencheCampos()` para validar a serialização contra o schema XSD.

---

### Documentação técnica, em HTML:

[Layout](https://www.gov.br/esocial/pt-br/documentacao-tecnica/leiautes-esocial-versao-s-1-3-nt-06-2026-rev-09-04-2026/index.html)
Aqui encontram-se regras de validação e preenchimento de cada campo.

---
### XSD DO EVENTO:
Está disponível em [eSocial.resx](../../../Tests/EficazFramework.Tests/Resources/Schemas/eSocial.resx), chave <evento>_v_S_01_03_00, exemplo: S1210_v_S_01_03_00
