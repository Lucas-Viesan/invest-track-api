# 📈 InvestTrack API

API REST desenvolvida em **.NET 8** para gerenciamento de uma carteira de investimentos.

O projeto permite criar carteiras, cadastrar investimentos e consultar o patrimônio total da carteira por meio de uma propriedade calculada, aplicando regras de negócio para garantir a consistência dos dados.

## 🚀 Tecnologias

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- MySQL
- AutoMapper
- Swagger / OpenAPI

---

## 📂 Estrutura do Projeto

```
Controllers/
Services/
Dtos/
Models/
Context/
Profiles/
```

---

## 📊 Modelo de Dados

### Carteira

| Campo | Tipo |
|--------|------|
| Id | int |
| Nome | string |
| DataCriacao | DateTime |

### Investimento

| Campo | Tipo |
|--------|------|
| Id | int |
| NomeAtivo | string |
| Tipo | string |
| ValorAplicado | decimal |
| ValorAtual | decimal |
| DataCompra | DateTime |
| CarteiraId | int |

### Relacionamento

```
Carteira (1)
      │
      └─────────── (N) Investimentos
```

---

## 📋 Regras de Negócio

- Uma carteira não pode possuir dois investimentos com o mesmo ativo.
- O valor aplicado deve ser maior que zero.
- O valor atual nunca pode ser negativo.
- Uma carteira só pode ser excluída caso não possua investimentos associados.
- O valor total da carteira é calculado dinamicamente pela soma do `ValorAtual` de todos os investimentos e **não é armazenado no banco de dados**.

---

## 🔗 Endpoints

### Carteira

| Método | Endpoint | Descrição |
|---------|----------|-----------|
| POST | `/Carteira` | Cria uma nova carteira |
| GET | `/Carteira/{id}` | Retorna uma carteira pelo ID, incluindo seus investimentos e o valor total |
| DELETE | `/Carteira/{id}` | Exclui uma carteira caso não possua investimentos |

### Investimento

| Método | Endpoint | Descrição |
|---------|----------|-----------|
| POST | `/Investimento` | Cadastra um novo investimento |
| GET | `/Investimento/{id}` | Retorna um investimento pelo ID |
| PUT | `/Investimento/{id}` | Atualiza o valor atual do investimento |
| DELETE | `/Investimento/{id}` | Remove um investimento |

---

## ⚙️ Funcionamento

Ao cadastrar um investimento, a API:

- verifica se a carteira existe;
- impede ativos duplicados na mesma carteira;
- valida o valor aplicado;
- define automaticamente a data da compra;
- inicializa o `ValorAtual` com o valor aplicado.

Ao consultar uma carteira, o sistema calcula automaticamente o **ValorTotalCarteira**, somando o valor atual de todos os investimentos vinculados.

---

## ▶️ Como executar

1. Clone o repositório

```bash
git clone <url-do-repositorio>
```

2. Entre na pasta do projeto

```bash
cd InvestTrack
```

3. Configure a conexão com o banco de dados no arquivo `appsettings.json`.

4. Execute as migrations

```bash
dotnet ef database update
```

5. Inicie a aplicação

```bash
dotnet run
```

6. Acesse a documentação da API

```
https://localhost:{porta}/swagger
```

---

## 🎯 Objetivos de Aprendizado

Este projeto foi desenvolvido para praticar:

- ASP.NET Core Web API
- Entity Framework Core
- Relacionamentos entre entidades
- AutoMapper
- DTOs
- Arquitetura em camadas
- LINQ
- Operações assíncronas
- Aplicação de regras de negócio

---

## 🔮 Melhorias Futuras

- Listagem de carteiras e investimentos
- Paginação
- Filtros de consulta
- Middleware para tratamento global de exceções
- FluentValidation
- Autenticação com JWT
- Testes unitários
- Docker