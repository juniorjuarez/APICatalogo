# Catálogo de Produtos API

## Sobre o Projeto

[cite\_start]A **Catálogo de Produtos API** é um projeto desenvolvido em ASP.NET Core 8 [cite: 1] com o objetivo de criar um catálogo de produtos e suas respectivas categorias. Esta API RESTful permite realizar operações de CRUD (Criar, Ler, Atualizar e Deletar) tanto para produtos quanto para categorias.

Este projeto foi criado como parte de um estudo pessoal para aprimorar conhecimentos em desenvolvimento de APIs com as tecnologias mais recentes do ecossistema .NET.

## Tecnologias Utilizadas

- [cite\_start]**.NET 8** [cite: 1]
- **ASP.NET Core Web API**
- **Entity Framework Core 9**
- [cite\_start]**Swagger/OpenAPI** [cite: 1] para documentação e teste de endpoints
- **SQLite** como banco de dados

## Funcionalidades

- **Gestão de Produtos:**

  - Listar todos os produtos
  - Buscar um produto específico por ID
  - Adicionar um novo produto
  - Atualizar as informações de um produto existente
  - Remover um produto

- **Gestão de Categorias:**

  - Listar todas as categorias
  - Buscar uma categoria específica por ID
  - Listar todas as categorias com seus respectivos produtos
  - Adicionar uma nova categoria
  - Atualizar as informações de uma categoria existente
  - Remover uma categoria

## Estrutura dos Dados

### Produto

| Campo          | Tipo de Dado    | Restrições        |
| :------------- | :-------------- | :---------------- |
| `ProdutoId`    | `int`           | Chave Primária    |
| `Nome`         | `string(80)`    | Obrigatório       |
| `Descricao`    | `string(300)`   | Obrigatório       |
| `Preco`        | `decimal(10,2)` | Obrigatório       |
| `ImagemUrl`    | `string(300)`   | Obrigatório       |
| `Estoque`      | `float`         |                   |
| `DataCadastro` | `DateTime`      |                   |
| `CategoriaId`  | `int`           | Chave Estrangeira |

### Categoria

| Campo         | Tipo de Dado  | Restrições     |
| :------------ | :------------ | :------------- |
| `CategoriaId` | `int`         | Chave Primária |
| `Nome`        | `string(80)`  | Obrigatório    |
| `ImagemUrl`   | `string(300)` | Obrigatório    |

## Como Executar o Projeto

1.  **Pré-requisitos:**

    - [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
    - Um editor de código de sua preferência (como Visual Studio Code ou Visual Studio 2022).

2.  **Clone o repositório:**

    ```bash
    git clone <URL_DO_SEU_REPOSITORIO>
    cd <NOME_DA_PASTA_DO_PROJETO>
    ```

3.  **Configure o Banco de Dados:**

    - O projeto está configurado para usar o SQLite.
    - A string de conexão pode ser encontrada e modificada no arquivo `appsettings.json`.
    - Para criar o banco de dados e as tabelas, execute os seguintes comandos do Entity Framework Core no terminal, na pasta do projeto:

    <!-- end list -->

    ```bash
    dotnet tool install --global dotnet-ef
    dotnet ef migrations add CriacaoInicial
    dotnet ef database update
    ```

    - [cite\_start]_Observação: As dependências do `Microsoft.EntityFrameworkCore.Design` [cite: 2] [cite\_start]e `Microsoft.EntityFrameworkCore.Tools` [cite: 3] já estão incluídas no projeto._

4.  **Execute a aplicação:**

    ```bash
    dotnet run
    ```

5.  **Acesse a documentação da API:**

    - Após iniciar a aplicação, você pode acessar a interface do Swagger para ver todos os endpoints e testá-los. O endereço padrão geralmente é:
      - `https://localhost:<PORTA>/swagger/index.html`

## Endpoints da API

A API possui dois controladores principais: `Produtos` e `Categorias`.

### Produtos

- `GET /Produtos`: Retorna uma lista de todos os produtos.
- `GET /Produtos/{id}`: Retorna um produto específico com base no `id`.
- `POST /Produtos`: Adiciona um novo produto.
- `PUT /Produtos/{id}`: Atualiza um produto existente.
- `DELETE /Produtos/{id}`: Remove um produto.

### Categorias

- `GET /Categoria`: Retorna uma lista de todas as categorias.
- `GET /Categoria/produtos`: Retorna uma lista de todas as categorias, incluindo os produtos associados a cada uma.
- `GET /Categoria/{id}`: Retorna uma categoria específica com base no `id`.
- `POST /Categoria`: Adiciona uma nova categoria.
- `PUT /Categoria/{id}`: Atualiza uma categoria existente.
- `DELETE /Categoria/{id}`: Remove uma categoria.

## Próximos Passos e Melhorias

Este é um projeto em desenvolvimento. Algumas das melhorias planejadas incluem:

- [ ] Implementar tratamento de erros mais robusto.
- [ ] Adicionar validação de dados (Data Annotations) mais completa nos modelos.
- [ ] Criar uma camada de serviço para separar as regras de negócio dos controladores.
- [ ] Implementar paginação nos endpoints de listagem.
- [ ] Adicionar autenticação e autorização.
- [ ] Escrever testes unitários e de integração.
