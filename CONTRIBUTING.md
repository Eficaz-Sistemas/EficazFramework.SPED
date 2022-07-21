## Informações e Diretrizes para Contribuidores   
   Agradecemos pelo interesse em ajudar para que este projeto seja ainda melhor e seja útil para todos que precisam de alguma forma, gerar ou obter informações acerca dos arquivos eletrônicos envolvidos pelos projetos SPED, NF-e, CT-e, e-Social e afins.   

## Requisitos Mínimos para Compilar o Código-Fonte
 - [.NET 6.0 SDK](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) (Pode ser atualizado visando acompanhar a evolução do .NET)

## Pull Requests
 - Solicitamos que cada Pull Request aborde apenas um assunto/tópico, para que sua solicitação não corra risco de quebrar outras partes do código. Preferimos muitas PR's ao invés de uma única com muitas mudanças em várias partes diferentes.
 - É muito importante que, junto com o trecho modificado / incluído, exista também teste(s) de unidade para avaliar que a feature/fix esteja funcional.
 - O(s) teste(s) deve(m) passar.
 - Deve ser feita em uma branch específica para o trabalho, e seu nome deve ser sugestivo ao trabalho feito.
 - Pull Requests com longo tempo de vida, devem ser atualizadas com a branch master, utilizando git rebase ([Guia para efetuar Rebase](https://docs.github.com/pt/get-started/using-git/about-git-rebase)).
 - Para grandes mudanças, por gentileza inicie uma Issue antes, para um debate prévio acerca do assunto.
 - Caso inicie a Pull Request antes de concluir o trabalho, solicitamos convertê-la em Rascunho (Convert to Draft) até que a mesma seja concluída. Desta forma saberemos que não devemos mesclá-la antes do tempo;
 - Em caso de campos com uma lista de valores númericos, solicitamos criar um Enum contendo os valores válidos para tal.

[//]: # (## Estrutura do Projeto)


[//]: # (## Recomendações para evitar erros comuns)


## Testes de Unidade e Cobertura de Código
 - Este projeto visa alcançar 90% de cobertura de código, mas também gostaríamos de assegurar uma boa qualidade dos testes;
 - Temos plena consciência do grau de dificuldade para se alcançar tal percentual com tantos Registros e Campos por layout, desta forma pretendemos flexibilizar o objetivo quanto ao conteúdo já criado;
 - Solicitamos que cada nova Pull Request criada, contenha testes específicos para a feature adicionada ou modificada.
 
 ## Documentação
  - Iremos utilizar a biblioteca [DefaultDocumentation](https://github.com/Doraku/DefaultDocumentation) para gerar a Documentação em padrão Markdown, à partir do que for documentado nas classes, métodos e campos;
  - Toda colaboração na documentação do código será muito bem vinda;
  - Solicitamos por gentileza documentar as classes conforme a descrição de seus layouts, por exemplo, na EFD ICMS / IPI:
```csharp
/// <summary>
/// Documentos Fiscais (01, 1B, 04, 55 e 65)
/// </summary>
public class RegistroC100
{ 
    /// <summary>
    /// Indicador do tipo de operação: <br/>
    /// 0 - Entrada <br/>
    /// 1 - Saída <br/>
    /// </summary>
    public IndicadorOperacao Operacao { get; set; } = IndicadorOperacao.Entrada;
   
    /// <summary>
    /// Indicador do emitente do documento fiscal: <br/>
    /// 0 - Emissão Própria <br/>
    /// 1 - Terceiros <br/>
    /// </summary>
    public IndicadorEmitente Emissao { get; set; } = IndicadorEmitente.Propria;
    
    /// <summary>
    /// Código do participante (campo 02 do Registro 0150) <br/>
    /// </summary>
    public string CodigoParticipante { get; set; } = null;

}
```
