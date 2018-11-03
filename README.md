# .NET-Core-EF-MySql-Swagger
Microserviço REST utilizando .NET Core 2 com Entity Framework, MySql e Swagger.

# Executar o projeto
1. Criar o banco de dados executando o script Config/insertTableUsuario.sql;

2. Configurar uma variável de ambiente 'MYSQL_CONNECTION', contendo uma connection-string mysql válida, exemplo:
> "server=localhost;port=3306;database=mydatabase;uid=myuser;password=123456"
   
3. Realizar o mapeamento das entidades utilizando Scaffolding, executando o comando a seguinte no console 'Package Manager Console' do Visual Studio, substituindo '<connection-string>' pela sua connection do MySql:
> "Scaffold-DbContext "<connection-string>" "Pomelo.EntityFrameworkCore.MySql" -o Model"
