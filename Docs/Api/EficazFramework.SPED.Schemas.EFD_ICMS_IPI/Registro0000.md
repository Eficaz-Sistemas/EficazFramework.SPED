#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')
### [EficazFramework.SPED.Schemas.EFD_ICMS_IPI](EficazFramework.SPED.Schemas.EFD_ICMS_IPI.md 'EficazFramework.SPED.Schemas.EFD_ICMS_IPI')

## Registro0000 Class

Abertura do Arquivo Digital e Identificação da entidade

### Remarks
Nível hierárquico - 0 <br/>  
Ocorrência - um por arquivo.
### Properties

| # | Name | |
| ---: | :--- | :--- |
| 02 | Finalidade | Código da finalidade do arquivo: <br/>            0 - Remessa do arquivo original <br/>            1 - Remessa do arquivo substituto <br/> |
| 03 | DataInicial | Data inicial das informações contidas no arquivo |
| 04 | DataFinal | Data final das informações contidas no arquivo |
| 05 | RazaoSocial | Nome empresarial da entidade |
| 06 | CNPJ | Número de inscrição da entidade no CNPJ |
| 07 | CPF | Número de inscrição da entidade no CPF |
| 08 | UF | Sigla da unidade da federação da entidade |
| 09 | InscricaoEstadual | Inscrição Estadual da entidade |
| 10 | MunicipioCodigo | Código do município do domicílio fiscal da entidade, conforme a tabela IBGE |
| 11 | InscricaoMunicipal | Inscrição Municipal da entidade |
| 12 | InscricaoSuframa | Inscrição da entidade no Suframa |
| 13 | Perfil | Perfil de apresentação do arquivo fiscal:  <br/>            A – Perfil A <br/>            B – Perfil B <br/>            C – Perfil C <br/> |
| 14 | Atividade | Indicador de tipo de atividade: <br/>            0 – Industrial ou equiparado a industrial  <br/>            1 – Outros  <br/> |
| 15 | Registro0001 |  |
| 16 | Registro0990 |  |
### Methods

| Name | |
| :--- | :--- |
| EscreveLinha() |  |
| LeParametros(string[]) |  |
