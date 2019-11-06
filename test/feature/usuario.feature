Funcionalidade: Usuário

@US6
Cenario 1: Cadastrar um usuario
Dado que todos os campos estão preenchidos com dados validos
Quando eu fazer uma requisição post para /api/Clientes/post
Então o cliente deve ser salvo
E a resposta HTTP deve ser 201 Created