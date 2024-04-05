#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_Reinf](EficazFramework.SPED.Schemas.EFD_Reinf.md 'EficazFramework.SPED.Schemas.EFD_Reinf')

## EventoRetorno Class

Abstração padrão para implementação em todos os eventos de retorno (R-9001, R-9005, R-9011 e R-9015).
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| Versao | `Versao` | <see cref="T:EficazFramework.SPED.Schemas.EFD_Reinf.Versao"/> do schema para leitura / escrita |

| Methods | |
| :--- | :--- |
| [ContribuinteCNPJ()](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/ContribuinteCNPJ().md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.ContribuinteCNPJ()') | Retorna o CNPJ do Contribuinte titular do evento. |
| [DefineSerializer()](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/DefineSerializer().md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.DefineSerializer()') | Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando [Evento](EficazFramework.SPED.Schemas.EFD_Reinf/Evento.md 'EficazFramework.SPED.Schemas.EFD_Reinf.Evento') |
| [Read(string)](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/Read(string).md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.Read(string)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [Read(Stream)](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/Read(Stream).md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.Read(System.IO.Stream)') | Efetua a leitura do evento em XML e retorna uma instância do Evento/> |
| [ToString()](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/ToString().md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.ToString()') | Substitui o método ToString() de object para retornar o resultado do método [Serialize](https://docs.microsoft.com/en-us/dotnet/api/Serialize 'Serialize') |
| [Write()](EficazFramework.SPED.Schemas.EFD_Reinf/EventoRetorno/Write().md 'EficazFramework.SPED.Schemas.EFD_Reinf.EventoRetorno.Write()') | Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML. |
