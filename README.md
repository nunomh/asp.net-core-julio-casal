# ASP.NET Core Full Course For Beginners

Based on Julio Casal youtube video https://www.youtube.com/watch?v=AhAxLiGC7Pc  
API project for a game store

.NET version > `dotnet --version`

### Create

.NET list of projects > `dotnet new list`

based on the short name of the list, create a new project, for instance > `dotnet new web`

Or with VS Code: Ctrl + Shift + P, select .NET new project, select the type of project

---

### Build

Build > `dotnet build` ou **Ctrl + Shift + B** ou pelo VS Code, no projeto, clicar no botão direito do rato e fazer build

---

### Run

**F5**  
ou **Ctrl + Shift + D** (vai para a tab Run And Debug)  
ou `dotnet run` dentro do projeto. Corre sem debugger.

---

### Packages

MinimalApis.Extensions - `dotnet add package MinimalApis.Extensions --version 0.11.0`
EntityFrameworkCore.Sqlite - `dotnet add package Microsoft.EntityFrameworkCore.Sqlite --version 8.0.2`

---

### What is a REST API

API - Application Programming Interface  
REST - REpresentational State Transfer - A set of guiding principles that impose conditions on how an API should work

A REST or RESTFUL API in one that conforms to the REST architectural style

**URI** - Uniform Resource Identifier  
http://example.com/games  
http - Protocol  
example.com - Domain  
games - Resource

A **resource** is any object, document or thing that the API can receive from or send to clients (ex. songs, users, posts)

**HTTP Methods**
The interaction with a REST API depends on the HTTP method  
Clients <--request--> Server  
Also known as CRUD operations, the HTTP methods are:

- POST - creates new resources
- GET - retrieves resources
- PUT - updates
- DELETE - deletes

---

#### Test a REST call

('REST Client' VS Code extension installed)  
**Ctrl + Alt + R**
