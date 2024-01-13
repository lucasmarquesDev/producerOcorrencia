# API .NET 7 com Clean Architecture, Entity Framework Core (Code First), MediatR - Exemplo

Esta API .NET 7 é um exemplo de aplicação que segue os princípios da Clean Architecture, MediatR para implementar operações em uma fila do Azure Service Bus SOLID.

## Estrutura do Projeto

A estrutura do projeto segue a Clean Architecture:

- **Core:** Contém dois projetos o primeiro é o Template.Application onde contem os UseCases que lida com a lógica de aplicação, incluindo manipulação de comandos e consultas utilizando o MediatR, classe de validação utilizando o FluentValidation. O segundo é o Template.Domain onde contem as entidades interfaces e objeto de response
- **Infrastructure:** Contém um projeto Template.Persistence Responsável por implementações específicas da infraestrutura, como por exemplo as chamadas do Azure Service Bus
- **Template.API:** Apresenta a API RESTful, recebe solicitações HTTP e interage com as classes da camada de aplicação.
- **Test:** Contém o projeto Template.UnitTests que tem como finalidade uma bateria de testes a nivel unitario, então ele moca os dados das entidades e realiza diversos testes. Utilizando as bibliotecas FluentValidation e XUnit para a execução dos benchmarks

## Principais componentes
- **Clean Architecture:**
	O código é organizado em camadas distintas, como Core (entidades e lógica de negócios), Infrastructure (implementações específicas da infraestrutura, como acesso ao Azure Service Bus), Application (lógica de aplicação), e Web API (apresentação da API).

- **MediatR:**
	A API implementa o padrão Mediator utilizando a biblioteca MediatR.

## Pré-requisitos

- [.NET SDK 7](https://dotnet.microsoft.com/download)
  
## Configuração

1. Clone o repositório: `git clone https://github.com/lucasmarquesDev/producerOcorrencia`
3. Navegue até o diretório `Template.API` e execute `dotnet run` para iniciar a aplicação.

## Utilização da API

- **Criar Nova Ocorrência:**
  `POST /api/ocorrencias/create`

## Tecnologias Utilizadas

- .NET 7
- MediatR
- XUnit
- FluentValidation

## Contribuições

Contribuições são bem-vindas!
