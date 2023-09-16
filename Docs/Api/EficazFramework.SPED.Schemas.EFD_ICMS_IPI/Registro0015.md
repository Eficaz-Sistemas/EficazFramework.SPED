#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0015 Class

Dados do Contribuinte Substituto Ou Responsável pelo ICMS Destino

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - vários (por arquivo).
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| UF | `String` | Sigla da unidade federativa do contribuinte substituído ou unidade de federação do consumidor final             não contribuinte - ICMS Destino EC 87/15 |
| InscricaoEstadual | `String` | Inscrição Estadual do contribuinte substituído ou unidade de federação do consumidor final             não contribuinte - ICMS Destino EC 87/15 |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0015/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0015/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0015/LeParametros(string[]).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0015.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "017";  
var reg0015 = new Registro0015(null, _versao)  
{  
    UF = "MG",  
    InscricaoEstadual = "0010001112233"  
};  
```