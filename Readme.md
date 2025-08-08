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

	class GrupoConsorcio{
        Id: int
        NomeDoGrupo: string
        ValorTotalDoGrupoSemTaxa: decimal
        QuantidadeDeCotas: int
        TaxaAdministrativa: decimal
        ValorTaxaAdministrativa: decimal
        Cotas: List|Cotas|
    }

    class Cota{
        Id: int
		NumeroCota: string?
        ValorParcela: decimal?
		TotalPago: decimal?
		DataDeAtribuição: DateOnly
		GrupoConsorcioId: int -FK
		GrupoConsorcio: GrupoConsorcio[JsonIgnore]
		ValorDaCartaDeCredito: decimal?
		QteParcelas: int?
		UserId: int -FK
		User: User
		ValorTotal: decimal [QteParcelas * ValorParcela]
    }

	class User{
		Id: int
		Username: string
		Password: string
		Cotas: List|Cota|
	}
    Cota --> GrupoConsorcio
    Cota --> User
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
##### Bibliotecas utilizadas
- Utilizar `Microsoft.EntityFrameworkCore` para fazer a abstração do banco de dados;
- Utilizar `Microsoft.EntityFrameworkCore.Design` para fazer a abstração;
- Utilizar `Microsoft.EntityFrameworkCore.SqlServer` -> driver do banco de dados;
- Utilizar `Microsoft.AspNetCore.Authentication.JwtBearer` -> Criação de JWT;
- Utilizar `Microsoft.AspNetCore.Identity` -> Gerenciar identidade e autenticar;
##### Endpoints

- Para conseguir utilizar a API você precisar criar seu usuário no endpoint proprio para isso:
-  `[POST].../user/novo-usuario`
```json
{
	"Username": "usuario",
	"Password": "password"
}
```

Para verificação eu coloquei apenas que o nome e a senha não podem estar em branco, mas deixei o código de um jeito que eu possa implementar mais complexidade minima a senha e ao usuário sem maiores problemas por meio das Reflections.

- Após criar seu usuário você precisa autenticar;
-  `[POST].../auth`
	**O body da autenticação**:
~~~json
{
	"Username":"usuario",
	"Password": "password"
}
~~~
A resposta será assim:
```json
{
	"token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJ1c3VhcmlvIiwianRpIjoiNmMzOGEwNTctMjVmMS00YWNkLThkZTAtNzU1ODQ2NTNjN2IzIiwidXNlcklkIjoiMSIsImV4cCI6MTc1NDY2MjgzNSwiaXNzIjoibWV1ZG9taW5pbyIsImF1ZCI6Im1ldWRvbWluaW8ifQ.KaCeh4B5mUYuAjg2798KXKwgBohlteS0b4V3GzpyFnw"
}
```
- Pegue o conteúdo de token, esta é a sua chave JWT, ela é enviada no bearer da requisição ~~por enquanto, mais pra frente pretendo mudar para armazenamento em cookie~~;
- `[PUT].../user/{id}` -> endpoint para atualização, com as mesmas verificações que fazemos ao criar o usuário
- Body:
~~~json
{
	"Username":"usuario",
	"Password": "password"
}
~~~

