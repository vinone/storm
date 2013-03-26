Funcionalidade: Controlar transições pendentes de aprovação
	Para que uma transição pendente seja liberada
	Enquanto um usuário aprovador de transições
	Eu quero poder aprová-las de forma visual e detalhada

Cenario: Criado uma nova pendencia
	Dado que uma maquina de estado foi iniciada
	E que um usuário sem permissão solicitou a transiçao de estado
	E que foi criado uma nova pendencia
	Quando eu solicitar a maquina de estado as minhas pendencias
	Entao a maquina de estado deve retornar 1 pendencia na lista