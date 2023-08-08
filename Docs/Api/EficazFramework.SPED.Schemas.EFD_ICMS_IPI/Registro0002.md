#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0002 Class

Classificação do Estabelecimento Industrial ou Equiparado a Industrial

### Remarks
Nível hierárquico - 2 <br/>  
Ocorrência - um por arquivo.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| ClassificacaoEstabelecimento | `TipoDeAtividade` | Classificação do Estabelecimento conforme Tabela 4.5.5: <br/>            0 - Industrial ou Equiparado a Industrial <br/>            1 - Outross <br/> |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0002/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0002/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0002/LeParametros(string[]).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0002.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "017";  
var reg0002 = new Registro0002(null, _versao)  
{  
    ClassificacaoEstabelecimento = Primitives.TipoAtividade.Industrial  
};  
```