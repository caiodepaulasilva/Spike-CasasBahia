<p align="center">  
  <img src="https://github.com/caiodepaulasilva/Prova-Deliver-IT/assets/36136627/dde0c669-e09b-45ae-a2ea-fcf15de8cc7b"/>
  <br><br>
  <img src="https://img.shields.io/badge/status-work%20in%20progress-red?style=for-the-badge"/>  
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>  
  <img src="https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=c-sharp&logoColor=white"/>    
</p>

## Introdução

Este trabalho foi desenvolvido como parte de um processo seletivo no qual o objetivo é construir um projeto de desenvolvimento web em que algumas habilidades possam ser exercitadas. E são elas:
- Domínio da construção de uma API baseada na arquitetura de Domain-Driven-Design
- Domínio de uso de Dependency Injection e Automapper
- Domínio de uso de Docker para criação de instâncias
- Domínio da construção de testes unitários
- Domínio de integração com SQL Server
- Domínio de integração com Kafka
- Domínio do framework .NET 8.0
- Domínio da capacidade analitica, de abstração e de construção de um algoritmo que reflita as boas práticas de programção e o uso razoável da linguagém C# para construção de APIs.

**Anexo**: O exerício proposto consta neste documento: [Estudo de Caso.pdf](https://github.com/caiodepaulasilva/Spike-CasasBahia/files/15151307/Estudo.de.Caso.pdf)
<br><b>


## Requerimentos
 O projeto tem uma construção parcialmente simples e, portanto, são necessárias apenas algumas poucas dependências para a sua execução. São esperados os seguintes requerimentos:

- Microsoft Visual Studio (versão 2010 ou superior)
- SDK .NET (versão 8.0 ou superior)
- Browser de navegação Web
- SQL Server Managament Studio
- Docker Desktop
- IIS Express

## Execução
O projeto necessita que duas dependências diretas sejam consideradas antes de sua execução. A configuração de um servidor **SQL Server** e uma plataforma **Apache Kafka**. Uma vez configurados, a execução da API se tornar então possível. Segue passo-a-passo de como configura-los:

**Clonar o projeto:**
```
cd "diretorio de sua preferencia"
git clone https://github.com/caiodepaulasilva/Spike-CasasBahia.git
```

**Criar Container Kafka:**
1. Uma vez no Visual Studio, no terminal PowerShell do Desenvolvedor, na raiz do projeto, digite:
```
cd "Infrastructure\Dependencies\Kafka"
docker-compose up -d
```
2. Verifique o bom funcionamento através do Docker Desktop. Os containers devem ter sido criados com sucesso e estarão em execução.
    1. É possível validar, por exemplo, os eventos realizados na integração com o Kafka pelo kafdrop (default: [localhost:19000](http://localhost:19000/))

**Criar Container SQL Server:**
1. Abra o arquivo docker-compose.yaml e defina uma senha para o servidor, através da variável *"SA_PASSWORD"*
2. Uma vez no Visual Studio, no terminal PowerShell do Desenvolvedor, na raiz do projeto, digite:
```
cd "Infrastructure\Dependencies\SQL Server"
docker-compose up -d
```
3. Verifique o bom funcionamento através do Docker Desktop. Os containers devem ter sido criados com sucesso e estarão em execução.
4. Verifique se é possível estabelcer conexão com o servidor. Para isso tente realizar a conexão através do SQL Server Managament Studio da seguinte maneira:

| Campo do Formulário de Conexão | Valor                               |
| ------------------------------ | ----------------------------------- |
| Server Type                    | Database Engine                     |
| Server Name                    | localhost                           |
| Authentication                 | SQL Server Authentication           |
| Login                          | sa                                  |
| Password                       | <SA_PASSWORD> (docker-compose.yaml) |
| Trust server certificate       | checked                             |

**Criar a estrutura da base de dados:**
2. Uma vez no Visual Studio, no terminal PowerShell do Desenvolvedor, na raiz do projeto, digite:
```
dotnet clean
dotnet ef migrations add InitialCreate --project Infrastructure --startup-project Spike-CasasBahia
```
Após a execução destas instrunções, deve ser possível executar o projeto normalmente.

## Licença

[MIT licensed](./LICENSE).
