# <p align="center"> ![EficazFramework.SPED](Assets/GitHub-HeaderReadme.png)
# EficazFramework.SPED

![Azure DevOps builds](https://eficazshields.azurewebsites.net/azure-devops/build/eficazcs/EficazFramework/21?&logo=azurepipelines&logoColor=white&style=flat-square)
![Azure DevOps tests (compact)](https://eficazshields.azurewebsites.net/azure-devops/tests/eficazcs/EficazFramework/21?compact_message&logo=azuredevops&logoColor=white&style=flat-square)
![Azure DevOps coverage](https://eficazshields.azurewebsites.net/azure-devops/coverage/eficazcs/EficazFramework/21?logo=codecov&logoColor=white&style=flat-square)
![Licence](https://img.shields.io/static/v1?label=licence&message=MIT&color=blue&style=flat-square&logo=github&logoColor=white)
[![Discord](https://eficazshields.azurewebsites.net/discord/846078359498653706?color=purple&logo=discord&logoColor=white&style=flat-square)](https://discord.gg/QgtMy6J6)
[![Twitter Follow](https://eficazshields.azurewebsites.net/twitter/follow/EficazCS?color=blue&label=twitter&logo=twitter&logoColor=white&style=flat-square)](https://twitter.com/EficazCS)
![EFD ICMS/IPI](https://eficazshields.azurewebsites.net/badge/EFD%20ICMS%2FIPI-v017-red?style=flat-square)
![EFD Contribuições](https://eficazshields.azurewebsites.net/badge/EFD%20Contribuições-v006-blue?style=flat-square)
![EFD-Reinf](https://eficazshields.azurewebsites.net/badge/EFD%20Reinf-v2.1.1-ff69b4?style=flat-square)
![ECD](https://eficazshields.azurewebsites.net/badge/ECD-v9.00-brightgreen?style=flat-square) 
![ECF](https://eficazshields.azurewebsites.net/badge/ECF-v0007-orange?style=flat-square) 
![LCDPR](https://eficazshields.azurewebsites.net/badge/LCDPR-v0013-greenyellow?style=flat-square)
   
   Bem vindo ao projeto EficazFramework.SPED.
   
   Este projeto tem por finalidade facilitar as tarefas de leitura, auditoria e escrita das mais diversas escriturações e arquivos eletrônicos governamentais.
   
   Desenvolvida para seguir a versão recente do .NET, pretende-se atender a todas as plataformas por ele antendidas, evitando instruções específicas que possam limitar seu uso apenas em Windows Desktop, como nas versões anteriores.
   
   Esta versão conta atualmente com uma quantidade maior de instruções sem plataforma específica, e foi estruturada para utilização dos recursos de Implantação e Entrega Contínua de aplicações (Azure DevOps).


## Documentação
![docs](https://eficazshields.azurewebsites.net/badge/docs-em%20construção-orange?style=flat-square)

   - [Sumário](/Docs/Api/EficazFrameworkSPED.md) 
     - Schemas
       - CT-e e CT-eOS
       - DAPI
       - e-CredAc, portarias CAT 83/09 e 207/09
       - e-Ressarcimento portaria CAT 42/18
       - ECD
       - ECF
       - [EFD ICMS / IPI](/Docs/Api/EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md)
       - EFD Contribuições
       - e-Social (em desenvolvimento)
       - GIA (SP)
       - GNRE
       - NF-e, a partir da versão 2.00
       - NFS-e   
       - [Livro Caixa Digital do Produtor Rural](/Docs/Api/EficazFramework.SPED.Schemas.LCDPR.md)
     - Classes complementares
       - [Abstrações](/Docs/Api/EficazFramework.SPED.Schemas.Primitives.md)
       - [Extensões](/Docs/Api/EficazFramework.SPED.Extensions.md)
       
## Exemplos de Uso

### Layouts baseados em arquivos de Texto (txt):

#### Leitura  
```csharp  
System.IO.Stream stream = System.IO.File.OpenRead(@"C:\SPED\SPED-EFD-ICMS-IPI.txt");  
EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
await escrituracao.LeArquivo(stream);  
```  
#### Escrita  
```csharp  
EficazFramework.SPED.Schemas.EFD_ICMS_IPI.Escrituracao escrituracao = new();  
escrituracao.Encoding = System.Text.Encoding.Default; //opcional  
escrituracao.Versao = "017"; //opcional  

var reg0000 = new Registro0000(null, escrituracao.Versao)  
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
escrituracao.Blocos["0"].Registros.Add(reg0000);  

// TODO: Adicionar demais registros em seus respectivos blocos...  

await escrituracao.EscreveArquivo(System.IO.File.Create(@"C:\SPED\SPED-EFD-ICMS-IPI.txt"));  
```
   
## Pré-Requisitos
.NET 6.0, para versão mais recente da biblioteca (pode sofrer alterações sem aviso prévio). Pretende-se acompanhar a versão em produção recente do .NET.

   
 ## Contribuições
   - Ficaremos felizes por receber contribuições visando enriquecer a qualidade do projeto, além de manter os schemas das escriturações sempre atualizado com os layouts definidos pelos agentes reguladores.
   - Por gentileza solicitamos a leitura das [Diretrizes de Contribuição](/CONTRIBUTING.md) antes de iniciar.
