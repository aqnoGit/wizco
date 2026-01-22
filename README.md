# wizco GerenciadorDePedidos API
Desafio técnico .Net

API desenvolvida em .NET 8 para gerenciamento de pedidos. 
Utiliza Entity Framework Core com MySQL para persistência.

Como rodar o projeto:
1. Clonar o repositório com o comando => git clone 
2. Configurar o banco de dados
3. Certifique-se de ter o MySQL instalado e rodando.
4. Crie o banco de dados com o comando => CREATE DATABASE gerenciadordepedidos;
5. Ajuste a connection string no arquivo appsettings.json passando a sua senha
6. Aplicar migrations com o comando => dotnet ef database update
7. Rodar a API com comando => dotnet run
(Abrirá uma página no swagger em seu navegador)
