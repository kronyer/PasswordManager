# Password Manager

Password Manager (falta um nome bom) é um gerenciador de senhas online no estilo Bitwarden, com criptografia das senhas no banco de dados.  
Uma combinação de C#, com o .NET MVC e SQL server e um pouco de JavaScript

## Features
- Autenticação através do scaffold do Razor
- Senha armazenada com Criptografia AES
- Salt de 32 caracteres para cada senha
- IV aleatório para cada senha guardado no banco de dados
- Key aleatória gerada para cada usuário registrado
- Padding PKCS7 para tornar impossível saber o tamanho da senha original
- Geração de senha aleatória personalizada através de JavaScript
- A senha é descriptografada apenas ao ser chamada pelo usuário correto, com a key respectiva, e não é armazenada no banco de dados

## Desafios enfrentados
- O CRUD é relativamente fácil de ser implementado, a dificuldade foi aprender a fazer uma chamada do javascript para gerar a senha aleatória diretamente na view do Create
- Precisei estudar um pouco de criptografia e da biblioteca de criptografia da Microsoft (e foi muito interessante)
