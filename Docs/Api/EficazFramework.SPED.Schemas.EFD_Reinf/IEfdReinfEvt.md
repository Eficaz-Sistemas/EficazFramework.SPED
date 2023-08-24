#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## IEvento Class

Interface padrão para implementação em todos os eventos da escrituração.
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Versao | `Versao` | <see cref="T:EficazFramework.SPED.Schemas.EFD_Reinf.Versao"/> do schema para leitura / escrita |
| TagToSign | `String` | Especifica qual Tag do XML do evento deve ser assinada por Certificado Digital |
| TagId | `String` | Retorna a ID do evento, criada pelo método <see cref="M:EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.GeraEventoID"/> |
| EmptyURI | `Boolean` | Informa se a Uri de referência da Tag assinada deve ser vazia, ou se deve ser formada conforme especificações do Manual Técnico. |
| SignAsSHA256 | `Boolean` | Informa se o XML deve ser assinado utilizando criptografia SHA256. |

| Methods | |
| :--- | :--- |
| [ContribuinteCNPJ()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/ContribuinteCNPJ().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.ContribuinteCNPJ()') | Retorna o CNPJ do Contribuinte titular do evento. |
| [DefineSerializer()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/DefineSerializer().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.DefineSerializer()') | Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando [IEvento](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento') |
| [Deserialize(string)](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/Deserialize(string).md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.Deserialize(string)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.Deserialize(System.IO.Stream)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [GeraEventoID()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/GeraEventoID().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.GeraEventoID()') | Gera uma ID única para o Evento a ser enviado para o portal do SPED.<br/>Cada tipo de evento da EFD-Reinf possui sua forma de geração. |
| [Serialize()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/Serialize().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.Serialize()') | Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML. |
| [ToString()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/ToString().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.ToString()') | Substitui o método ToString() de object para retornar o resultado do método [Serialize()](EficazFramework.SPED.Schemas.EFD_Reinf/IEvento/Serialize().md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEvento.Serialize()') |
