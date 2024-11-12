# LeadFrwk.Solution

A solução foi realizada com o objetivo de gerenciar os leads, listando com convites enviados, aceitos e declinados, possibilitando o usuário a aceitar ou declinar.
Caso seja aceito, o lead é listado na aba de "Aceitos" e o serviço simula o envio de um e-mail, além de aplicar um desconto de 10% sobre o valor, caso o preço seja acima de $500.

# Instruções:
Para que a solução seja compilada basta seguir os passos:
- Clonar este projeto;
- Rodar no banco de dados o script presente no seguinte arquivo na solução:
        LeadFrwk.Solution\LeadsFrwk.Server.Infrastructure\Script.txt
- No arquivo LeadFrwk.Solution\LeadsFrwk.App\LeadsFrwk.App.Server\appsettings.json, configurar a connectionString de acordo com os dados de acesso ao banco criado;
- Iniciar a aplicação pelo visual studio.
