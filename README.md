# RPGWiki API

RPGWiki é uma API para gerenciamento de elementos de RPG, como jogadores, personagens, missões e equipamentos. 

## Endpoints

### Jogadores

- **GET** `/jogadores`
  - Retorna uma lista de todos os jogadores.

- **GET** `/jogadores/{id}`
  - Retorna os detalhes de um jogador específico pelo seu ID.

- **POST** `/jogadores`
  - Cria um novo jogador.
  - Corpo da requisição: `{"Nome": "string", "Moedas": "int", "Missoes": ["MissaoRequest"]}`

- **DELETE** `/jogadores/{id}`
  - Deleta um jogador pelo seu ID.

- **PUT** `/jogadores`
  - Atualiza um jogador existente.
  - Corpo da requisição: `{"Id": "int", "Nome": "string", "Moedas": "int"}`

### Personagens

- **GET** `/personagens`
  - Retorna uma lista de todos os personagens.

- **GET** `/personagens/{id}`
  - Retorna os detalhes de um personagem específico pelo seu ID.

- **POST** `/personagens`
  - Cria um novo personagem.
  - Corpo da requisição: `{"name": "string"}`

- **DELETE** `/personagens/{id}`
  - Deleta um personagem pelo seu ID.

- **PUT** `/personagens`
  - Atualiza um personagem existente.
  - Corpo da requisição: `{"Id": "int", "Name": "string", "Nivel": "int", "Vida": "int"}`

### Missões

- **GET** `/missoes`
  - Retorna uma lista de todas as missões.

- **POST** `/missoes`
  - Cria uma nova missão.
  - Corpo da requisição: `{"Name": "string", "Dificuldade": "int"}`

- **DELETE** `/missoes/{id}`
  - Deleta uma missão pelo seu ID.

- **GET** `/missoes/{id}/jogadores`
  - Retorna os jogadores associados a uma missão específica pelo seu ID.

### Equipamentos

- **GET** `/equipamentos`
  - Retorna uma lista de todos os equipamentos.

- **GET** `/equipamentos/{id}`
  - Retorna os detalhes de um equipamento específico pelo seu ID.

- **POST** `/equipamentos`
  - Cria um novo equipamento.
  - Corpo da requisição: `{"Name": "string", "Tipo": "string"}`

- **DELETE** `/equipamentos/{id}`
  - Deleta um equipamento pelo seu ID.

- **PUT** `/equipamentos`
  - Atualiza um equipamento existente.
  - Corpo da requisição: `{"Id": "int", "Name": "string", "Tipo": "string"}`

## Dados de Exemplo

### Jogadores
```json
[
  { "Id": 1, "Nome": "Ana", "Moedas": 1500 },
  { "Id": 2, "Nome": "Bruno", "Moedas": 2000 },
  { "Id": 3, "Nome": "Carla", "Moedas": 1800 }
]
```

### Equipamentos
```json
[
  { "Id": 1, "Nome": "Espada", "Tipo": "Arma", "JogadorId": 1 },
  { "Id": 2, "Nome": "Escudo", "Tipo": "Armadura", "JogadorId": 1 },
  { "Id": 3, "Nome": "Cajado", "Tipo": "Arma", "JogadorId": 2 },
  { "Id": 4, "Nome": "Armadura Leve", "Tipo": "Armadura", "JogadorId": 3 },
  { "Id": 5, "Nome": "Poção de Vida", "Tipo": "Consumível", "JogadorId": 3 }
]
```
### Personagens
```json
[
  { "Id": 1, "Nome": "Guerreiro Ana", "Nivel": 10, "JogadorId": 1, "Vida": 100 },
  { "Id": 2, "Nome": "Arqueira Ana", "Nivel": 8, "JogadorId": 1, "Vida": 80 },
  { "Id": 3, "Nome": "Mago Bruno", "Nivel": 12, "JogadorId": 2, "Vida": 120 },
  { "Id": 4, "Nome": "Ladino Carla", "Nivel": 7, "JogadorId": 3, "Vida": 70 },
  { "Id": 5, "Nome": "Paladino Carla", "Nivel": 15, "JogadorId": 3, "Vida": 150 },
  { "Id": 6, "Nome": "Druida Carla", "Nivel": 9, "JogadorId": 3, "Vida": 90 }
]
```
### Missões
```json
[
  { "Id": 1, "Nome": "Resgatar o Rei", "Dificuldade": 3 },
  { "Id": 2, "Nome": "Defender a Vila", "Dificuldade": 5 },
  { "Id": 3, "Nome": "Explorar a Caverna", "Dificuldade": 1 }
]
```
### Participações (JogadorMissao)
```json
[
  { "jogadoresId": 1, "missoesId": 1 },
  { "jogadoresId": 2, "missoesId": 2 },
  { "jogadoresId": 3, "missoesId": 3 }
]
```
### Autenticação

Para acessar a API, é necessário autenticar-se com as credenciais fornecidas:

- **Email:** mestre@gmail.com
- **Senha:** Projeto@122

### Acesso

A API pode ser acessada via Swagger UI para facilitar a visualização e interação com os endpoints.

### Instruções para Execução

1. Clone o repositório:

    ```bash
    git clone <URL-do-repositorio>
    cd <nome-do-repositorio>
    ```

2. Instale as dependências e execute a aplicação:

    ```bash
    dotnet restore
    dotnet run
    ```

3. Acesse o Swagger UI em [https://localhost:7172/Swagger/index.html](https://localhost:7172/Swagger/index.html).

### Licença

Este projeto está licenciado sob a Licença MIT - veja o arquivo `LICENSE` para mais detalhes.
