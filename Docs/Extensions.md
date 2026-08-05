# Extensions (Métodos de Extensão)

As **Extensions** (`EficazFramework.SPED.Extensions`) fornecem um conjunto de métodos utilitários estendidos para tipos nativos do .NET (`string`, `DateTime`, números, XML), facilitando a conversão, formatação e validação de dados comuns em escriturações fiscais.

---

## 🔡 Extensões de String (`string`)
Oferecem facilidades de parsing de datas, formatação de documentos (CPF, CNPJ, IE) e limpeza de strings:

*   **`ToDate()`**: Converte strings no formato do SPED (`DDMMAAAA`) ou Sintegra de volta para um objeto `DateTime?`.
*   **Formatações Fiscais**: Conversão rápida de strings cruas para formatos com máscara (ex: aplicar máscaras de CNPJ, CPF, CEP, etc.).
*   **Limpeza de Caracteres**: Métodos para remover pontuações e caracteres especiais, preparando dados para gravação de acordo com regras de validação do governo.

---

## 📅 Extensões de Data (`DateTime`)
Facilitam a escrita de datas no formato exigido pelos layouts:

*   **`ToSpedString()`**: Converte um objeto `DateTime` na string padrão exigida pelo SPED (`DDMMAAAA`).
*   **`ToSintegraString()`**: Formata datas de acordo com os padrões específicos do Sintegra.
*   **`ToXmlString()`**: Formata datas no padrão exigido pelos Schemas XML de documentos eletrônicos (ex: NF-e, eSocial, EFD-Reinf).

---

## 🧮 Extensões de Números e Financeiro
Apoiam a formatação de valores monetários, alíquotas e quantidades de forma alinhada com as regras de casas decimais do SPED:

*   **Formatação de Valores**: Conversão de `double`, `decimal` e `float` para strings com a quantidade exata de casas decimais (ex: 2 casas para valores monetários, 3 ou mais para quantidades).
*   **Limpeza e Conversão**: Conversão segura de strings com vírgulas ou pontos para tipos numéricos (`ToDecimal`, `ToDouble`).
