#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0001 Class

Abertura do Bloco 0

### Remarks
Nível hierárquico - 1 <br/>  
Ocorrência - um por arquivo.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| IndicadorMovimento | `IndicadorMovimento` | Indicador de movimento: <br/>            0 - Bloco com Dados Informados <br/>            1 - Bloco som Dados Informados <br/> |
| Registro0005 | `Registro0005` | Propriedade de navegação para registro filho. |
| Registros0015 | `List<Registro0015>` | Propriedade de navegação para lista de registros filhos. |
| Registro0100 | `Registro0100` | Propriedade de navegação para registro filho. |
| Registros0150 | `List<Registro0150>` | Propriedade de navegação para lista de registros filhos. |
| Registros0190 | `List<Registro0190>` | Propriedade de navegação para lista de registros filhos. |
| Registros0200 | `List<Registro0200>` | Propriedade de navegação para lista de registros filhos. |
| Registros0300 | `List<Registro0300>` | Propriedade de navegação para lista de registros filhos. |
| Registros0400 | `List<Registro0400>` | Propriedade de navegação para lista de registros filhos. |
| Registros0450 | `List<Registro0450>` | Propriedade de navegação para lista de registros filhos. |
| Registros0460 | `List<Registro0460>` | Propriedade de navegação para lista de registros filhos. |
| Registros0500 | `List<Registro0500>` | Propriedade de navegação para lista de registros filhos. |
| Registros0600 | `List<Registro0600>` | Propriedade de navegação para lista de registros filhos. |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0001/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0001/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0001/LeParametros(string[]).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0001.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "017";  
var reg0001 = new Registro0001(null, _versao)  
{  
    IndicadorMovimento = Primitives.IndicadorMovimento.ComDados  
};  
```