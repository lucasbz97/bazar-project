# Barca.Web

img do docker utilizada
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=_P9w8-VzXv" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2019-CU14-ubuntu-20.04

comando para mapear as tabelas e colunas que seram criadas com base na classe "Initial" é somente o nome do mapeamento mas o padrao é começar "Initial" depois seguimos com "mgtN" sendo N o ultimo +1  
Add-Migration  Initial

comando para efetivamente executar tudo que foi mapeado anteriormente
update-database -verbose

Classe Statup não existe no dotnet 6, mas não é como se não pudesse ser recriada mas em roma aja como os romanos então não criei

-----18/02
executa esse comando no banco "delete from __EFMigrationsHistory;"
apaga tudo da pasta Migrations

e roda o update
update-database -verbose

no começo foi apenas um teste... caso tenha feito a parte de cima
----19/02
estabelecer modelo de comunicação entre controller e repositorio tendo como base o produto
----21/02
adicionando outro db context para o Identity

    Add-Migration identity -context ApplicationDbContext
    update-database -verbose -context ApplicationDbContext

usar o identity para criar o login de usuarios
----23/03
Levantando as necessidades do pagamento via cartão de credito
criar codigo de exemplo com uma implementação realmente muito simples na "api/order/paymentWish"

o serviço da strippe, bem facil de implementar mas um pouco caro e tem suas observações para funcionamento no brasil

3,99% + R$ 0,39 por cobrança bem-sucedida realizada em cartão esse no plano padrão 

eu conheci algumas outros alternativas como a paypal, mas é horrivel, talvez um mercado pago pode ser bom?

em fim se quiser testar tbm pode ir na https://dashboard.stripe.com/ 
criar a conta e testar, para desenvolvimento é de graça, obviamente não cobra nem deposita nada mas vc conhece a plataforma e os meios


----24/03 Sobre importação da autenticação utilizando Google: 
instalar o pacote do google - package manager: 
NuGet\Install-Package Microsoft.AspNetCore.Authentication.Google -Version 6.0.6

path: 'C:\projects\Project Git\bazar-project\BarcaWeb\src\Barca'
rodar o comando dotnet user-secrets init --project <path>
rodar o comando dotnet user-secrets set "Authentication:Google:ClientId" "33569505883-u4fss4d7mr7oqb3tkh10sjtgjicf6nqq.apps.googleusercontent.com" --project <path>
dotnet user-secrets set "Authentication:Google:ClientSecret" "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" --project <path>

AddGoogle(googleOptions =>
{
    googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
    googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
})
----25/02

boa opção para fazer a carga fria ou cargas frias utilizando migration, ele simplesmente pega um arquivo sql e executa sozinho 