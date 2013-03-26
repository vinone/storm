Funcionalidade: Uma máquina de estado deve trazer os estados com as ações e transições baseando-se no perfil de acesso do usuário que iniciou a máquina de estado
				Como um desenvolvedor
				Eu quero poder definir perfis de acesso por grupos e relaciona-los com os estados e suas ações

Cenario: O perfil de acesso do usuário deve carregar seus estados
	Dado um usuário com perfil de officer 
	Quando a máquina de estado é iniciada pelo usuário com perfil de officer
	Entao o perfil deve validar os estados como a seguir
		| Nome            |
		| Em Negociação   |
		| Desistência     |
		| Análise Crédito |
		| Aprovado        |
	E os estados devem estar com as suas transições