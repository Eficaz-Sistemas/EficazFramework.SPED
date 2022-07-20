#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CTeRodoviario Class
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | RNTRC | `String` |  |
| 03 | DataPrevistaEntrega | `Nullable<DateTime>` |  |
| 04 | DataPrevistaEntregaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataPrevistaEntrega' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| 05 | lota | `rodoLota` |  |
| 06 | CIOT | `String` |  |
| 07 | occ | `ObservableCollection<rodoOcc>` |  |
| 08 | valePed | `ObservableCollection<rodoValePed>` |  |
| 09 | veic | `ObservableCollection<rodoVeic>` |  |
| 10 | lacRodo | `ObservableCollection<rodoLacRodo>` |  |
| 11 | moto | `ObservableCollection<rodoMoto>` |  |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| ShouldSerializeDataPrevistaEntregaXML() | `Boolean` |  |
| OnPropertyChanged(string) | `Void` |  |
| Serialize() | `String` | Serializes current TNfeProc object into an XML document |
| CanDeserialize(string, CTeRodoviario, Exception) | `Boolean` | Deserializes workflow markup into an TNfeProc object |
| CanDeserialize(string, CTeRodoviario) | `Boolean` |  |
| Deserialize(string) | `CTeRodoviario` |  |
| Deserialize(Stream) | `CTeRodoviario` |  |
| CanSaveToFile(Stream, Exception) | `Boolean` | Serializes current TNfeProc object into file |
| SaveTo(Stream) | `Void` |  |
| SaveToAsync(Stream) | `Void` |  |
| CanLoadFrom(Stream, CTeRodoviario, Exception) | `Boolean` | Deserializes xml markup from file into an TNfeProc object |
| CanLoadFrom(Stream, CTeRodoviario) | `Boolean` |  |
| LoadFrom(Stream) | `CTeRodoviario` |  |
| LoadFromAsync(Stream) | `Task<CTeRodoviario>` |  |
| LoadFromAsync(Stream, bool) | `Task<CTeRodoviario>` |  |
