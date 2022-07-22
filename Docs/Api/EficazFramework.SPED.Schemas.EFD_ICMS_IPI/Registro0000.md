#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade

### Remarks
Nível hierárquico - 0 <br/>  
Ocorrência - um por arquivo.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Finalidade | `Finalidade` | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| DataInicial | `Nullable<DateTime>` | Data inicial das informações contidas no arquivo |
| DataFinal | `Nullable<DateTime>` | Data final das informações contidas no arquivo |
| RazaoSocial | `String` | Nome empresarial da entidade |
| CNPJ | `String` | Número de inscrição da entidade no CNPJ |
| CPF | `String` | Número de inscrição da entidade no CPF |
| UF | `String` | Sigla da unidade da federação da entidade |
| InscricaoEstadual | `String` | Inscrição Estadual da entidade |
| MunicipioCodigo | `String` | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| InscricaoMunicipal | `String` | Inscrição Municipal da entidade |
| InscricaoSuframa | `String` | Inscrição da entidade no Suframa |
| Perfil | `Perfil` | Perfil de apresentação do arquivo fiscal:  <br/>            A – Perfil A <br/>            B – Perfil B <br/>            C – Perfil C <br/> |
| Atividade | `TipoAtividade` | Indicador de tipo de atividade: <br/>            0 – Industrial ou equiparado a industrial  <br/>            1 – Outros  <br/> |
| Registro0001 | `Registro0001` | Propriedade de navegação para acesso ao Registro0001. <br/>            Setada automaticamente na leitura de arquivos.            Deve ser setada manualmente na construção do arquivo a ser escrito. |
| Registro0990 | `Registro0990` | Propriedade de navegação para acesso ao Registro0001. <br/>            Setada automaticamente na leitura de arquivos.            Deve ser setada manualmente na construção do arquivo a ser escrito. |

| Methods | |
| :--- | :--- |
| [EscreveLinha()](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0000/EscreveLinha().md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000.EscreveLinha()') | Realiza a escrita (serialização) da instância em uma linha do arquivo. |
| [LeParametros(string[])](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0000/LeParametros(string[]).md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000.LeParametros(string[])') | Efetua a leitura (desserialização) da linha especificada em [data](EficazFramework.SPED.Schemas.EFD_ICMS_IPI/Registro0000/LeParametros(string[]).md#EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000.LeParametros(string[]).data 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Registro0000.LeParametros(string[]).data') |

### Example
```csharp  
string _versao = "017";  
var reg0000 = new Registro0000(null, _versao)  
{  
    Finalidade = Primitives.Finalidade.Original,  
    DataInicial = new System.DateTime(2022, 7, 1),  
    DataFinal = new System.DateTime(2022, 7, 31),  
    RazaoSocial = "Empresa Exemplo S/A",  
    CNPJ = "00123456000100",  
    UF = "MG",  
    InscricaoEstadual = "00112345600001",  
    MunicipioCodigo = "3129707",  
    Perfil = Perfil.B,  
    Atividade = Primitives.TipoAtividade.Outros  
};  
```