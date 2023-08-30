# <p align="center"> ![EficazFramework.SPED](Assets/GitHub-HeaderReadme.png)
# EficazFramework.SPED

![DotNet Versions](https://img.shields.io/static/v1?label=dotnet&message=6.0%20%7C%207.0&color=blueviolet&style=flat-square&logo=dotnet)
![Nuget](https://eficazshields.azurewebsites.net/nuget/v/EficazFramework.SPED?style=flat-square)
![Azure DevOps builds](https://eficazshields.azurewebsites.net/azure-devops/build/eficazcs/EficazFramework/21?&logo=azurepipelines&logoColor=white&style=flat-square)
![Azure DevOps tests (compact)](https://eficazshields.azurewebsites.net/azure-devops/tests/eficazcs/EficazFramework/21?compact_message&logo=azuredevops&logoColor=white&style=flat-square)
![Azure DevOps coverage](https://eficazshields.azurewebsites.net/azure-devops/coverage/eficazcs/EficazFramework/21?logo=codecov&logoColor=white&style=flat-square)
![Licence](https://img.shields.io/static/v1?label=licence&message=MIT&color=blue&style=flat-square&logo=github&logoColor=white)
[![Discord](https://eficazshields.azurewebsites.net/discord/846078359498653706?color=purple&logo=discord&logoColor=white&style=flat-square)](https://discord.gg/UrVkCB2Jms)
[![Twitter Follow](https://eficazshields.azurewebsites.net/twitter/follow/EficazCS?color=blue&label=twitter&logo=twitter&logoColor=white&style=flat-square)](https://twitter.com/EficazCS)
![EFD ICMS/IPI](https://eficazshields.azurewebsites.net/badge/EFD%20ICMS%2FIPI-v017-red?style=flat-square)
![EFD Contribuições](https://eficazshields.azurewebsites.net/badge/EFD%20Contribuições-v006-blue?style=flat-square)
![EFD-Reinf](https://eficazshields.azurewebsites.net/badge/EFD%20Reinf-v2.1.2.B-ff69b4?style=flat-square)
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
       - DAPI (MG)
       - e-CredAc, portarias CAT 83/09 e 207/09
       - e-Ressarcimento portaria CAT 42/18
       - ECD
       - ECF
       - [EFD ICMS / IPI](/Docs/Api/EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md)
       - EFD Contribuições
       - [EFD Reinf](/Docs/Api/EficazFramework.SPED.Schemas.EFD_Reinf.md)
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
### Layouts baseados em arquivos xml:

#### Leitura  
```csharp
using EficazFramework.SPED.Schemas.EFD_Reinf;

System.IO.Stream stream = System.IO.File.OpenRead(@"C:\SPED\SPED-EFD-REINF-EVT-R1000.xml");
var evento = new R1000()
{
    Versao = Versao.v2_01_02
};
evento.Read(stream);
stream.Dispose();
```
#### Escrita  
```csharp
using EficazFramework.SPED.Schemas.EFD_Reinf;

var evento = new R1000()
{
    Versao = Versao.v2_01_02,
    evtInfoContri = new R1000_EventoInfoContribuinte()
    {
        ideEvento = new IdentificacaoEvento()
        {
            tpAmb = Ambiente.ProducaoRestrita_DadosReais,
            procEmi = EmissorEvento.AppContribuinte,
            verProc = "2.2"
        },
        ideContri = new IdentificacaoContribuinte()
        {
            tpInsc = PersonalidadeJuridica.CNPJ,
            nrInsc = "12345678"
        },
        infoContri = new R1000EventoInfoContribuinte()
        {
            Item = new R1000Inclusao() // R1000Alteracao() ou R1000Exclusao()
            {
                idePeriodo = new IdentificacaoPeriodo()
                {
                    iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                },
                infoCadastro = new R1000InfoCadastro()
                {
                    classTrib = "99",
                    indEscrituracao = ObrigatoriedadeECD.EntregaECD,
                    indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
                    indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
                    indSitPJ = SituacaoPessoaJuridica.Normal,
                    indSitPJSpecified = true,
                    contato = new R1000InfoCadastroContato()
                    {
                        nmCtt = "Pierre de Fermat",
                        cpfCtt = "47363361886",
                        foneFixo = "3535441234",
                        email = "suporte@eficazcs.com.br"
                    },
                    softHouse = new R1000InfoCadastroSoftwareHouse()
                }
            }
        }
    }
};

var xmlString = evento.ToString();
System.IO.Stream stream = System.IO.File.Create(@"C:\SPED\SPED-EFD-REINF-EVT-R1000.xml");

// Escrita, opção 1:
System.Xml.XmlDocument doc = new();
doc.LoadXml(xmlString);
doc.Save(stream);

// Outra forma de escrita:
using (var writer = new System.IO.StreamWriter(stream, System.Text.Encoding.UTF8))
{
    await writer.WriteAsync(xmlString);
    await writer.FlushAsync();
    writer.Dispose();
}
```

## Pré-Requisitos
| Versão | Versão do .NET | Suporte |
| :--- | :--- | :---: |
| 6.1.x + | [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0); [.NET 7](https://dotnet.microsoft.com/en-us/download/dotnet/7.0) | :white_check_mark:|
| 6.0.x | [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0) | :x: |

   
 ## Contribuições
   - Ficaremos felizes por receber contribuições visando enriquecer a qualidade do projeto, além de manter os schemas das escriturações sempre atualizado com os layouts definidos pelos agentes reguladores.
   - Por gentileza solicitamos a leitura das [Diretrizes de Contribuição](/CONTRIBUTING.md) antes de iniciar.
