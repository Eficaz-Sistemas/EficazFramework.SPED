#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')

## EficazFramework.SPED.Schemas Namespace
### Interfaces

<a name='EficazFramework.SPED.Schemas.IXmlSignableDocument'></a>

## IXmlSignableDocument Interface

```csharp
public interface IXmlSignableDocument
```

Derived  
&#8627; [IEfdReinfEvt](EficazFramework.SPED.Schemas.EFD_Reinf/IEfdReinfEvt.md 'EficazFramework.SPED.Schemas.EFD_Reinf.IEfdReinfEvt')
### Properties

<a name='EficazFramework.SPED.Schemas.IXmlSignableDocument.EmptyURI'></a>

## IXmlSignableDocument.EmptyURI Property

```csharp
bool EmptyURI { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.SPED.Schemas.IXmlSignableDocument.SignAsSHA256'></a>

## IXmlSignableDocument.SignAsSHA256 Property

```csharp
bool SignAsSHA256 { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='EficazFramework.SPED.Schemas.IXmlSignableDocument.TagId'></a>

## IXmlSignableDocument.TagId Property

```csharp
string TagId { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Schemas.IXmlSignableDocument.TagToSign'></a>

## IXmlSignableDocument.TagToSign Property

```csharp
string TagToSign { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Schemas.IXmlSpedDocument'></a>

## IXmlSpedDocument Interface

```csharp
public interface IXmlSpedDocument
```

Derived  
&#8627; [CTe](EficazFramework.SPED.Schemas.CTe/CTe.md 'EficazFramework.SPED.Schemas.CTe.CTe')  
&#8627; [Evento](EficazFramework.SPED.Schemas.CTe/Evento.md 'EficazFramework.SPED.Schemas.CTe.Evento')  
&#8627; [EventoConfEntregaCTe](EficazFramework.SPED.Schemas.CTe/EventoConfEntregaCTe.md 'EficazFramework.SPED.Schemas.CTe.EventoConfEntregaCTe')  
&#8627; [LoteCte](EficazFramework.SPED.Schemas.CTe/LoteCte.md 'EficazFramework.SPED.Schemas.CTe.LoteCte')  
&#8627; [ProcessoCTe](EficazFramework.SPED.Schemas.CTe/ProcessoCTe.md 'EficazFramework.SPED.Schemas.CTe.ProcessoCTe')  
&#8627; [ProcessoEvento](EficazFramework.SPED.Schemas.CTe/ProcessoEvento.md 'EficazFramework.SPED.Schemas.CTe.ProcessoEvento')  
&#8627; [CTeOS](EficazFramework.SPED.Schemas.CTeOS/CTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.CTeOS')  
&#8627; [ProcessoCTeOS](EficazFramework.SPED.Schemas.CTeOS/ProcessoCTeOS.md 'EficazFramework.SPED.Schemas.CTeOS.ProcessoCTeOS')  
&#8627; [NFe](EficazFramework.SPED.Schemas.NFe/NFe.md 'EficazFramework.SPED.Schemas.NFe.NFe')  
&#8627; [ProcessoEvento](EficazFramework.SPED.Schemas.NFe/ProcessoEvento.md 'EficazFramework.SPED.Schemas.NFe.ProcessoEvento')  
&#8627; [ProcessoInutilizacaoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoInutilizacaoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoInutilizacaoNFe')  
&#8627; [ProcessoNFe](EficazFramework.SPED.Schemas.NFe/ProcessoNFe.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFe')  
&#8627; [ProcessoNFeBase](EficazFramework.SPED.Schemas.NFe/ProcessoNFeBase.md 'EficazFramework.SPED.Schemas.NFe.ProcessoNFeBase')  
&#8627; [ResumoEvento](EficazFramework.SPED.Schemas.NFe/ResumoEvento.md 'EficazFramework.SPED.Schemas.NFe.ResumoEvento')  
&#8627; [RetornoEnvioEvento](EficazFramework.SPED.Schemas.NFe/RetornoEnvioEvento.md 'EficazFramework.SPED.Schemas.NFe.RetornoEnvioEvento')  
&#8627; [RetornoNFeNormal](EficazFramework.SPED.Schemas.NFe/RetornoNFeNormal.md 'EficazFramework.SPED.Schemas.NFe.RetornoNFeNormal')  
&#8627; [ConsultarNFseResposta](EficazFramework.SPED.Schemas.NFSe.ABRASF/ConsultarNFseResposta.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.ConsultarNFseResposta')  
&#8627; [tcCompNfse](EficazFramework.SPED.Schemas.NFSe.ABRASF/tcCompNfse.md 'EficazFramework.SPED.Schemas.NFSe.ABRASF.tcCompNfse')  
&#8627; [ConsultarRpsResposta](EficazFramework.SPED.Schemas.NFSe.BETHA/ConsultarRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.BETHA.ConsultarRpsResposta')  
&#8627; [NFSe](EficazFramework.SPED.Schemas.NFSe.Common/NFSe.md 'EficazFramework.SPED.Schemas.NFSe.Common.NFSe')  
&#8627; [tcComplNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcComplNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcComplNfse')  
&#8627; [tcCompNfse](EficazFramework.SPED.Schemas.NFSe.Common/tcCompNfse.md 'EficazFramework.SPED.Schemas.NFSe.Common.tcCompNfse')  
&#8627; [ConsultarLoteRpsResposta](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta')  
&#8627; [ConsultarLoteRpsResposta2](EficazFramework.SPED.Schemas.NFSe.GINFES/ConsultarLoteRpsResposta2.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.ConsultarLoteRpsResposta2')  
&#8627; [EnviarLoteRpsEnvio](EficazFramework.SPED.Schemas.NFSe.GINFES/EnviarLoteRpsEnvio.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.EnviarLoteRpsEnvio')  
&#8627; [tcListaNfse](EficazFramework.SPED.Schemas.NFSe.GINFES/tcListaNfse.md 'EficazFramework.SPED.Schemas.NFSe.GINFES.tcListaNfse')  
&#8627; [CancelamentoCFe](EficazFramework.SPED.Schemas.SAT_CFe/CancelamentoCFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CancelamentoCFe')  
&#8627; [CFe](EficazFramework.SPED.Schemas.SAT_CFe/CFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.CFe')  
&#8627; [envCFe](EficazFramework.SPED.Schemas.SAT_CFe/envCFe.md 'EficazFramework.SPED.Schemas.SAT_CFe.envCFe')
### Properties

<a name='EficazFramework.SPED.Schemas.IXmlSpedDocument.Chave'></a>

## IXmlSpedDocument.Chave Property

Chave única do Documento Fiscal

```csharp
string Chave { get; }
```

#### Property Value
[System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

<a name='EficazFramework.SPED.Schemas.IXmlSpedDocument.DataEmissao'></a>

## IXmlSpedDocument.DataEmissao Property

Data de Emissão do Documento Fiscal

```csharp
System.Nullable<System.DateTime> DataEmissao { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.DateTime](https://docs.microsoft.com/en-us/dotnet/api/System.DateTime 'System.DateTime')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='EficazFramework.SPED.Schemas.IXmlSpedDocument.DocumentType'></a>

## IXmlSpedDocument.DocumentType Property

Retorna o tipo de Documento (NFe, CTe, etc) para permitir o cast correto.

```csharp
EficazFramework.SPED.Schemas.XmlDocumentType DocumentType { get; }
```

#### Property Value
[XmlDocumentType](EficazFramework.SPED.Schemas/XmlDocumentType.md 'EficazFramework.SPED.Schemas.XmlDocumentType')

| Enums | |
| :--- | :--- |
| [XmlDocumentType](EficazFramework.SPED.Schemas/XmlDocumentType.md 'EficazFramework.SPED.Schemas.XmlDocumentType') | |
