#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade

### Remarks
Nível hierárquico - 0 <br/>  
Ocorrência - um por arquivo.
### Properties

| # | Name | Type | |
| ---: | :--- | :---: | :--- |
| 02 | Finalidade | `Finalidade` | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| 03 | DataInicial | `Nullable<DateTime>` | Data inicial das informações contidas no arquivo |
| 04 | DataFinal | `Nullable<DateTime>` | Data final das informações contidas no arquivo |
| 05 | RazaoSocial | `String` | Nome empresarial da entidade |
| 06 | CNPJ | `String` | Número de inscrição da entidade no CNPJ |
| 07 | CPF | `String` | Número de inscrição da entidade no CPF |
| 08 | UF | `String` | Sigla da unidade da federação da entidade |
| 09 | InscricaoEstadual | `String` | Inscrição Estadual da entidade |
| 10 | MunicipioCodigo | `String` | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| 11 | InscricaoMunicipal | `String` | Inscrição Municipal da entidade |
| 12 | InscricaoSuframa | `String` | Inscrição da entidade no Suframa |
| 13 | Perfil | `Perfil` | Perfil de apresentação do arquivo fiscal:  <br/>            A – Perfil A <br/>            B – Perfil B <br/>            C – Perfil C <br/> |
| 14 | Atividade | `TipoAtividade` | Indicador de tipo de atividade: <br/>            0 – Industrial ou equiparado a industrial  <br/>            1 – Outros  <br/> |
| 15 | Registro0001 | `Registro0001` | Propriedade de navegação para acesso ao Registro0001. <br/>            Setada automaticamente na leitura de arquivos.            Deve ser setada manualmente na construção do arquivo a ser escrito. |
| 16 | Registro0990 | `Registro0990` | Propriedade de navegação para acesso ao Registro0001. <br/>            Setada automaticamente na leitura de arquivos.            Deve ser setada manualmente na construção do arquivo a ser escrito. |
### Methods

| Name | Return Type | |
| :--- | :---: | :--- |
| EscreveLinha() | `String` | Herdado de Primitives.Registro.EscreveLinha() |
| LeParametros(string[]) | `Void` | Herdado de Primitives.Registro.LeParametros(string[] data) |
