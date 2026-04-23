# 🍔 GoodHamburger

API para gerenciamento de pedidos de uma lanchonete, desenvolvido com **.NET**, aplicando boas práticas de arquitetura e separação de responsabilidades.

---

## 🧱 Arquitetura

O projeto foi estruturado seguindo os princípios de **Clean Architecture**, com separação clara entre camadas:

- **Domain** → Entidades e regras de negócio  
- **Application** → Casos de uso e orquestração  
- **Infrastructure** → Persistência com EF Core + SQL Server  
- **API** → Backend com Minimal APIs

---

## 🚀 Tecnologias Utilizadas

- .NET / ASP.NET Core   
- Entity Framework Core  
- SQL Server  
- Minimal APIs  
- OpenAPI / Scalar  
- FluentValidation  

---

## 📦 Funcionalidades

- CRUD de pedidos  
- Cálculo automático de descontos:
  - 🥤 + 🍟 + 🍔 → 20%  
  - 🥤 + 🍔 → 15%  
  - 🍟 + 🍔 → 10%  
- Validação de regras de negócio (ex: itens duplicados)  
- Persistência com migrations  

---

## 🧮 Regras de Negócio

- Cada pedido pode conter:
  - 1 sanduíche  
  - 1 acompanhamento  
  - 1 bebida  
- Itens duplicados não são permitidos  
- Descontos são aplicados automaticamente conforme combinação  

---

## 🌐 API

A API foi construída com **Minimal APIs**, mantendo endpoints simples e performáticos.

### Exemplos:

- `GET /api/orders` → Lista pedidos  
- `POST /api/orders` → Cria pedido  
- `GET /api/orders/{id}` → Busca por ID  
- `DELETE /api/orders/{id}` → Remove pedido  

---

## 📄 Documentação

A documentação da API está disponível via:

- **OpenAPI**
- **Scalar UI**

## ▶️ Como executar

1. Configure a connection string no `appsettings.json`
2. Execute as migrations:

```bash
dotnet ef database update
```

Execute a API:

```bash
dotnet run --project GoodHamburger.API
```

🎯 Objetivo

Este projeto foi desenvolvido como desafio técnico, com foco em:

Organização de código
Boas práticas de arquitetura
Separação de responsabilidades
Clareza na implementação de regras de negócio

📌 Observações

Projetado para ser facilmente evoluído, permitindo:

inclusão de novos itens no cardápio
suporte a múltiplos clientes (mobile, web, etc.)
expansão das regras de negócio
