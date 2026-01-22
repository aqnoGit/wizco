# wizco GerenciadorDePedidos API
Desafio técnico .Net

API desenvolvida em .NET 8 para gerenciamento de pedidos. 
Utiliza Entity Framework Core com MySQL para persistência.

Como rodar o projeto:
1. Clonar o repositório com o comando => git clone 
2. Configurar o banco de dados

2.1. Certifique-se de ter o MySQL instalado e rodando.
2.2. Crie o banco de dados com o comando => CREATE DATABASE gerenciadordepedidos;
2.3. Ajuste a connection string no arquivo appsettings.json passando a sua senha

3. Aplicar migrations com o comando => dotnet ef database update

4. Rodar a API com comando => dotnet run
(Abrirá uma página no swagger em seu navegador)
