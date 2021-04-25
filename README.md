# desafioSoftplanApi

Projeto Web API desenvolvido a partir do Asp.Net Core, utilizando Swagger para gerar a documentação e interface gráfica dos endpoints.

- Implementação do Endpoint /taxajuros, que retorna a taxa de juros atual, fixa em 1%.

- Implementação do Endpoint /calculaJuros, que realiza o cálculo de juros compostos, consumindo a taxa de juros atual. 
A fórmula para esse cálculo é ValorInicial(decimal) * (1 + TaxaJuros) ^ MesesCorridos(int). Tanto ValorInicial quando MesesCorridos são parâmetros fornecidos pelo usuário.
Para resolver a operação de potência foi utilizada a bilbioteca Math, através de seu método Pow, que recebe dois números double e retora um double com o resultado.

- Implementação do Endpoint /showmethecode, que retorna uma URL(string) contendo o endereço do projeto hospedado no GitHub.

# Testes

O projeto também conta com alguns testes unitários automátizados, separados dentro da namespace desafioSoftPlanTestes.

# Configurações

- O projeto deve rodar na porta 5001, através do servidor de aplicações IIS. Caso opte por utilizar outra porta, é necessário ajustar a injeção de dependência da URI informada,
dentro do arquivo Startup.cs, dentro do método ConfigureSerivces, alterando o AddScoped que injeta a interface ICalculaJuros.

# Boas práticas

O projeto foi escrito utilizando boas práticas de orientação a objetos, princípios do S.O.L.I.D. e Clean Code. Citando alguns deles, é possível notar o Single Responsability
Principle, que garante que cada método possui uma e somente uma responsabilidade. A implementação da injeção de dependência dos mecanismos nativos do .Net Core também garante
o princípio Dependecy Inversion Principle.

Além disso, os nomes de métodos, variáveis e testes respeitam o princípio da Importância dos Nomes. Cada um deles possui o nome coeso em relação ao comportamento e função, 
garantindo fácil compreensão do código.
