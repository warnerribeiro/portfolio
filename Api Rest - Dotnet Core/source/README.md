# BackendApi

## Tecnoligias Utilizadas

- Asp net core 5.0
- EntityFramework core 
- Dapper
- Autenticação em JWT
- SQL Server

## Sobre o projeto

O projeto foi desenvolvido em camadas, cada camada tem sua responsabilidade,
camada de repository responsavel por comunicação e troca de informação com banco de dados,
camada de serviço reponsavel pela regra de negocio, camada de serviço de aplicação responsavel pela troca de informação
com cliente, utilizado banco de dados sql server com EntityFramework core (ORM) e Dapper (Micro ORM), Dapper fui utilizado 
para consultas que podem retornar grande quantidade de dados, para ter um melhor desempenho, entity fui utilizado para
gerenciar o modelo de banco de dados e operações como inserir, atualizar e deletar, WebApi foi implementada utilizando
o padrão REST, utilizada autenticação por token JWT e armazenamento de senhas utilizada tecnica de salt e pepper para maior segurança.
