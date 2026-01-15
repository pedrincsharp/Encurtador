# Encurtador de URLs

Projeto de **Encurtador de URLs** desenvolvido em **ASP.NET Core** utilizando **Minimal APIs**, seguindo uma arquitetura organizada em **Application**, **Infra** e **API**, com injeção de dependência e documentação via **Swagger/OpenAPI**.

O objetivo do projeto é permitir a criação de URLs curtas, redirecionamento para a URL original, listagem e remoção de URLs encurtadas.

---

## 🚀 Tecnologias Utilizadas

* .NET 10
* ASP.NET Core (Minimal API)
* Entity Framework Core
* InMemory Database (para ambiente de desenvolvimento)
* Swagger / OpenAPI
* Injeção de Dependência (DI)

---

## 📐 Arquitetura do Projeto

O projeto está organizado em camadas:

* **API**

  * Responsável por expor os endpoints HTTP
  * Configuração de rotas, Swagger e middlewares

* **Application**

  * Contém as regras de negócio
  * Serviços (`ISiteService`, `SiteService`)
  * DTOs e validações

* **Infra**

  * Persistência de dados
  * Repositórios (`ISiteRepository`, `SiteRepository`)
  * `DatabaseContext` com Entity Framework

---

## ⚙️ Configuração de Serviços

Os serviços são registrados no container de DI no `Program.cs`:

* Repositório e Service com ciclo de vida **Scoped**
* `DbContext` utilizando **InMemoryDatabase**
* OpenAPI habilitado para documentação

---

## 📌 Endpoints Disponíveis

### 🔗 Redirecionar URL

`GET /{shortCode}`

Redireciona o usuário para a URL original associada ao código curto.

* Retorna **404** caso o código não exista
* Utiliza **Redirect permanente (301)**

---

### ➕ Criar URL Encurtada

`POST /api/sites`

Cria uma nova URL encurtada.

**Parâmetro:**

* `url` (string) – URL original

**Resposta:**

* `201 Created` com os dados do site criado

---

### 📄 Listar URLs

`GET /api/sites`

Retorna todas as URLs encurtadas cadastradas.

---

### ❌ Remover URL

`DELETE /api/sites/{shortCode}`

Remove uma URL encurtada pelo código.

---

## 📊 Modelo de Dados

Cada URL encurtada possui as seguintes informações:

* ShortCode
* UrlOrigin
* UrlAccessCount
* CreatedAt

---

## 🧪 Documentação da API

O Swagger está disponível em ambiente de desenvolvimento:

```
/swagger
```

A documentação OpenAPI é exposta em:

```
/openapi/v1.json
```

---

## 🛠️ Execução do Projeto

1. Clone o repositório
2. Execute o projeto:

```bash
dotnet run
```

3. Acesse o Swagger no navegador

---

## 👨‍💻 Autor

Projeto desenvolvido como estudo e prática de Minimal APIs, arquitetura limpa e boas práticas em .NET.
