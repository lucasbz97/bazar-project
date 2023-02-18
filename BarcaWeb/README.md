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