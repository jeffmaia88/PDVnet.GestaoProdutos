# PDVnet.GestaoProdutos
## Aplicação desktop em C# com WPF e SQL Server para gestão de produtos em estoque.


**Sistema desktop desenvolvido em C# com WPF e SQL Server para gerenciamento de produtos em estoque.

O objetivo do projeto é avaliar meus conhecimentos em C#, foi utilizado por mim aqui, 4 camadas (Model, Data, Business e UI), para separação de responsabilidades.
Utilziei 3 ClassLibraries (Model, DATA,Business) e um projeto WPF (UI).

- Segui exatamente a orientação de diretórios e nomenclaturas disponibilizado no PDF via e-mail.
- Segui os requisitos obrigatórios e funcionalidades extras solicitadas, o Sistema implementa as funcionalidades de Adicionar, Editar, Excluir e Listar os rodutos em estoque.
- Listei os produtos em um DataGrid, que atualiza automaticamente a cada operação de inserção, edição ou exclusão.
- Implementei os Dashboards solicitados, que mostram o numero total de produtos, o valor total de estoque, a quantidade de produtos com baixo estoque e um alerta nos produtos com baixo estoque na grid.

- Usei banco de dados SQL Server, com um banco chamado GestaoProdutosDB e uma tabela chamada Produtos.
- Utilizei um container docker que copstumo utilizar com SQL Server já configurado, em conjunto com o Azure Data Studio para gerenciar o banco de dados.
- A string de conexão está configurada no arquivo App.config do projeto WPF (UI).

## Funcionalidades do Sistema

O sistema foi desenvolvido para atender todos os requisitos obrigatórios solicitados no PDF, além de implementar algumas funcionalidades extras.


### Funcionalidades principais
- **Cadastro de produtos:**  Insere novos produtos no estoque, informando nome, descrição(opcional), preço e quantidade.
- **Edição de produtos:**  Ao Selecionar o Produto no Grid, permite alterar os dados de um produto já cadastrado.
- **Exclusão de produtos:** Ao Selecionar o Produto no Grid, permite remover um produto do banco de dados, com mensagem de confirmação antes da exclusão.
- **Listagem de produtos:** Mostra todos os produtos cadastrados uma grade (DataGrid), com atualização automática após cada operação.

### Relatórios e dashboards
- **Total de produtos cadastrados.**
- **Valor total do estoque (soma de Preço x Quantidade).**
- **Produtos com baixo estoque (quantidade menor que 5).**
- **Destaque visual na grid para produtos com baixo estoque.**

### Validações e regras de negócio
- Contém validação de entradas nos campos numéricos (impede digitação de letras em preço e quantidade).
- É feito a verificação de campos obrigatórios antes do cadastro.
- Há bloqueio de valores negativos para preço e quantidade.
- É feito o tratamento de erros e mostrada mensagens ao usuário.

### Funcionalidades extras implementadas
- Atualização dinâmica do DataGrid após operações de CRUD.
- Confirmação de exclusão antes da remoção de registros.
- Exibição formatada da data de cadastro e preço (padrão brasileiro, dd/MM/AAAA e R$).
- Destaque em vermelho nas linhas do DataGrid com baixo estoque.
- Atualização do Dashboard, após clique no botão atualizar.

## Estrutura do Projeto

Como mencioneia cima o projeto foi desenvolvido utilizando separação por camadas, para organizar o código e facilitar manutenção e entendimento do sistema.

Abaixo estão as camadas e suas responsabilidades principais:

### Model
Camada responsável pelas classes que representam as entidades do sistema.
No projeto, há apenas uma Classe, a classe `Produto`, que define as propriedades principais (Id, Nome, Descrição, Preço, Quantidade e Data de Cadastro).

### Data
Camada responsável pela comunicação com o banco de dados SQL Server.  
Aqui ficaram as classes `ConnectionHelper` (que faz a conexão) e `ProdutoRepository` (que executa os comandos SQL para inserir, editar, excluir e listar produtos).

### Business
Camada responsável pelas regras de negócio e validações.  
Contém as classes `ProdutoService` (lógica do CRUD), a RelatórioService (Responsável pela lógica dos Dashboards, e criada fora do escopo do PDF, para diminuir as responsabildiades da ProdutoService) e `ProdutoValidator` (validação dos dados antes de salvar no banco, como pedido nas funcionalidades extras).

### UI (WPF)
Camada de interface com o usuário, desenvolvida com WPF.  
Contém as telas `MainWindow` e `ProdutoForm`, além das classes `MainViewModel` e `ProdutoFormViewModel`, que fazem a comunicação entre a interface e as regras de negócio.


## Como executar o sistema

Abaixo estão as instruções básicas para rodar o projeto localmente.  
O sistema foi desenvolvido e testado em ambiente Windows 11 com Visual Studio 2022.

### 1. Banco de dados SQL Server
O sistema utiliza SQL Server como banco de dados.  
Como dito anteriormente, eu utilizei um container docker, pois já utilizo-o em outros projetos aqui e otimiza meu trabalho, mas pode ser rodado em uma instancia local.  

O script de criação do banco e da tabela está disponível na pasta **Data/Scripts** dentro do projeto.

Nome do banco: `GestaoProdutosDB`  
Nome da tabela: `Produtos`

### 2. Configuração da conexão
A string de conexão já está configurada no arquivo **App.config** do projeto WPF (UI).  
Por padrão, ela está assim:

```<connectionStrings> <add name="PDVnetConnection" connectionString="Server=localhost;Database=GestaoProdutosDB;User Id=sa;Password=MINHASENHA;Encrypt=True;TrustServerCertificate=True;" providerName="System.Data.SqlClient"/> </connectionStrings> ```

Se você utilizar outro servidor, usuário ou senha, basta ajustar os valores acima.

### 3. Executando o Sistema

- Abra o projeto no Visual Studio 2022
- Certifique-se de que o projeto PDVnet.GestaoProdutos.UI está definido como projeto de inicialização
- A Tela principal MainWindow será carregada por padrão, exibindo o dashboard e alista de produtos.
- 

## Considerações Finais

Este projeto foi desenvolvido exclusivamente para esse processo seletivo para testar meus conhecimentos práticos em C#, WPF e SQL Server. 
Independente do resultado, irei deixá-lo no meu portfolio pessoal, foi legal desenvolvê-lo nesses 4 dias. 

Procurei seguir ao máximo as instruções do PDF enviado, respeitando a estrutura de camadas e as nomenclaturas sugeridas.  
Evitei o uso de bibliotecas externas, Frameworks ou recursos automáticos, priorizando código simples e legível.

Durante o desenvolvimento, optei por implementar algumas melhorias e ajustes além do escopo original, como separação de serviços, validações manuais e mensagens de confirmação, buscando deixar o sistema mais completo e com uma estrutura próxima de um projeto real.

O foco principal foi mostrar minha capacidade de entender o problema, planejar a solução e entregar um sistema funcional, com uma boa organização e clareza no código, e é claro, ser selecionado.


## Autor

**Jefferson Reis**
Desenvolvedor.Net — C#, SQL, ASPNET, WPF
**Email:** [jefferson.reis88@gmail.com](mailto:jefferson.reis88@gmail.com) 
**LinkedIn:** [linkedin.com/in/jefferson-maia88](https://www.linkedin.com/in/jefferson-maia88/) 
**Portfólio:** [github.com/jeffmaia88](https://github.com/jeffmaia88)