# Aplicação ToDoApp
É uma aplicação criada em c# para poder criar as listas de to-dos.
Aplicação disponivel na pasta ToDoApp_version_alpha_0.1.

#### Funcionalidades:
- Listar to-dos
- Adicionar to-dos
- Remover to-dos
- Alterar o estado dos to-dos para completed ou not complete
- Alterar o titulo dos to-dos

#### Formato dos to-dos:
- Id
- Titulo
- IsCompleted (Estado)

#### Program.cs metodos:
- ListToDos: dá display dos to-dos
- AddToDo: adiciona um to-do
- ChangeToDoStatus: muda o estado do to-do
- RemoveToDo: remove um todo
- UpdateToDoTitle: altera o titulo do to-do

#### TodoService.cs metodos:
- Load: a inicializar o serviço este metodo corre, para carregar a lista disponivel em todos.json na property _todos.
- ListAll: retorna a lista de todos os to-dos
- Add: adiciona um to-do a lista em _todos e faz save dela no ficheiro todos.json
- UpdStatus: muda o estado de um to-do com um Id especifico e faz save da alteraçao no ficheiro todos.json
- Remove: remove um todo com um Id especifico e e faz save da alteraçao no ficheiro todos.json
- UpdateTitle: altera o titulo de um to-do com um Id especifico e e faz save da alteraçao no ficheiro todos.json

#### Para melhorar na aplicação:
O código precisa de ser melhor organizado, alguns metodos podem ser merged e improved. E os metodos precisam de ser documentados.

# Testes da aplicação ToDoApp:
Os testes disponiveis para a aplicação são:
- List_All_ToDos_Test: testa a listagem de to-dos
- Add_ToDo_Test: testa a adição de um to-do
- Update_ToDo_Title_Test: testa a alteração do titulo de um to-do
- Update_ToDo_Status_Test: testa a alteração do estado de um to-do
- Remove_ToDo_Test: testa a remoção de um to-do

#### Para melhorar nos testes:
Atualmente os testes disponiveis são apenas os positive tests, ainda vai ser preciso adicionar negative tests. Também é preciso rever os testes atual para verificar se não é possivel melhora-los.