# TESTE TÉCNICO - Desenvolvedor Back end: Sistema de controle de Notas Fiscais para Freelancer

## Demonstração
Vídeo demonstrando a API funcionando: [https://youtu.be/SfiozbOSE2o](https://youtu.be/SfiozbOSE2o)

## Tecnologias utilizadas:
 - ASP.NET Core
 - Entity Framework Core
 - SQL Server

## Configura para executar o sistema
Precisa ter o [.NET Core 3.1](https://dotnet.microsoft.com/download/dotnet-core/3.1) instalado

Por padrão o arquivo vai se conectar na instancia `.\SQLEXPRESS` usando autenticação do windows.
O nome do banco de dados será como `GustavoVibbraTestDb`.

Se precisar alterar essas configurações, será necessário alterar o arquivo `VibbraTest.API\bin\Debug\netcoreapp3.1\appsettings.Development.json`.
Se a pasta `VibbraTest.API\bin\Debug` não existir, execute o comando `dotnet build` dentro da pasta `VibbraTest.API`.

## Como executar o sistema
Dentro da pasta `VibbraTest.API`, executar o seguinte comando `dotnet run`

Ao executar o sistema, o banco de dados deve ser criado automaticamente. 
Caso o sistema não consiga criar o banco por causa de alguma permissão, 
você terá que criar o banco `GustavoVibbraTestDb` manualmente.

Por padrão no sistema já vai vir cadastrado um usuário `Admin` com a senha `Admin` para facilitar os testes
