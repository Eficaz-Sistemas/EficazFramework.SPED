# Primitives (Classes Base e Abstrações)

As **Primitives** (`EficazFramework.SPED.Schemas.Primitives`) são as classes base, interfaces e enumerações que fornecem a fundação para todas as escriturações do projeto SPED suportadas pelo framework.

---

## 🏗️ Principais Abstrações de Layouts de Texto
O framework utiliza uma estrutura de classes herdadas para representar a hierarquia física dos arquivos texto do SPED:

### 1. `Escrituracao`
É a classe orquestradora principal. Cada obrigação fiscal em formato texto (como EFD ICMS/IPI, EFD Contribuições, LCDPR) possui uma classe derivada de `Escrituracao` que gerencia:
- O processo assíncrono de leitura (`LeArquivo`) e escrita (`EscreveArquivo`).
- O `Encoding` de leitura/gravação (geralmente Windows-1252/Default).
- A lista de `Blocos` contidos na escrituração.

### 2. `Bloco`
Representa um bloco físico do SPED (ex: Bloco 0, Bloco C, Bloco 9).
- Armazena uma lista ordenada de `Registro` na propriedade `Registros`.
- Controla o indicador de movimento do bloco (`IndicadorMovimento`).

### 3. `Registro`
Representa uma única linha física (um registro/registro-filho) no arquivo estruturado.
- Possui propriedades básicas como `Codigo` (ex: "0000", "C100"), `Versao` e metadados de preenchimento.
- Fornece métodos abstratos herdados pelas classes de cada registro para:
  - Desserializar parâmetros a partir de uma linha lida (`LeParametros`).
  - Serializar as propriedades internas de volta para o formato de linha do SPED (`EscreveLinha` / `ToString`).

---

## 🔑 Enumerações Base
O namespace contém enums genéricas usadas por múltiplos schemas:

*   **`Finalidade`**: Define a finalidade da escrituração:
    - `Original = 0` (Remessa de arquivo original)
    - `Substituto = 1` (Remessa de arquivo substituto/retificador)
*   **`TipoAtividade`**: Indicador do tipo de atividade do estabelecimento:
    - `Industrial = 0` (Industrial ou equiparado a industrial)
    - `Outros = 1`
*   **`IndicadorMovimento`**: Status de preenchimento de blocos ou seções:
    - `ComDados = 0`
    - `SemDados = 1`
