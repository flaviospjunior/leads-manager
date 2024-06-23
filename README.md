# Leads Manager

Um projeto para gerenciamento de leads utilizando .NET 6 e Entity Framework Core.

## Tabela de Conteúdos

- [Pré-requisitos](#pré-requisitos)
- [Instalação](#instalação)
- [Configuração](#configuração)
- [Uso](#uso)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Licença](#licença)
- [Contato](#contato)

## Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) 

## Instalação

```bash
# Clone este repositório
git clone https://github.com/seu-usuario/leads-manager.git

# Acesse a pasta do projeto no terminal/cmd
cd leads-manager

# Instale as dependências
dotnet restore
```

## Configuração

1. Configure a string de conexão do banco de dados em `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=NomeDoBanco;Trusted_Connection=True;MultipleActiveResultSets=true"
  }
}
```

# Uso

## Migrations

Aplique a Migration mais recente de acordo com o comando a seguir:

### Atualize o banco de dados com a migration mais recente

#### Package Manager Console

1. Abra o Visual Studio.
2. Vá para **Tools** > **NuGet Package Manager** > **Package Manager Console**.
3. Execute os seguintes comandos:

```powershell
# Atualize o banco de dados com a migration mais recente
Update-Database -Project Leads.Data -StartupProject Leads-Manager
```

#### Opção via Terminal

```bash
# Aplicação de Migration
cd Leads-Manager
dotnet ef database update -p Leads.Data -s Leads-Manager
```
### Execute a aplicação

```bash
# Execute a aplicação
cd Leads-Manager
dotnet run
```

Por padrão a aplicação estará disponível em `https://localhost:7256`.

A documentação estará disponível em `https://localhost:7256/swagger/index.html`.

## Estrutura do Projeto

```
leads-manager/
├── Leads.Application/
│   ├── Dependencies/
│   ├── Configuration/
│   ├── Events/
│   ├── Features/
│   ├── IoC/
│   └── Services/
├── Leads.Data/
│   ├── Dependencies/
│   ├── Configuration/
│   ├── Contexts/
│   ├── Migrations/
│   ├── Repositories/
│   └── UnitOfWork/
├── Leads.Domain/
│   ├── Dependencies/
│   ├── Aggregates/
│   ├── Entities/
│   ├── Enums/
│   └── Interfaces/
├── Leads.SharedKernel/
│   ├── Dependencies/
│   ├── Mediator/
│   └── KernelLoc.cs
├── Leads.Tests/
│   ├── Dependencies/
│   ├── Application/
│   ├── Data/
│   ├── Fixture/
│   └── Services/
└── Leads-Manager/
    ├── Connected Services/
    ├── Dependencies/
    ├── Properties/
    ├── Controllers/
    ├── appsettings.json
    └── Program.cs
```

## Tecnologias Utilizadas

- [.NET 6](https://dotnet.microsoft.com/download/dotnet/6.0)
- [Entity Framework Core](https://docs.microsoft.com/pt-br/ef/core/)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)


## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## Contato

[Flávio Pires](https://www.linkedin.com/in/flaviospjunior/) - flaviospjunior@gmail.com

Link do Projeto: https://github.com/flaviospjunior/leads-manager
