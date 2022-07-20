#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CTeRodoviario Class
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | RNTRC |  |
| 03 | DataPrevistaEntrega |  |
| 04 | DataPrevistaEntregaXML | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataPrevistaEntrega' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 05 | lota |  |
| 06 | CIOT |  |
| 07 | occ |  |
| 08 | valePed |  |
| 09 | veic |  |
| 10 | lacRodo |  |
| 11 | moto |  |
### Methods

| Name | |
| :--- | :--- |
| ShouldSerializeDataPrevistaEntregaXML() |  |
| OnPropertyChanged(string) |  |
| Serialize() | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CTeRodoviario, Exception) | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTeRodoviario) |  |
| Deserialize(string) |  |
| Deserialize(Stream) |  |
| CanSaveToFile(Stream, Exception) | Serializes current TNfeProc object into file |
| SaveTo(Stream) |  |
| SaveToAsync(Stream) |  |
| CanLoadFrom(Stream, CTeRodoviario, Exception) | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTeRodoviario) |  |
| LoadFrom(Stream) |  |
| LoadFromAsync(Stream) |  |
| LoadFromAsync(Stream, bool) |  |
