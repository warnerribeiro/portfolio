# Desafio Basis

## Tecnologias

 Frontend
 - Angular 16
 - Bootstrap
 
 Backend
 - Net 8
 - Entity framework 8

DataBase
 - SQL Server

 Unit Test
 - XUnit

 Report
 - Reporting Services

## Intruções

Para executar o projeto, basta realizar a configuração da conexão com banco de dados, deve ser configurada no arquivo appsettings no backend, basta alterar a string de conexão para servidor desejado, o banco de dados (SQL Server) é criado quando a api é executada.

Para executar o frontend é necessario alterar o caminho da api no arquivo de config.ts, e utilizar o navegador com seguraças desabilitada por conta do cross-origin (somente para ambiente de desenvolvimento).

Foi utilizado o comando abaixo para execução no chrome.

    "chrome.exe" --disable-web-security --user-data-dir=c:\tmpChromeSession --ignore-certificate-errors

Para executar o relatorio é necessario ter uma instancia do Reporting Services configurada, e realizar upload do relatorio para a instancia e realizar alteração do caminho do relatorio no app.componet.html no frontend, o script dentro do projeto model no backend deve ser executado no banco de dados para criação da view.