<h1 align="center"> API com Swagger e CRUD </h1>

<p align="center">
  Atividade Prática do Módulo 6
</p>

Este projeto é uma API RESTful ASP.NET Core com Swagger, fornecendo operações CRUD (Create, Read, Update, Delete) para a entidade Usuario, Destino e Destino Reservado.

### Pré-requisitos

- .NET Core SDK instalado (versão 3.1 ou superior) https://dotnet.microsoft.com/en-us/download

- Entity Framework Core para migração e manipulação do banco de dados https://learn.microsoft.com/pt-br/ef/core/

### Passos de Configuração

1. Clonar o repositório:
   
```bash
git clone https://seurepositorio.com/suaminhaapi.git
cd suaminhaapi
```
2. nstalar Pacotes Necessários:

```bash
dotnet restore
```

3. Configurar o Entity Framework Core:

- Crie a classe de contexto ApplicationDbContext e a classe Usuario para representar a entidade Usuario.

4. Configurar o Swagger:

- No arquivo Startup.cs, configure o Swagger no método ConfigureServices e adicione o middleware do Swagger no método Configure.

5. Criar Operações CRUD para a Classe Usuario:

- Crie o controlador UsuarioController com operações CRUD.

6. Migrar e Atualizar o Banco de Dados:

- Execute os seguintes comandos para aplicar as migrações e atualizar o banco de dados:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```
7. Execute a Aplicação:

```bash
dotnet run
```

8. Acessar o Swagger:

- Abra o navegador e acesse https://localhost:5001/swagger para testar e documentar sua API usando o Swagger.

### Comandos Úteis

- Adicionar Migração:

```bash
dotnet ef migrations add NOME_DA_MIGRACAO
```


- Atualizar Banco de Dados:

```bash
dotnet ef database update
```


