---
name: Mapeamento de Evento do e-Social
about: Use este template para iniciar uma issue do tipo Enhancement para eventos que devem ser mapeados nos Schemas do e-Social.
title: "[e-Social] Evento <evtID>, versão S-1.3"
labels: ["product-quality", "evt"]
assignees: []
---

### Proposta desta issue: 
- [ ] ➕ Criar a classe <evtID> em `./src/Core/EficazFramework.SPED.Schemas/e-Social/<evtID>.cs` para conforme layout <version> vigente
          Considerar o respectivo arquivo XSD disponível na [Documentação Técnica](https://www.gov.br/esocial/pt-br/documentacao-tecnica/leiautes-esocial-versao-s-1-3-nt-06-2026-rev-09-04-2026/index.html);
- [ ] 🔗 Assegurar compatibilidade com versões anteriores, visando futura feature de Importação de dados;
- [ ] 🧪 Criar testes unitários de leitura/escrita em diferentes versões.
