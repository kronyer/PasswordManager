# Password Manager

Password Manager (falta um nome bom) é um gerenciador de senhas online no estilo Bitwarden, com criptografia das senhas no banco de dados.  
Uma combinação de C#, com o .NET MVC e SQL server e um pouco de JavaScript



https://github.com/kronyer/PasswordManager/assets/152650887/e24a7b21-ff89-4356-8b9c-0575b5b7b4a6



## Features
- Autenticação através do scaffold do Razor
- Senha armazenada com Criptografia AES
- Padding PKCS7 para tornar impossível saber o tamanho da senha original
- Geração de senha aleatória personalizada através de JavaScript
- A senha é descriptografada apenas ao ser chamada pelo usuário correto, com a key respectiva, e não é armazenada no banco de dados

## Sobre a Criptografia
- A senha é criptografada com o padrão AES
- Cada usuário registrado possui sua key para descriptografar aleatória gerada
- Em cada senha é adicionado um salt de 32 caracteres 
- Cada senha possui seu IV aleatório para a geração da senha
- É utilizado um padding PKCS7

## Desafios enfrentados
- O CRUD é relativamente fácil de ser implementado, a dificuldade foi aprender a fazer uma chamada do javascript para gerar a senha aleatória diretamente na view do Create
- Precisei estudar um pouco de criptografia e da biblioteca de criptografia da Microsoft (e foi muito interessante)

## Mudanças futuras
- A key do usuário talvez devesse ser protegida, ou nao constar no banco de dados. Pensar uma alternativa para validar a key do usuário sem ter ela no banco de dados
