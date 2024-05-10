# Teste Prático de Desenvolvimento .NET

## Visão Geral
Teste prático para avaliar as habilidades de desenvolvimento .NET de Gustavo Uchôa, utilizando .NET 5 (.NET Core MVC) e VS2019. O foco está nas capacidades de back-end e front-end, incluindo Javascript.

## Estrutura do Projeto
O projeto `ICI.ProvaCandidato` é dividido em três camadas:
- **Apresentação**: `ICI.ProvaCandidato.Web`
- **Negócio**: `ICI.ProvaCandidato.Negocio`
- **Dados**: `ICI.ProvaCandidato.Dados`

## Modelo de Dados
Deve ser criado entidades e utilizar Migrations para estruturar os dados no banco.

## Requisitos
1. 🚧 Migrations
   - [x] Criar entidades e executar a criação da estrutura dos dados no banco utilizando Migrations.

2. 🏷️ CRUD de Tags
   - [x] Desenvolver a tela de visualização das Tags cadastradas.
   - [x] Implementar as telas de cadastro e edição de Tags.

3. 🔍 Pesquisa de Tags
   - [ ] Na tela de visualização de Tags, desenvolver um campo de pesquisa por descrição da Tag.
   - [ ] Exibir o conteúdo correspondente na tabela de visualização.

4. ❌ Exclusão de Tags
   - [ ] Validar se uma Tag está vinculada a uma notícia antes de excluir.
   - [ ] Retornar uma mensagem informando que não foi possível excluir caso haja o vínculo.

5. 📰 Visualização de Notícias
   - [ ] Desenvolver a tela de visualização das notícias cadastradas em forma de tabela.
   - [ ] A tabela deve ter uma coluna para cada informação da notícia.

6. ✏️Cadastro e Edição de Notícias
   - [ ] Desenvolver a tela de cadastro e edição de notícia.
     - [ ] Permitir cadastrar e editar todas as informações da notícia e vincular uma lista de Tags a este cadastro.
     - [ ] Implementar função de exclusão.

7. 🧼 Funcionalidade de Limpeza de Formulário
   - [ ] Na tela de cadastro e edição, implementar um botão que limpe os campos do formulário, executando essa ação com Javascript.

8. ✔️ Validações
   - [ ] Realize validações Server-Side e também em Javascript antes de salvar o registro.

## Critérios de Avaliação
Será avaliado o uso de Migrations, Entity Framework, HTML, Razor, Javascript, funcionalidades, estrutura MVC e a organização do código.

## Entrega do Teste
Enviar o projeto implementado juntamente com o arquivo de banco de dados (ou script para criação do mesmo).