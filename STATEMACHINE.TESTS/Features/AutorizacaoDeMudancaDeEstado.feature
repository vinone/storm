Funcionalidade: Alterar um estado de uma máquina de estado
	Para alterar um estado a máquina deve verificar a alçada da transição
	Enquanto usuário da máquina de estado
	Eu quero avançar um estado

Cenario: Usuário com permissão
	Dado um usuário com cargo "Aprovador"
	Quando ele solicita a alteração de estado
	Entao o estado da máquina deve estar alterado

Cenario: Usuário sem permissão
	Dado um usuário com cargo "Não Aprovador"
	Quando ele solicita a alteração de estado
	Entao o estado da máquina deve ser igual ao inicial

Cenario: Transição sem alçada
	Dado uma transição de estado sem alçada
	Quando o usuário solicita a alteração de estado
	Entao o estado da máquina deve estar alterado