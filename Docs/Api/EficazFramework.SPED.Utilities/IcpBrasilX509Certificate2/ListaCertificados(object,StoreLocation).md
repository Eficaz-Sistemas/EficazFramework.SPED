#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Utilities](EficazFramework.SPED.Utilities.md 'EficazFramework.SPED.Utilities').[IcpBrasilX509Certificate2](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2.md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2')

## IcpBrasilX509Certificate2.ListaCertificados(object, StoreLocation) Method

Obtém a lista de Certificados Digitais hospedadas no Repositório do Navegador, no padrao ICP-Brasil.

```csharp
public static System.Collections.Generic.List<EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2> ListaCertificados(object filtro, System.Security.Cryptography.X509Certificates.StoreLocation storeLocation);
```
#### Parameters

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.ListaCertificados(object,System.Security.Cryptography.X509Certificates.StoreLocation).filtro'></a>

`filtro` [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object')

Especifica algum critério para filtragem. Opcional.

<a name='EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2.ListaCertificados(object,System.Security.Cryptography.X509Certificates.StoreLocation).storeLocation'></a>

`storeLocation` [System.Security.Cryptography.X509Certificates.StoreLocation](https://docs.microsoft.com/en-us/dotnet/api/System.Security.Cryptography.X509Certificates.StoreLocation 'System.Security.Cryptography.X509Certificates.StoreLocation')

Determina se será pesquisado no Rpositório Global ou no Repositório do Usuário Logado.

#### Returns
[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[IcpBrasilX509Certificate2](EficazFramework.SPED.Utilities/IcpBrasilX509Certificate2.md 'EficazFramework.SPED.Utilities.IcpBrasilX509Certificate2')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')