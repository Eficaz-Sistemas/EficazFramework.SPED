#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.eSocial](EficazFramework.SPED.Schemas.eSocial.md 'EficazFramework.SPED.Schemas.eSocial')

## Evento Class

Abstração padrão para implementação em todos os eventos da escrituração.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Versao | `Versao` | <see cref="T:EficazFramework.SPED.Schemas.EFD_Reinf.Versao"/> do schema para leitura / escrita |
| TagToSign | `String` | Especifica qual Tag do XML do evento deve ser assinada por Certificado Digital |
| TagId | `String` | Retorna a ID do evento, criada pelo método <see cref="M:EficazFramework.SPED.Schemas.eSocial.Evento.GeraEventoID"/> |
| EmptyURI | `Boolean` | Informa se a Uri de referência da Tag assinada deve ser vazia, ou se deve ser formada conforme especificações do Manual Técnico. |
| SignAsSHA256 | `Boolean` | Informa se o XML deve ser assinado utilizando criptografia SHA256. |

| Methods | |
| :--- | :--- |
| [ContribuinteCNPJ()](EficazFramework.SPED.Schemas.eSocial/Evento/ContribuinteCNPJ().md 'EficazFramework.SPED.Schemas.eSocial.Evento.ContribuinteCNPJ()') | Retorna o CNPJ do Contribuinte titular do evento. |
| [DefineSerializer()](EficazFramework.SPED.Schemas.eSocial/Evento/DefineSerializer().md 'EficazFramework.SPED.Schemas.eSocial.Evento.DefineSerializer()') | Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando [Evento](EficazFramework.SPED.Schemas.eSocial/Evento.md 'EficazFramework.SPED.Schemas.eSocial.Evento') |
| [GeraEventoID()](EficazFramework.SPED.Schemas.eSocial/Evento/GeraEventoID().md 'EficazFramework.SPED.Schemas.eSocial.Evento.GeraEventoID()') | Gera uma ID única para o Evento a ser enviado para o portal do SPED.<br/>Cada tipo de evento da EFD-Reinf possui sua forma de geração. |
| [Read(string)](EficazFramework.SPED.Schemas.eSocial/Evento/Read(string).md 'EficazFramework.SPED.Schemas.eSocial.Evento.Read(string)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [Read(Stream)](EficazFramework.SPED.Schemas.eSocial/Evento/Read(Stream).md 'EficazFramework.SPED.Schemas.eSocial.Evento.Read(System.IO.Stream)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [ToString()](EficazFramework.SPED.Schemas.eSocial/Evento/ToString().md 'EficazFramework.SPED.Schemas.eSocial.Evento.ToString()') | Substitui o método ToString() de object para retornar o resultado do método [Serialize](https://docs.microsoft.com/en-us/dotnet/api/Serialize 'Serialize') |
| [Write()](EficazFramework.SPED.Schemas.eSocial/Evento/Write().md 'EficazFramework.SPED.Schemas.eSocial.Evento.Write()') | Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML. |
