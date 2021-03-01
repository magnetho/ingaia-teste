# Teste Ingaia

Olá esse é foi projeto desenvolvido para conforme proposto, foi desenvolvido  2 api REST aspnet core 3.1, sua execução no container Docker, e o armazenamento da imagem no Docker hub, para armazenamento e versionamento do do projeto foi utilizado o repositorio Github, no processo de papiline e release foi utilizado o Azure devops e para publicação o Heroku.



## Sumário
- [Frameworks utilizados](#fra)
- [Estrutura do projeto](#eprj)
- [Execução do projeto](#exprj)
- [Credenciais](#crd)
- [Pipeline e release](#ppr)
- [Considerações finais](#cf)



## <a name="fra"></a> Principais frameworks utilizados

| Frameworks   | utilização |
| ------ | ------ |
| Flurl | Request http |
| Bogus | Gerador de dados fakes para teste|
| Xunit | Utilizado no processo de teste  |
| Newtonsoft | Manipulador de dados no formato json |
| Swashbuckle | Gerar documentação swagger  |



|     |  |
| ------ | ------ |
| dotnet core 3.1  | cronstrução das Apis |
| Github | Repositorio |
| Git | Versionamento de codigo  |
| Docker  | Execução e Release do codigo |
| Azure Devops | Build, teste e release  |
| Heroku | Servidor para disponibilidade das apis   |

## <a name="eprj"></a> Estrutura do projeto
Apesar de ser um projeto relativamente simples, foi montado uma uma arquitetura para demostrar algumas conhecimentos de padrões adotados pela comunidade, Cada  Api foi montada 4 projetos Data, Domain, Api e test:

![alt text](./doc/img/structure.png?raw=true)

### Data 
Responsavel pela conexeção, e busca dos dasdos na base de dados. O data referencia apenas o Domain, Ma Api-01 ela é responsavel por buscar a informação do valor padrão do imovel. 
### Damain 
Projeto responsavel pelas entidades e suas regras assim como procetimentos na Api-02 ela é responsavel em busca a informação do valor padrão o imovel que estava na api-01, porem a implementão do serviço do busca fica no projeto api. que implementa um interface do domain.

### Api 
Responsavel pelos Endpoints assim como seu retorno https e as chamadas dos serviços e validação de entrada.Assim como a implementção da documentação nesse caso o Swagger
### Teste
Projeto responsavel pelos teste da aplicação, testes unitarios e teste de integração, nesses teste foi validado possiveis entradas e retornos de metodos e da propria api. 

### Docker 
foi criado 2 arquivos Docker files e docker-compose sendo que um arquivo de cada fica dentro da pasta "api-01" e a outra em "api-02" esses arquivos são responsaves por executar os projetos no container docker.


## <a name="exprj"></a> Execução do projeto

### Visual Studio
a execução do projeto no ambiente local pode ser efetuado de dua forma atraves do proprio visual estudio para quem tem o aspnet core 3.1 executando o seguinte comando

#### Api-01
```sh
Local: src\api-01\IngaiaService01.Api
dotnet run
```

#### Api-02
```sh
Local: src\api-02\IngaiaService02.Api
dotnet run
```

### Docker Container
Caso prefira pode executar no proprio contanier do docker abaixo o comando para execução  
#### Api-01
```sh
Local: src\api-01
dorker-compose up
```

#### Api-02
```sh
Local: src\api-02
dorker-compose up
```
![alt text](./doc/img/container-docker.png?raw=true)

Ou caso prefira pode pegar a imagem no proprio doker hub. Nesse modelo vc n precisa baixar o repositorio.  
#### Api-01
```sh
dorker pull  magnetho7/myapi:<versão>
```

#### Api-02
```sh
dorker pull  magnetho7/api-02:<versão>
```

## <a name="crd"></a> Credenciais
Foi criado um processo de pipeline e release do azure devops com mencionado acima, então foi gerado uma autenticação temporaria para esse projeto.
```sh
Link Projeto: https://dev.azure.com/nethoadm/ingaia-teste
Email: development-testing@outlook.com
Senha: Teste@2021
```

## <a name="ppr"></a> Pipeline e release
Conforme acima mencionado, para subir o projeto para o servidor e atualizar a imagem no docker hub é utilizado o Azure devops. No devops foi criado 2 pipeline  "ingaia-api-01" e "ingaia-api-02" em ambos vai gerar as builder, teste e push da imagem para Docker Hub. Caso todos os passos seja executados com sucesso essas pipelines ficam disponiveis para Release, A qual executada envia para o Heroku. 

![alt text](./doc/img/pipeline.png?raw=true)

Abaixo strutura de release:

![alt text](./doc/img/release.png?raw=true)


## <a name="cf"></a> Considerações finais

Apesar da simplicidade do projeto,  tentei mostrar um pouco do meu conhecimento tecnico, espero que seja suficiente, para um boa avaliação, estou a disposição para alguma explicação ou exposição desse material.
