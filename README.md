# Booktopia
Gerenciador de Aluguéis de Livros

## Tecnologia Utilizadas

### Back-End:
- C#
- ASP.NET Core
- Entity Framework
- Identity ASP.NET Core
- SQL Server

### Front-End:
- Bootstrap
- JavaScript
- HTML
- CSS

## Regras de Negócio
- O cliente deve está cadastrado no sistema para poder realizar um aluguel;
- Caso o cliente não esteja na base de dados, deverá ser feito seu cadastro previamente;
- O cliente tem um prazo de 10 dias para devolver o livro, caso atrase, pagará uma multa de R$ 1,00 por dia;
- O administrador do sistema deverá cadastrar cliente e atualizar dados cadastrais;
- O administrador do sistema deverá manter o controle de livro (adicionar, desativar editar e reativar);
- O administrador do sistema deverá gerenciar os aluguéis (adicionar aluguel e realizar devolução).

## Recursos
- Ao Alugar um livro, diminui o estoque automaticamente. Assim como ao devolver, o estoque aumenta.
- Se o estoque de livros zerar, ele é desativado automaticamente.
- Livro, Cliente e Aluguel não poderão ser apagados da base de dados, mas um livro pode ser desativado e reativado.
