Funcionalidade: Uma transição pendente de aprovação deve ser liberada por usuários aprovadores
	Para que uma transição seja aprovada
	Enquanto um usuário aprovador de alçadas
	Eu quero visualizar as transições pendentes de minha aprovação

Cenario: Transição nova
	Dado um usuário sem permissão altera o estado da máquina
	Quando a transição solicitar aprovação para a mudança
	Entao deve ser criado uma pendência para o usuário aprovador

Cenario: Transição pendente
	Dado um usuário com permissão de aprovação
	Quando o usuário inicia uma máquina de estado
	Entao o usuário deve visualizar as transições pendentes de aprovação

Cenario: Transição aprovada
	Dado um usuário com permissão de aprovação
	Quando o usuário inicia uma máquina de estado
	Entao o usuário deve visualizar as transições pendentes de aprovação
	Quando o usuário aprova as transições pendentes
	Entao não deve existir pendencias