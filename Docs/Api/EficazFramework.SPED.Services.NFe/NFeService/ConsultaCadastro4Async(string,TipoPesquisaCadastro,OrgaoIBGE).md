#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Services.NFe](EficazFramework.SPED.Services.NFe.md 'EficazFramework.SPED.Services.NFe').[NFeService](EficazFramework.SPED.Services.NFe/NFeService.md 'EficazFramework.SPED.Services.NFe.NFeService')

## NFeService.ConsultaCadastro4Async(string, TipoPesquisaCadastro, OrgaoIBGE) Method

Efetua a consulta de cadastro de contribuintes, na versão 4.00

```csharp
public System.Threading.Tasks.Task<EficazFramework.SPED.Schemas.NFe.RetornoConsultaCadastro> ConsultaCadastro4Async(string cnpjCpfIe, EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro documento, EficazFramework.SPED.Schemas.NFe.OrgaoIBGE uf);
```
#### Parameters

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string,EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE).cnpjCpfIe'></a>

`cnpjCpfIe` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

CNPJ, CPF ou Inscrição Estadual para pesquisa

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string,EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE).documento'></a>

`documento` [TipoPesquisaCadastro](EficazFramework.SPED.Schemas.NFe/TipoPesquisaCadastro.md 'EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro')

Informa qual tipo de documento o número fornecido em [cnpjCpfIe](EficazFramework.SPED.Services.NFe/NFeService/ConsultaCadastro4Async(string,TipoPesquisaCadastro,OrgaoIBGE).md#EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string,EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE).cnpjCpfIe 'EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string, EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro, EficazFramework.SPED.Schemas.NFe.OrgaoIBGE).cnpjCpfIe') corresponde

<a name='EficazFramework.SPED.Services.NFe.NFeService.ConsultaCadastro4Async(string,EficazFramework.SPED.Schemas.NFe.TipoPesquisaCadastro,EficazFramework.SPED.Schemas.NFe.OrgaoIBGE).uf'></a>

`uf` [OrgaoIBGE](EficazFramework.SPED.Schemas.NFe/OrgaoIBGE.md 'EficazFramework.SPED.Schemas.NFe.OrgaoIBGE')

Estado do contribuinte pesquisado

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[RetornoConsultaCadastro](EficazFramework.SPED.Schemas.NFe/RetornoConsultaCadastro.md 'EficazFramework.SPED.Schemas.NFe.RetornoConsultaCadastro')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')