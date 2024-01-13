# API .NET 7 com Clean Architecture, Entity Framework Core (Code First), MediatR e CQRS - Exemplo

Esta API .NET 7 é um exemplo de aplicação que segue os princípios da Clean Architecture, utiliza Entity Framework Core para interação com um banco Oracle, MediatR para implementar o padrão CQRS, e realiza operações CRUD em uma tabela chamada `TB_OCORRENCIA` e utilizando principios SOLID.

## Estrutura do Projeto

A estrutura do projeto segue a Clean Architecture com a adição do padrão CQRS:

- **Core:** Contém dois projetos o primeiro é o Template.Application onde contem os UseCases que lida com a lógica de aplicação, incluindo manipulação de comandos e consultas utilizando o MediatR, classe de validação utilizando o FluentValidation. O segundo é o Template.Domain onde contem as entidades interfaces e objeto de response
- **Infrastructure:** Contém um projeto Template.Persistence Responsável por implementações específicas da infraestrutura, como contexto de banco de dados, migrations, contem tambem a pasta ContextExistings onde contem exemplo de Scaffold onde as entidades são criadas a partir das tabelas do banco de dados.
- **Template.API:** Apresenta a API RESTful, recebe solicitações HTTP e interage com as classes da camada de aplicação.
- **Test:** Contém dois projetos o primeiro é o Template.IntegrationTests que tem com finalidade realizar uma bateria de testes integrados com dados mocados em uma instancia do banco de dados, o segundo projeto é o Template.UnitTests que tem como finalidade uma bateria de testes a nivel unitario, então ele moca os dados das entidades e realiza diversos testes. Ambos os projetos utilizam as bibliotecas FluentValidation e XUnit para a execução dos benchmarks

## Principais componentes
- **Clean Architecture:**
	O código é organizado em camadas distintas, como Core (entidades e lógica de negócios), Infrastructure (implementações específicas da infraestrutura, como acesso ao banco de dados), Application (lógica de aplicação utilizando CQRS), e Web API (apresentação da API).
	Entity Framework Core (Code First).

- **Entity Framework Core (Code First):** 
	Utiliza Entity Framework Core para interação com um banco de dados Oracle. O Code First permite a definição do modelo de dados usando classes, gerando automaticamente o esquema do banco de dados.
	MediatR e CQRS.

- **MediatR e CQRS:**
	A API implementa o padrão Mediator utilizando a biblioteca MediatR, separando operações de escrita (comandos) e leitura (consultas). O padrão CQRS melhora a escalabilidade e facilita a manutenção ao otimizar cada tipo de operação.
	Operações CRUD.

- **Operações CRUD:**
	Abaixo um conjunto de endpoints para realizar operações CRUD na tabela TB_OCORRENCIA. Os endpoints são projetados para seguir as melhores práticas RESTful.

## Pré-requisitos

- [.NET SDK 7](https://dotnet.microsoft.com/download)
- [Oracle Database](https://www.oracle.com/database/)
  
## Configuração

1. Clone o repositório: `git clone https://BrasPress@dev.azure.com/BrasPress/Template%20API%20.NET/_git/Template%20API%20.NET`
2. Configure a string de conexão Oracle no arquivo `appsettings.json` e `appsettings.Development.json` em `Template.API`.
3. Navegue até o diretório `Template.API` e execute `dotnet run` para iniciar a aplicação.

## Utilização da API

- **Obter Todas as Ocorrências:**
  `GET api/Ocorrencia/getall`

- **Obter Ocorrência por ID:**
  `GET /api/ocorrencias/getbyid/{id}`

- **Criar Nova Ocorrência:**
  `POST /api/ocorrencias/create`

- **Atualizar Ocorrência Existente:**
  `PUT /api/ocorrencias/update`

- **Excluir Ocorrência:**
  `DELETE /api/ocorrencias/delete/{id}`

## CQRS e MediatR

Este projeto utiliza o padrão CQRS (Command Query Responsibility Segregation) com a biblioteca MediatR para separar operações de leitura e escrita. A camada de comandos (Commands) lida com operações de escrita, enquanto a camada de consultas (Queries) lida com operações de leitura.

## Tecnologias Utilizadas

- .NET 7
- Entity Framework Core
- Oracle Database
- MediatR
- CQRS
- XUnit
- FluentValidation

## Contribuições

Contribuições são bem-vindas!

## Scripts bases

- **Aplica a migration(caso já exista):**
 `Update-Database -Context AppDbContext`

- **Cria uma migration:**
  `Add-Migration OracleInicial -Context AppDbContext`

- **Cria classe de entidades a partir de tabelas no banco:**
   `Scaffold-DbContext "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=BTU-DEV-SCAN.braspress.com.br)(PORT=1521)))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=BTUD.braspress.com.br)));User Id = usuario; Password = senha" Oracle.EntityFrameworkCore -o ContextExistings  -Tables MS_PICKUP_PICKUP_REL`