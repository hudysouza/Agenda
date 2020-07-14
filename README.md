# Guia de Web API e  Vue.js
### Objetivos
Instruir como é feita a criação de uma Web API simples em ASP.NET Core para cadastro de contatos, como é feito o consumo dos dados de uma Web API utilizando o Postman  e como consumir uma com uma ferramenta de Frontend utilizando o Vuejs

## Pre Requisitos:
* [.net Core 3.1](https://dotnet.microsoft.com/download)
* [Node.js](https://nodejs.org/en/)
* [Postman](https://www.postman.com/)
* [Visual Studio Code](https://code.visualstudio.com/)
* [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

## Frameworks utilizadas

### Backend
* [ASP.NET Core 3.1](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-3.1) 
* [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
### Front End
* [Vue.js](https://vuejs.org/v2/guide/)
* [Vue CLI](https://cli.vuejs.org/)
* [Buefy](https://buefy.org/)

## Primeiros Passos
#### Criando um projeto ASP.NET CORE
```bash
$ dotnet new webapi -n Agenda --no-https
```
#### Adicionando dependências:
```bash
$ cd Agenda/
$ dotnet add package Microsoft.EntityFrameworkCore --version 3.1.5
$ dotnet add package Microsoft.EntityFrameworkCore.Design --version 3.1.5
$ dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 3.1.5
```

#### Gerando Migrations do Banco de Dados

``` bash
$ dotnet ef migrations add <Nome Migration>
$ dotnet ef database update
```

#### Criando projeto front-end
``` bash
$ npm install -g @vue/cli
$ vue create agenda.front
```

### Instalando dependencias do front-end
``` bash
$ npm install axios
$ npm install buefy
$ npm install bulma
$ npm install node-sass
$ npm install sass-loader
```

