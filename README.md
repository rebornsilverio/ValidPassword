# ValidPassword
Este projeto é uma API implementada em C# para validar uma senha seguindo os seguintes critérios:
- Considerar espaço em branco como caracter inválido
- Mínimo nove caracteres
- Ao menos 1 dígito
- Ao menos 1 letra minúscula
- Ao menos 1 letra maiúscula
- Ao menos 1 caractere especial
  - Considere como especial os seguintes caracteres: !@#$%^&*()-+
- Não possuir caracteres repetidos dentro do conjunto

## Como executar
A forma mais simples de executá-lo é, no Visual Studio:
* Abrir o arquivo da solução (arquivo ValidPassword.sln)
* No Gerenciador de Soluções, no projeto ValidPasswordAPI, click com o botão direito do mouse e escolha `Definir como Projeto de Inicialização`,
* Pressione F5 para iniciar a depuração.
* Depois de executar todos os passos acima, o Visual Studio abrirá o navegador chamando o endpoint padrão da controller. Altere para https://localhost:5001/validpassword/isvalid?password=SenhaQueDesejaValidar

## Estrutura dos arquivos
A solução está dividida em 4 projetos:
* `APIs/ValidPasswordAPI` - Interface REST
	`Controllers/ValidPassword` - Pasta com APIs - que para esta solução só foi necessária uma
* `Interfaces/ValidPasswordInferfaces` - Biblioteca com a interface implementada
* `Lib1/ValidPasswordLib` - Biblioteca com uma implementação da regra de negócios
* `Lib1/ValidPasswordMSTest` - Projeto de testes unitários da implementação da regra de negócios

## Decisões de design
Para mim faz muito sentido que as interfaces sejam agrupadas em uma biblioteca própria: dá às implementações delas o isolamento desejado, desde que cada implementação também esteja em uma biblioteca separada. 
Cada implementação das regras de negócio devem ficar em pastas `Lib-n` (que só implementei 1, na pasta `Lib1` da solução) e possui um projeto de teste unitário.
Os testes unitários que criei são apenas das regras de negócio. Os exemplos de execução foram usados em testes unitários, porém como não eram exaustivos implementei outros testes.
Nas regras de negócio, as regras para uma senha válida foram implementadas em métodos separados, para facilitar a manutenção, desconsiderando a performance da execução (aplicar todas as regras de forma mais aninhada traria um desempenho melhor).

