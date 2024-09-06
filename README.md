
# Projeto ASP.NET Core Web API com Entity Framework e Dapper

Este projeto é uma API construída com ASP.NET Core Web API, que utiliza dois ORMs diferentes: **Entity Framework Core** para operações de persistência (inserir, atualizar e excluir) e **Dapper** para consultas (selecionar). A arquitetura segue uma separação em camadas, com foco em boas práticas de desenvolvimento.

## Tecnologias Utilizadas

- ASP.NET Core 6.0
- Entity Framework Core
- Dapper
- SQL Server (para persistência de dados)
- Injeção de Dependência
- CORS para permitir comunicação entre frontend e backend

## Arquitetura

A arquitetura foi dividida em três camadas principais:
1. **Apresentação**: Responsável por expor os endpoints da API para o cliente (neste caso, uma SPA Angular).
2. **Domínio**: Contém as regras de negócio e as interfaces dos repositórios.
3. **Infraestrutura**: Implementa os repositórios utilizando Entity Framework Core e Dapper, além de configurar o DbContext.



## Configuração de Serviços

No arquivo `Startup.cs` ou `Program.cs`, configuramos o Entity Framework Core e o Dapper, além da política de CORS para permitir a comunicação com o frontend.

```csharp
public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

    services.AddScoped<IPessoaRepository, PessoaRepository>();

    services.AddControllers();

    services.AddCors(options =>
    {
        options.AddPolicy("AllowAll", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
    });
}
```

## Executando o Projeto

1. Clone o repositório.
2. Configure a string de conexão com o SQL Server no arquivo `appsettings.json`.
3. Execute o comando `dotnet ef database update` para criar o banco de dados.
4. Inicie a aplicação utilizando `dotnet run`.

Agora, a API estará disponível para ser consumida pelo frontend Angular ou qualquer outro cliente.
