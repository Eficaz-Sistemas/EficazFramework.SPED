# Livro Caixa Digital do Produtor Rural (LCDPR)

- **Pessoa Física**
- **Produto Rural**
- **Até R$4,8 milhões de reais**

# Guia
Uma escrituração da obrigação do produtor rural que visa esclarecer para a Receita Federal as movimentações de um produtor rural de pessoa física com renda bruta anual de até R$4,8 milhões de reais no determinado ano-calendário.

# Objetivo
Tornar o cumprimento das obrigações fiscais do produtor rural, obrigatoriamente, pessoa física, mais transparentes e claros, agilizando o processo por meio da digitalização.

# Composição/Layout

## Geral

**OBS** O documento vale ao que está escrito após o "=>".
```csharp
/// Bloco 0
// Registro 0000 => 0000|LCDPR|0013|11111111191|JOSÉ DA SILVA|0|0||01012019|31122019
// Registro 0010 => 0010|1
// Registro 0030 => 0030|RUA TESTE|1234|BLOCO Z SALA 301|BAIRRO LCDPR|DF|5300108|71000000|6133333333|testeLCDPR@LCDPR.com.br
// Registro 0040 => 0040|001|BR|BRL|12345678|12345678901234|12345678901234|Fazenda Tudo Certo|Rodovia BR 999, Km 3000|||Distrito do Meio|DF|5300108|71000000|2|05000
// Registro 0045 => 0045|002|3|12345678912|JOÃO DE SOUSA|00520
// Registro 0050 => 0050|001|BR|999|Banco LCDPR|1234|0000000123456789

/// Bloco Q
// Registro Q100 => Q100|02012019|001|001|2|3|Venda de 100 sacas de milho|12345678912|1|1000000|0|1100000|P
// Registro Q100 => Q200|012019|10000000| 8500000| 1500000|P
// Registro Q200 => Q200|022019|9000000| 9300000| 1200000|P

/// Bloco 9
// Registro 9999 => 9999|JOSE DE SOUZA|12345678912|AL123456O| testeLCDPR@LCDPR.com.br|6133333333|8007
```

## Bloco 0 
Responsável pela abertura, identificação e referências da pessoa física, estado e informações pessoais.

### Registro 0000
### Registro 0010
### Registro 0030
### Registro 0040
### Registro 0045
### Registro 0050


## Bloco Q
Responsável pela demonstração dos resultados obtidos com a atividade rural da pessoa física.

### Registro Q100
### Registro Q200


## Bloco 9
Responsável por informar o profissional responsável pela elaboração do LCPDR e informar informações sobre o documento.

### Registro 9999


## Documentos
- [Documentação - Receita Federal](https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/declaracoes-e-demonstrativos/lcdpr-livro-caixa-digital-do-produtor-rural/manual-de-preenchimento-do-lcdpr-1-3)