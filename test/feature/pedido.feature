Funcionalidade: Pedido

@US3
Cenário 1: Fazer um pedido de uma Pizza grande com bebida
Dado que todos os campos então preenchidos com dados validos
E que o tamanho da Pizza é do tamanho grande
E que um item do tipo bebida está sendo enviado na requisição
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido deve ser salvo
E a resposta HTTP deve ser 201 Created

Cenário 2: Fazer um pedido de uma Pizza pequena
Dado que todos os campos então preenchidos com dados validos
E que o tamanho da Pizza é do tamanho pequena
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido deve ser salvo
E a resposta HTTP deve ser 201 Created

Cenário 3: Fazer um pedido de uma Pizza média com bebida
Dado que todos os campos então preenchidos com dados validos
E que o tamanho da Pizza é do tamanho médio
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido deve ser salvo
E a resposta HTTP deve ser 201 Created

@US1
Cenario 4: Fazer um pedido de um combo
Dado que todos os campos então preenchidos com dados validos
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido deve ser salvo
E a resposta HTTP deve ser 201 Created

@US4 @US2 @US3
Cenario 5: Fazer um pedido de duas Pizzas, uma pequena e outra média, ambas com dois sabores e uma bebida
Dado que todos os campos então preenchidos com dados validos
E que dois itens do tipo Pizza foram adicionados a requisição
E que um item está com o tipo grande
E o outro está com o tipo médio
E que o item sabores está com dois itens em ambas as pizzas
E que um item do tipo bebida está sendo enviado na requisição
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido deve ser salvo
E a resposta HTTP deve ser 201 Created

@US7
Cenário 6: Visualizar pedidos pendentes
Dado que existem pedidos pendentes
Quando eu fazer uma requisicao de GET para /api/Pedidos/GetNotDone
Entao os pedidos pendentes devem ser retornados no corpo da resposata
E a resposta HTTP deve ser 200 OK

Cenário 7: Atualizar status do pedido para completo
Dado que existem pedidos pendentes
E que a requisição está com o dado que altera o status para completo
Quando eu fizer uma requisição PATCH para api/Pedidos/<ver o param>
Então o pedido deve ser atualizado para completo
E a resposta HTTP deve ser 200 OK

Cenário 8: Fazer um pedido com dados invalidos
Dado que todos os campos então preenchidos com dados invalidos
E todos os campos string estao com dados do tipo integer
E todos os campos do tipo number estao com strings
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido nao deve ser salvo
E a resposta HTTP deve ser 400 Bad Request

Cenário 9: Fazer um pedido enviando um numero do tipo float na quantidade
Dado que todos os campos então preenchidos com dados validos
E o campo quantidade esta preenchido com um valor do tipo float
Quando eu fazer uma requisição post para /api/Pedidos/post
Então o pedido nao deve ser salvo
E a resposta HTTP deve ser 400 Bad Request

Cenário 10: Alterar o status do pedido para concluido
Dado que existe um pedido
E ele esta com status de pendente
Quando eu fazer uma requisição post para /api/Pedidos/postdone
Então o pedido deve ser atualizado para o status de done
E a resposta HTTP deve ser 200 OK