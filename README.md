<h1 align="center">📊 Calculadora IMC</h1>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8-informational?style=flat&logo=dotnet&logoColor=white" alt=".NET 8"/>
  <img src="https://img.shields.io/badge/WPF-Desktop-blue" alt="WPF"/>
  <img src="https://img.shields.io/badge/MVVM-Pattern-lightgrey" alt="MVVM"/>
  <img src="https://img.shields.io/badge/JSON-Persistence-orange" alt="JSON"/>
</p>

<hr>

<h2>📄 Descrição</h2>
<p>
Esta aplicação desktop foi desenvolvida em <strong>C# com WPF (.NET 8)</strong>, seguindo o padrão <strong>MVVM</strong>. 
O objetivo é permitir o <strong>cadastro e gerenciamento de usuários</strong>, registrar suas medições de <strong>peso e altura</strong> e exibir a evolução do <strong>Índice de Massa Corporal (IMC)</strong> através de gráficos interativos.
</p>

<hr>

<h2>✅ Funcionalidades</h2>

<h3>1. Cadastro e Gerenciamento de Usuários</h3>
<ul>
  <li>Cada usuário possui um <strong>identificador único</strong> (GUID).</li>
  <li>Campos obrigatórios: nome, idade, gênero, peso inicial e altura.</li>
  <li>Adicionar, listar e remover usuários.</li>
  <li>Busca dinâmica por nome de usuário.</li>
</ul>

<h3>2. Medições de Peso e Cálculo de IMC</h3>
<ul>
  <li>Adicionar novas medições de peso para cada usuário.</li>
  <li>Cálculo automático do IMC pela fórmula:</li>
  <pre><code>IMC = peso / (altura²)</code></pre>
  <li>Histórico completo de medições (peso, data e IMC calculado).</li>
  <li>Gráfico de evolução do IMC ao longo do tempo.</li>
</ul>

<h3>3. Persistência de Dados</h3>
<ul>
  <li>Todos os dados são salvos localmente em <code>AppData\Local\Calculadora IMC\usuarios.json</code>.</li>
  <li>Utiliza a biblioteca <strong>Newtonsoft.Json</strong> para serialização/desserialização.</li>
  <li>Ao iniciar a aplicação, os dados são carregados automaticamente do arquivo JSON.</li>
</ul>

<h3>4. Interface Gráfica (WPF + MVVM)</h3>
<ul>
  <li>Janela principal com lista dinâmica de usuários e campo de busca.</li>
  <li>Botão para adicionar novos usuários.</li>
  <li>Janela de detalhes do usuário exibindo:
    <ul>
      <li>Dados básicos do usuário</li>
      <li>Histórico de medições</li>
      <li>Campo para adicionar nova medição de peso</li>
      <li>Gráfico da evolução do IMC</li>
    </ul>
  </li>
</ul>

<hr>

<h2>🛠 Tecnologias Utilizadas</h2>
<ul>
  <li>C# (.NET 8)</li>
  <li>WPF</li>
  <li>MVVM</li>
  <li>Newtonsoft.Json</li>
  <li>LiveCharts</li>
</ul>

<hr>

<h2>📂 Estrutura do Projeto</h2>
<pre><code>
/Calculadora IMC
│
├─ /Core         # Classes de lógica central
├─ /Models       # Classes de Usuário e Medição
├─ /Services     # Serviços de persistência de dados e navegação entre telas
├─ /Styles       # Recursos de estilo
├─ /ViewModels   # Lógica de apresentação e bindings
├─ /Views        # Telas WPF
├─ App.xaml      # Configurações e inicialização da aplicação
├─ App.xaml.cs   # Code-behind da App.xaml
├─ AssemblyInfo.cs # Informações do assembly
├─ Calculadora IMC.csproj # Arquivo de projeto C#
└─ Calculadora IMC.csproj.user # Arquivo de configuração do usuário do projeto
</code></pre>

<hr>

<h2>🚀 Como Executar</h2>
<ol>
  <li>Clone o repositório:
    <pre><code>git clone https://github.com/luanbsc/Calculadora-IMC.git</code></pre>
  </li>
  <li>Abra o projeto no <strong>Visual Studio 2022</strong> ou superior.</li>
  <li>Certifique-se de que os pacotes NuGet (<strong>Newtonsoft.Json</strong> e <strong>LiveCharts</strong>) estão restaurados.</li>
  <li>Execute a aplicação (<code>F5</code>) e interaja com a interface.</li>
</ol>

<hr>

<h2>📸 Demonstração</h2>
<p align="center">
  <img src="demo.gif" alt="Exemplo da Aplicação" width="600"/>
</p>

<hr>

<h2>ℹ Observações</h2>
<ul>
  <li>Todos os critérios funcionais da atividade foram atendidos.</li>
  <li>O arquivo <code>usuarios.json</code> é atualizado automaticamente a cada alteração.</li>
  <li>A aplicação permite acompanhar a evolução do IMC de cada usuário de forma prática e visual.</li>
</ul>

<hr>

Este projeto foi uma oportunidade valiosa de aprendizado e crescimento na minha jornada com desenvolvimento desktop em C# e WPF. Ao implementá-lo, aprofundei meus conhecimentos em <strong>MVVM</strong>, manipulação de dados com <strong>JSON</strong> e criação de interfaces gráficas interativas. 


Obrigado por visitar este projeto! 🎉<br>
