# Recepciona a DPS e Gera a NFS-e de forma síncrona.

## `POST` /nfse

Request Body schema: application/json  
Estrutura contendo um DPS compactado no padrão gZip (base64Binary)

## Body
| Campo | Tipo | Required | Descrição |
|---|---|:---:|---|
| dpsXmlGZipB64 | `string` | ✅ | DPS compactado no padrão gZip (base64Binary) |

## Payload 
application/json
```json
{
  "dpsXmlGZipB64": "string"
}
```

## Response samples
### 201 
A NFS-e foi criada com sucesso
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "idDps": "string",
  "chaveAcesso": "string",
  "nfseXmlGZipB64": "string",
  "alertas": [
    {
      "codigo": "string",
      "descricao": "string",
      "complemento": "string"
    }
  ]
}
```

### 400 
Não foi possível criar a NFS-e
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "idDPS": "string",
  "erros": [
    {
      "codigo": "string",
      "descricao": "string",
      "complemento": "string"
    }
  ]
}
```

### 403 
Certificado digital da transmissão inválido ou fora dos padrões da NFS-e
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "idDPS": "string",
  "erros": [
    {
      "codigo": "string",
      "descricao": "string",
      "complemento": "string"
    }
  ]
}
```

### 500 
Falha durante o processamento do DPS
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "idDPS": "string",
  "erros": [
    {
      "codigo": "string",
      "descricao": "string",
      "complemento": "string"
    }
  ]
}
```

---

# Retorna a NFS-e a partir da consulta pela chave de acesso correspondente (50 posições).

## `GET` /nfse/{chaveAcesso}

## Request Parameters
| Campo | Tipo | Required | Descrição |
|---|---|:---:|---|
| chaveAcesso | `string` | ✅ | Chave de acesso da NFS-e (50 posições) |

## Response samples
### 200
NFS-e encontrada
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "chaveAcesso": "string",
  "nfseXmlGZipB64": "string"
}
```

### 400 
A chave de acesso consultada deve conter 50 números.
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```

### 401
Não foi possível obter o certificado de cliente.
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```

### 403
Consulta desta NFS-e não é permitida para este usuário.
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```

### 404
Chave de acesso não encontrada.
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```


---

# Retorna a chave de acesso da NFS-e a partir do identificador do DPS.

## `GET` /dps/{id}

## Request Parameters
| Campo | Tipo | Required | Descrição |
|---|---|:---:|---|
| id | `string` | ✅ | Identificador do DPS |

## Response samples
### 200
Foi gerada uma NFS-e com o identificador de DPS informado
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "idDps": "string",
  "chaveAcesso": "string"
}
```

### 400 
Identificador de DPS inválido
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```

### 404
Não foi gerada uma NFS-e com o identificador de DPS informado
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```



---

# Retorna o Documento Fiscal de Serviço correspondenente ao NSU informado

## `GET` /DFe/{NSU}

## Path Parameters
| Campo | Tipo | Required | Descrição |
|---|---|:---:|---|
| NSU | `string` | ✅ | Número de Sequência Única do Documento Fiscal de Serviço |

## Query Parameters
| Campo | Tipo | Descrição |
|---|:---:|---|
| cnpjConsulta | `string` | CNPJ da empresa consultada |
| lote | `boolean` | Indica se a consulta é para um lote de documentos |


## Response samples
### 200
```json
{
  "StatusProcessamento": "REJEICAO",
  "LoteDFe": [
    {
      "NSU": 0,
      "ChaveAcesso": "string",
      "TipoDocumento": "NENHUM",
      "TipoEvento": "CANCELAMENTO",
      "ArquivoXml": "string",
      "DataHoraGeracao": "2019-08-24T14:15:22Z"
    }
  ],
  "Alertas": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "Erros": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "TipoAmbiente": "PRODUCAO",
  "VersaoAplicativo": "string",
  "DataHoraProcessamento": "2019-08-24T14:15:22Z"
}
```

### 400 
Identificador de DPS inválido
```json
{
  "tipoAmbiente": 1,
  "versaoAplicativo": "string",
  "dataHoraProcessamento": "2026-09-23T09:25:15.5845456-03:00",
  "erro": {
    "codigo": "string",
    "descricao": "string",
    "complemento": "string"
  }
}
```

### 400
```json
{
  "StatusProcessamento": "REJEICAO",
  "LoteDFe": [
    {
      "NSU": 0,
      "ChaveAcesso": "string",
      "TipoDocumento": "NENHUM",
      "TipoEvento": "CANCELAMENTO",
      "ArquivoXml": "string",
      "DataHoraGeracao": "2019-08-24T14:15:22Z"
    }
  ],
  "Alertas": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "Erros": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "TipoAmbiente": "PRODUCAO",
  "VersaoAplicativo": "string",
  "DataHoraProcessamento": "2019-08-24T14:15:22Z"
}
```




### 404
```json
{
  "StatusProcessamento": "REJEICAO",
  "LoteDFe": [
    {
      "NSU": 0,
      "ChaveAcesso": "string",
      "TipoDocumento": "NENHUM",
      "TipoEvento": "CANCELAMENTO",
      "ArquivoXml": "string",
      "DataHoraGeracao": "2019-08-24T14:15:22Z"
    }
  ],
  "Alertas": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "Erros": [
    {
      "Mensagem": {},
      "Parametros": [
        "string"
      ],
      "Codigo": "string",
      "Descricao": "string",
      "Complemento": "string"
    }
  ],
  "TipoAmbiente": "PRODUCAO",
  "VersaoAplicativo": "string",
  "DataHoraProcessamento": "2019-08-24T14:15:22Z"
}
```



