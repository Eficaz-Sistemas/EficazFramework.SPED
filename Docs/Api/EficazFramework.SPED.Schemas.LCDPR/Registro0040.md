#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.LCDPR](EficazFramework.SPED.Schemas.LCDPR.md 'EficazFramework.SPED.Schemas.LCDPR')

## Registro0040 Class

Cadastro dos Imóveis Rurais

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - 1:N
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| IDImovel | `Nullable<Int32>` | Identificador único (código) do Imóvel no LCDPR |
| Pais | `String` | País (Brasil - BR) |
| Moeda | `String` | Moeda (Padrão: Real Brasileiro 0 BRL) |
| NIRF | `String` | CAFIR (Informar DV) |
| CAEPF | `String` | Cadastro de Atividade Econômica da Pessoa Física (IN RFB nº 1.828/2018) |
| InscricaoEstadual | `String` | Inscrição Estadual |
| NomeImovel | `String` | Nome do Imóvel |
| Endereco | `String` | Endereço do Imóvel |
| Numero | `String` | Número |
| Complemento | `String` | Complemento |
| Bairro | `String` | Bairro |
| UF | `String` | Unidade Federativa (http://sped.rfb.gov.br/pasta/show/1932) |
| CodigoMunicipio | `String` | Código do Município (http://sped.rfb.gov.br/pasta/show/1932) |
| CEP | `String` | Código de Endereçamento Postal |
| TipoExploracao | `TipoExploracao` | Tipo de Exploração do Imóvel: <br/>            1 – Exploração individual(Imóvel próprio) <br/>            2 - Condomínio <br/>            3 - Imóvel arrendado <br/>            4 - Parceria <br/>            5 - Comodato <br/>            6- Outros |
| Percentual | `Nullable<Double>` | Participação em percentual na exploração do Imóvel |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.LCDPR/Registro0040/EscreveLinha().md 'EficazFramework.SPED.Schemas.LCDPR.Registro0040.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.LCDPR/Registro0040/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.LCDPR.Registro0040.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.LCDPR/Registro0040/LeParametros(string[]).md#EficazFramework.SPED.Schemas.LCDPR.Registro0040.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.LCDPR.Registro0040.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "0013";  
var reg0040 = new Registro0040(null, _versao)  
{  
    IDImovel = 1,  
    Pais = "BR",  
    Moeda = "BRL",  
    NIRF = "12345678",  
    CAEPF = "12345678901234",  
    InscricaoEstadual = "12345678901234",  
    NomeImovel = "Fazenda Eficaz",  
    Endereco = "Rodovia BR 999, Km 3000",  
    Bairro = "Zona Rural",  
    UF = "MG",  
    CodigoMunicipio = "3129707",  
    CEP = "37990000",  
    TipoExploracao = TipoExploracao.Individual,  
    Percentual = 100000  
};  
```