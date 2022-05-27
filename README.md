# Desafio  .NET Core
 
## Técnicas

- [x] RESTfull
- [x] Autenticação JWT
- [x] Swagger
- [x] Versionamento de API
- [x] CQRS 
- [x] FluentValidation
- [x] Docker

## ORM EF (ENTITY FRAMEWORK)
- [x] Sql
- [x] Migrations

## API contendo as seguintes funcionalidades:

- Administrador
    - Cadastro
    - Edição
    - Exclusão lógica (desativação)
    - Listagem de usuários não administradores ativos
        - Opção de trazer registros paginados
        - Retornar usuários por ordem alfabética
- Usuário
    - Cadastro
    - Edição
    - Exclusão lógica (desativação)
- Filmes
    - Cadastro (somente um usuário administrador poderá realizar esse cadastro)
    - Voto (a contagem de votos será feita por usuário de 0-4 que indica quanto o usuário gostou do filme)
    - Listagem
        - Opção de filtros por diretor, nome, gênero e/ou atores
        - Opção de trazer registros paginados
        - Retornar a lista ordenada por filmes mais votados e por ordem alfabética
    - Detalhes do filme trazendo todas as informações sobre o filme, inclusive a média dos votos

## Usuarios para Testes

	- admin@admin.com senha: Admin@12345
	- user@user.com   senha:User@12345
	
## Setup
	- Rode o comando docker-compose -f video-store.yml up --build na pasta docker-compose na raiz do projeto.
	
