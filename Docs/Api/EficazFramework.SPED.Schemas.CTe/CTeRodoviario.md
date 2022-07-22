#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.CTe](EficazFramework.SPED.Schemas.CTe.md 'EficazFramework.SPED.Schemas.CTe')

## CTeRodoviario Class
### Properties

| Name | Type | |
| :--- | :---: | :--- |
| RNTRC | `String` |  |
| DataPrevistaEntrega | `Nullable<DateTime>` |  |
| DataPrevistaEntregaXML | `String` | Campo em formato string para escrita do XML no padrão exigido pela NF-e            Utilize o campo 'DataPrevistaEntrega' (Date?) para trabalho. Ambos estarão            automaticamente em sincronia |
| lota | `rodoLota` |  |
| CIOT | `String` |  |
| occ | `ObservableCollection<rodoOcc>` |  |
| valePed | `ObservableCollection<rodoValePed>` |  |
| veic | `ObservableCollection<rodoVeic>` |  |
| lacRodo | `ObservableCollection<rodoLacRodo>` |  |
| moto | `ObservableCollection<rodoMoto>` |  |

| Methods | |
| :--- | :--- |
| [CanDeserialize(string, CTeRodoviario)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/CanDeserialize(string,CTeRodoviario).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.CanDeserialize(string, EficazFramework.SPED.Schemas.CTe.CTeRodoviario)') | |
| [CanDeserialize(string, CTeRodoviario, Exception)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/CanDeserialize(string,CTeRodoviario,Exception).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.CanDeserialize(string, EficazFramework.SPED.Schemas.CTe.CTeRodoviario, System.Exception)') | Deserializes workflow markup into an TNfeProc object |
| [CanLoadFrom(Stream, CTeRodoviario)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/CanLoadFrom(Stream,CTeRodoviario).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.CTe.CTeRodoviario)') | |
| [CanLoadFrom(Stream, CTeRodoviario, Exception)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/CanLoadFrom(Stream,CTeRodoviario,Exception).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.CanLoadFrom(System.IO.Stream, EficazFramework.SPED.Schemas.CTe.CTeRodoviario, System.Exception)') | Deserializes xml markup from file into an TNfeProc object |
| [CanSaveToFile(Stream, Exception)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/CanSaveToFile(Stream,Exception).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.CanSaveToFile(System.IO.Stream, System.Exception)') | Serializes current TNfeProc object into file |
| [Deserialize(string)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/Deserialize(string).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.Deserialize(string)') | |
| [Deserialize(Stream)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/Deserialize(Stream).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.Deserialize(System.IO.Stream)') | |
| [LoadFrom(Stream)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/LoadFrom(Stream).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.LoadFrom(System.IO.Stream)') | |
| [LoadFromAsync(Stream)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/LoadFromAsync(Stream).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.LoadFromAsync(System.IO.Stream)') | |
| [LoadFromAsync(Stream, bool)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/LoadFromAsync(Stream,bool).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.LoadFromAsync(System.IO.Stream, bool)') | |
| [OnPropertyChanged(string)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/OnPropertyChanged(string).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.OnPropertyChanged(string)') | |
| [SaveTo(Stream)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/SaveTo(Stream).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.SaveTo(System.IO.Stream)') | |
| [SaveToAsync(Stream)](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/SaveToAsync(Stream).md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.SaveToAsync(System.IO.Stream)') | |
| [Serialize()](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/Serialize().md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.Serialize()') | Serializes current TNfeProc object into an XML document |
| [ShouldSerializeDataPrevistaEntregaXML()](EficazFramework.SPED.Schemas.CTe/CTeRodoviario/ShouldSerializeDataPrevistaEntregaXML().md 'EficazFramework.SPED.Schemas.CTe.CTeRodoviario.ShouldSerializeDataPrevistaEntregaXML()') | |
