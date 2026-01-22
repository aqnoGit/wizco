# wizco GerenciadorDePedidos API
Desafio técnico .Net

API desenvolvida em .NET 8 para gerenciamento de pedidos. 
Utiliza Entity Framework Core com MySQL para persistência.

Como rodar o projeto:
1. Clonar o repositório
git clone 

2. Configurar o banco de dados

Certifique-se de ter o MySQL instalado e rodando.

Crie o banco de dados com o comando => CREATE DATABASE gerenciadordepedidos;

Ajuste a connection string no arquivo appsettings.json passando a sua senha

3. Aplicar migrations

dotnet ef database update

4. Rodar a API

dotnet run

Abrirá uma página no swagger em seu navegador
