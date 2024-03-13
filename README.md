<h1 align="center">MVC Contatos <img src="https://raw.githubusercontent.com/tomchen/stack-icons/master/logos/c-sharp.svg" width="30px"></h1>
<br/>

<h2>Sobre:</h2>
<p>Este projeto consistem em uma aplicação MVC em ASP.Net usando .Net 8.0, onde podemos cadastrar usuários, fazer logins e cadastrar contatos.</p>

<h2>Ferramentas Utilizadas:</h2>
<ul>
  <li>ASP.Net MVC Web Application</li>
  <li>Microsoft.EntityFrameworkCore</li>
  <li>Microsoft.EntityFrameworkCore.Design</li>
  <li>Microsoft.EntityFrameworkCore.SqlServer</li>
  <li>Microsoft.EntityFrameworkCore.Tools</li>
</ul>

<h2>Explicando o conceito do MVC:</h2>
<ul>
  <h3><li>Views:</li></h3><br/>
	<p>
		A partir das Views, podemos visualizar os dados, por ser uma aplicação Web, manipulamos de forma que possamos visualizar na web.
	</p>
	<h3><li>Models:</li></h3><br/>
	<p>
		A partir das Models, modelamos nossas entidades para criarmos relacionamentos entre elas, e isso é possível através do EntityFrameworkCore.
	</p>
	<h3><li>Contexto do Banco de Dados:</li></h3><br/>
	<p>
		Podemos criar um arquivo de contexto do banco de dados ao finalizar nossas models e maps, sendo assim, podemos executar migrations e atualizar
		o nosso banco de dados quando necessário.
	</p>
	<h3><li>Interfaces:</li></h3><br/>
	<p>
		Explicando de uma maneira simples, as interfaces são classes que são feitas para serem herdadas, como se fosse uma classe abstrata, porém,
		apenas aplicamos métodos a elas.
	</p>
	<h3><li>Implementação da interface:</li></h3><br/>
	<p>
		Podemos criar uma pasta repositório que guardam classes que implementam interfaces, desta maneira, a implementação de uma interface é feita
		de uma forma mais organizada e limpa. <br/>
		OBS.: Não é possívem fazer uma injeção de dependência de uma interface dentro de outra.
	</p>
	<h3><li>Controller:</li></h3><br/>
	<p>
		Onde controlamos as ações da API, com os métodos HTTP GET, POST, PUT e DELETE, onde também é aplicada a regra de negócio da aplicação.
	</p>
	<h3><li>Program.cs:</li></h3><br/>
	<p>
		Não podemos nos esquecer de adicionar o escopo das injeções de dependência das nossas interfaces, além de configurarmos o EntityFramework.
	</p>
</ul>
