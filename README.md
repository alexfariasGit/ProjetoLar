# ProjetoLar
O ProjetoLar consiste em uma aplicação em camadas baseadas no modelo CQRS com MediatR,
contendo
Projeto de Domain(Entidades)
Projeto de Data(acesso ao Banco de Dados)
projeto de Business(regras de negocio)
Projeto de Api(endpoint)
Projeto Web(Visual)

Para execução e necessario ajustar os appsettings com a conexao de um banco em branco que ProjetoLar
no SQLServer apos os ajustes no Package Manager Console setar o projeto para Data e executar o seguinte
comando dotnet ef database update --project Caminho do projeto\Projeto Lar\Data\Data.csproj para a 
criação das tabelas. 
Executar a subida do projeto de Api e o de Web.

Att.