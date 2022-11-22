#### [EficazFramework.SPED](EficazFrameworkSPED.md 'EficazFramework SPED')

## EficazFramework.SPED.Schemas.LCDPR Namespace

# Livro Caixa Digital do Produtor Rural (LCDPR)<br/>  
## Publico Alvo<br/>  
 - Produtor Rural Pessoa Física<br/>  
 - Faturamento Anual acima de R$ 4,8 milhões de reais<br/>  
## Guia<br/>  
Obrigação Assessória de competência do Produtor Rural, que visa esclarecer para a Receita Federal as suas movimentações (Receitas x Despesas), quando a Renda Bruta do ano-calendário ultrapassar o limite até R$4,8 milhões de reais. <br/>  
Foi implementada pela Instrução Normativa n° 1848, de 28 de Novembro de 2018.<br/>  
## Objetivo<br/>  
Tornar o cumprimento das obrigações fiscais do produtor rural, obrigatoriamente, pessoa física, mais transparentes e claros, agilizando o processo por meio da digitalização.<br/>  
## Links Úteis<br/>  
- [Manual de Preenchimento, v1.3](https://www.gov.br/receitafederal/pt-br/assuntos/orientacao-tributaria/declaracoes-e-demonstrativos/lcdpr-livro-caixa-digital-do-produtor-rural/manual-de-preenchimento-do-lcdpr-1-3)<br/>  
- [Perguntas e Respostas](https://www.gov.br/receitafederal/pt-br/centrais-de-conteudo/publicacoes/perguntas-e-respostas/perguntas-e-respostas-lcdpr/Perguntas-Respostas-LCDPR)<br/>  
## Implementação<br/>

| Classes | |
| :--- | :--- |
| [Escrituracao](EficazFramework.SPED.Schemas.LCDPR/Escrituracao.md 'EficazFramework.SPED.Schemas.LCDPR.Escrituracao') | Classe principal de configuração, leitura e escrita do Livro Caixa Digital do Produtor Rural |
| [Registro0000](EficazFramework.SPED.Schemas.LCDPR/Registro0000.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0000') | Abertura do Arquivo Digital e Identificação da Pessoa Física |
| [Registro0010](EficazFramework.SPED.Schemas.LCDPR/Registro0010.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0010') | Parâmetros de Tributação |
| [Registro0030](EficazFramework.SPED.Schemas.LCDPR/Registro0030.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0030') | Dados Cadastrais |
| [Registro0040](EficazFramework.SPED.Schemas.LCDPR/Registro0040.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0040') | Cadastro dos Imóveis Rurais |
| [Registro0045](EficazFramework.SPED.Schemas.LCDPR/Registro0045.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0045') | Cadastro de Terceiros |
| [Registro0050](EficazFramework.SPED.Schemas.LCDPR/Registro0050.md 'EficazFramework.SPED.Schemas.LCDPR.Registro0050') | Cadastro das Contas Bancárias do Produtor Rural |
| [Registro9999](EficazFramework.SPED.Schemas.LCDPR/Registro9999.md 'EficazFramework.SPED.Schemas.LCDPR.Registro9999') | Identificação do Signatário do LCDPR e Encerramento do Arquivo Digital |
| [RegistroQ100](EficazFramework.SPED.Schemas.LCDPR/RegistroQ100.md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ100') | Demonstração da Atividade Rural |
| [RegistroQ200](EficazFramework.SPED.Schemas.LCDPR/RegistroQ200.md 'EficazFramework.SPED.Schemas.LCDPR.RegistroQ200') | Resumo Mensal do Demonstrativo do Resultado da Atividade Rural |

| Enums | |
| :--- | :--- |
| [FormaApuracao](EficazFramework.SPED.Schemas.LCDPR/FormaApuracao.md 'EficazFramework.SPED.Schemas.LCDPR.FormaApuracao') | Forma de Apuração do Lucro da Atividade Rural. |
| [SituacaoEspecial](EficazFramework.SPED.Schemas.LCDPR/SituacaoEspecial.md 'EficazFramework.SPED.Schemas.LCDPR.SituacaoEspecial') | Situação especial do Declarante |
| [SituacaoInicioPeriodo](EficazFramework.SPED.Schemas.LCDPR/SituacaoInicioPeriodo.md 'EficazFramework.SPED.Schemas.LCDPR.SituacaoInicioPeriodo') | Situação do Declarante no Início do Período da Escrituração quanto a início de atividades, ou obrigatoriedade no curso do ano-calendário. |
| [TipoDocumento](EficazFramework.SPED.Schemas.LCDPR/TipoDocumento.md 'EficazFramework.SPED.Schemas.LCDPR.TipoDocumento') | Tipo de Documento do Lançamento Fiscal (NF, Recibo, etc). |
| [TipoExploracao](EficazFramework.SPED.Schemas.LCDPR/TipoExploracao.md 'EficazFramework.SPED.Schemas.LCDPR.TipoExploracao') | Situação da exploração, relativo a individual ou coletiva. |
| [TipoExploracaoTerceiro](EficazFramework.SPED.Schemas.LCDPR/TipoExploracaoTerceiro.md 'EficazFramework.SPED.Schemas.LCDPR.TipoExploracaoTerceiro') | Formato de Participação dos demais sócios / terceiros quanto à exploração coletiva do Imóvel Rural. |
| [TipoLancamento](EficazFramework.SPED.Schemas.LCDPR/TipoLancamento.md 'EficazFramework.SPED.Schemas.LCDPR.TipoLancamento') | Natureza do Lançamento (Receita / Despesa). |
