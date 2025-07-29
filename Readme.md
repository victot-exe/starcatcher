## Consorcio
### Como funciona?
Um grupo de pessoas com o mesmo objetivo para comprar algo se reúne (através de uma concessionaria) para comprar algo (serviço, produto, imóvel).
Ou seja um grupo (consórcio) é dividido em cotas por seus membros, as cotas são pagas mensalmente ou no período acordado.
Tem também os sorteios de contemplação, quanto mais você paga (fazendo os lances) mais chances você tem de ser contemplado.

### Necessário para a aplicação (backend)
_Utilizar .NET_
1. CRUD das cotas (Create, Read, Update, Delete) -> Via graphQL
2. Um método que sorteia de maneira aleatória dando mais chances para quem pagou mais (fez mais lances)
3. Autenticação simples via JWT
#### Esquema do banco de dados (inicial)

~~~mermaid
classDiagram

    class Cota{

        Id: int

        ValorFinal: decimal

        ValorMensal: decimal

        ValorPago: decimal

        Status -entender melhor

        DataCriacao: LocalDate

        GrupoId: int -FK

    }

  

    class Grupo{

        Id: int

        ValorFinal: decimal

        Cotas: List|Cotas|

    }

  

    Cota --> Grupo
~~~

#### Comunicação

~~~mermaid
sequenceDiagram

    Frontend ->> ApolloServer: Coleta os dados da requisição
    ApolloServer ->> Backend: Cria a requisição graphql
    Backend ->> Database: Processa a requisição e coleta os dados no Database
    Database -->> Backend: Devolve os dados requisitados
    Backend -->> ApolloServer: Processa os dados da requisição e devolve em graphql
    ApolloServer -->> Frontend: Trata os dados da graphQL e manda para o front
~~~

#### Código (backend)
- Utilizar `HotChocolate.AspNetCore` para as requisições poderem ser em GraphQL;
- Pesquisar qual template utilizar para conseguir criar essa API (`dotnet new web` ou `dotnet new webapi`)
- Utilizar `Microsoft.EntityFrameworkCore` para fazer a abstração do banco de dados
- Utilizar `Microsoft.EntityFrameworkCore.Design` para fazer a abstração
- Utilizar `Microsoft.EntityFrameworkCore.SqlServer` -> driver do banco de dados
- Pesquisar como faz para fazer a relação 1->n no EF