- `[GET].../user/` -> Obtém todos os usuários com a respectiva lista de cotas de cada um;
```json
[
	{
		"username": "usuario",
		"cotas": [
			{
				"id": 2,
				"numeroCota": "G1C00002",
				"valorTotal": 1.00,
				"parcela": 1.00,
				"totalPago": 0.00,
				"dataCriacao": "2025-08-06",
				"grupoId": 1
			},
			{
				"id": 3,
				"numeroCota": "G1C00003",
				"valorTotal": 1.00,
				"parcela": 1.00,
				"totalPago": 0.00,
				"dataCriacao": "2025-08-06",
				"grupoId": 1
			]
	},
	{
		"username": "usuario2",
		"cotas": [
			{
				"id": 4,
				"numeroCota": "G1C00002",
				"valorTotal": 1.00,
				"parcela": 1.00,
				"totalPago": 0.00,
				"dataCriacao": "2025-08-06",
				"grupoId": 1
			},
			{
				"id": 5,
				"numeroCota": "G1C00003",
				"valorTotal": 1.00,
				"parcela": 1.00,
				"totalPago": 0.00,
				"dataCriacao": "2025-08-06",
				"grupoId": 1
			]
	}
]
```
- `[GET].../user/{username}` -> podemos obter o usuário a partir do seu username
```json
{
	{
	"username": "usuario",
	"cotas": [
		{
			"id": 2,
			"numeroCota": "G1C00002",
			"valorTotal": 1.00,
			"parcela": 1.00,
			"totalPago": 0.00,
			"dataCriacao": "2025-08-06",
			"grupoId": 1
		},
		{
			"id": 3,
			"numeroCota": "G1C00003",
			"valorTotal": 1.00,
			"parcela": 1.00,
			"totalPago": 0.00,
			"dataCriacao": "2025-08-06",
			"grupoId": 1
		},
		{
			"id": 1002,
			"numeroCota": "G0002C00001",
			"valorTotal": 10.20,
			"parcela": 0.34,
			"totalPago": 0.00,
			"dataCriacao": "2025-08-07",
			"grupoId": 2
		}
	]
}
}
```
- `[DELETE].../user/{id}` -> requisição para deletar o usuário, deleta o usuário e seta as propriedade Atribuida para false e o UserId para null;
- As cotas são criadas de maneira automática quando criamos um grupo, já que é impossível existir uma cota que não esteja ligada a um grupo, no momento da criação é definido o UserId como null e o Atribuida como false, para criar grupos utilizamos o endpoin:
	- `[POST].../grupos/` com o body:
	~~~json
	{
		"NomeGrupo": "Grupo do Teste",
		"ValorFinalPorCota": 17000,
		"TaxaDeAdministracao": 17,
		"ParcelasPorCota": 10,
		"QuantidadeDeCotas": 10
	}
	~~~
	- O esse endpoint já faz as validações necessárias
	- O NomeGrupo não pode ser vazio;
	- O ValorFinalPorCota deve ser maior do que 0;
	- A TaxaDeAdministracao deve ser maior do que 0 e menor do que 100;
	- As ParcelasPorCota devem ser maior do que 0;
	- A QuantidadeDeCotas deve ser maior do que 0;
		No service ligado a este endpoint ele faz uso da classe GrupoConsorcioFactory
	- `GrupoConsorcioFactory` -> é a classe que possui métodos estáticos que são responsáveis pela criação de grupos a partir da entrada dos dados, ela cria com base nas regras de negócio;
		- `CriarGrupo` -> Cria o GrupoConsorcio;
		- `GerarCotas` -> É a função que faz um loop e a partir dele cria as cotas com base nos dados inseridos, o loop dura quantas vezes forem definidas em QuantidadeDeCotas;
	- `CotasFactory` -> É a classe responsável por criar Cotas com base nos dados enviados pelo usuário
		- `GerarCota` -> Método que recebe os dados e cria as cotas, ele é consumido dentro do loop de `GerarCotas`.
- `[PUT].../grupos/{id}` -> Endpoint que atualiza os grupos, tem as mesmas validações que ao criar a cota, com o adicional de não deixar alterar o número de cotas que o grupo possui.
	- Body:
	~~~json
	{
		"NomeGrupo": "Grupo do Teste",
		"ValorFinalPorCota": 17000,
		"TaxaDeAdministracao": 17,
		"ParcelasPorCota": 10,
		"QuantidadeDeCotas": 10
	}
	~~~
	- O service desse endpoint também faz o recalculo do valor das cotas, sem alterar o quanto já foi pago;
- `[GET].../grupos/` -> retorna todos os grupos com a sua lista de cotas;
- `[GET].../grupos/{id}` -> retorna o grupo com o respectivo id e a sua lista de cotas;
- `[DELETE].../grupos/{id}` -> exclui o grupo com o id e exclui também as suas cotas;
- `[POST].../cotas/{id}` -> este recurso ele pega uma cota criada previamente, e retorna a primeira que tem o atributo Atribuida como false;
- `[GET].../cotas/` -> retorna todas as cotas que tem Atribuida como true;
- `[GET].../cotas/{id}` -> retorna a cota com o respectivo id independente do Atribuida ser true ou false;
- `[PUT].../cotas/{}` -> em alteração