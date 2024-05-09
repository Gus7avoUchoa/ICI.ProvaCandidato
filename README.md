# Teste Prático de Desenvolvimento .NET

## Visão Geral
Teste prático para avaliar as habilidades de desenvolvimento .NET de Gustavo Uchôa, utilizando .NET 5 (.NET Core MVC) e VS2019. O foco está nas capacidades de back-end e front-end, incluindo Javascript.

## Estrutura do Projeto
O projeto `ICI.ProvaCandidato` é dividido em três camadas:
- **Apresentação**: `ICI.ProvaCandidato.Web`
- **Negócio**: `ICI.ProvaCandidato.Negocio`
- **Dados**: `ICI.ProvaCandidato.Dados`

## Modelo de Dados
Os candidatos devem criar entidades e utilizar Migrations para estruturar os dados no banco[^2^][2].

## Requisitos do Teste
- [ ] **CRUD de Tags**: Implementar visualização, cadastro, edição e exclusão de Tags.
- [ ] **Pesquisa de Tags**: Adicionar funcionalidade de busca por descrição na visualização de Tags.
- [ ] **Validação de Exclusão**: Verificar vínculos de Tags com notícias antes de excluir[^3^][3].
- [ ] **Visualização de Notícias**: Criar tela em formato de tabela para exibir notícias cadastradas[^4^][4].
- [ ] **Cadastro e Edição de Notícias**: Permitir o cadastro e edição de notícias, incluindo vinculação de Tags.
- [ ] **Limpeza de Formulário**: Adicionar botão para limpar campos do formulário com Javascript.
- [ ] **Validações**: Realizar validações tanto no lado do servidor quanto em Javascript.

## Critérios de Avaliação
Serão avaliados o uso de Migrations, Entity Framework, HTML, Razor, Javascript, funcionalidades, estrutura MVC e a organização do código.

## Entrega do Teste
Os candidatos devem enviar o projeto implementado junto com o arquivo de banco de dados ou script para sua criação[^5^][5].