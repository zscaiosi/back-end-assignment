## How to execute and test the project:
#### Prerequistes:
- Docker
- WebBrowser
- MongoDB running on port 27017
- Modify appsettings.json with your own credentials
#### Run the following scripts:
- Runs and populate mongoDB: mongo localhost:27017/test ./back-end-assignment/mongobulk.js
- Builds and runs docker containers: cd ./back-end-assignment/publishScript.sh
- Runs PWA: cd ./products-evoxsolutions-pwa && npm run build && serve -p 80 -s build
- Runs TDD: cd ./back-end-assignment/Products.API.Tests && dotnet test

## Briefing
Uma aplicação composta por 2 microserviços, um de autorização e outro de gerenciamento de compras de produtos por atacado.

O usuário pode criar produtos e fazer compras através do PWA
## Original
Elabore uma aplicação exemplo **RESTful**, ou seja, a aplicação deverá aplicar os princípios de **REST** a partir da criação de uma **WebApi**. Esse exemplo será um CRUD simples e deverá ser integrado a uma camada de front **(o layout e elementos gráficos não serão avaliados, apenas a parte de lógica e integração, preferencialmente o uso de Vue.js ou React).** 
 
São requisitos técnicos, a estruturação do projeto utilizando **.NET Core**, como prática de desenvolvimento, o **BDD** e a realização de ao menos um **teste unitário**. 
 
A aplicação deverá ser composta de telas de cadastro, bem como suas telas de consulta. Fica a critério do candidato a definição do contexto (objetos) que será utilizado para a aplicação. 
 
As camadas de **front/back** deverão estar **segregadas** e se comunicar via **API**. 
 
Todos os nomes de métodos, variáveis e classes devem estar escritos em inglês. 
 
Serão considerados critérios de avaliação: 
- Quantidade de erros ou warnings;
- Complexidade do cenário proposto pelo candidato bem como complexidade das entidades; 
- Limpeza do código;
- Coerência no padrão de desenvolvimento e nomenclatura; 
- Utilização coerente de programação orientada a objetos; 
- Conhecimentos técnicos das tecnologias utilizadas, principalmente de .NET Core e WebAPI; 
 - Organização e isolamento da camada de negócio. 
 
A aplicação deverá ser feita remotamente pelo candidato, que deverá fornecer completamente o código da aplicação, scripts de banco de dados (caso tenha) e um documento com instruções de deploy, instalação e configuração, bem como informações de TODAS as tecnologias utilizadas com o **prazo máximo de 5 dias corridos**.
 
Caso o candidato encontre dificuldade em alguma tecnologia ou técnica, o mesmo poderá prosseguir da forma que lhe for mais natural, mesmo que isso signifique não utilizar as técnicas e tecnologias solicitadas, porém, o não emprego das técnicas e tecnologias solicitadas influenciará na determinação do nível de senioridade do candidato. 


**Boa sorte!!**
