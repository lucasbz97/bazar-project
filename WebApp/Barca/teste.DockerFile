FROM node:alpine
#só precisei do node

WORKDIR /app
#o diretorio onde os comandos vão rodar

COPY package.json /app
COPY package-lock.json /app

RUN npm install
#na realidade esse comando só precisa se executado uma vez para gerar os arquivos e poder rodar dentro do docker

COPY . /app
#copiar os arquivos gerados do diretorio fonte onde esta a app para o diretorio dentro do docker

EXPOSE 4200
#dentro do docker sera exposto na porta 4200
#mas na maquina esse dock responde em outra porta

CMD node_modules/.bin/ng serve --host 0.0.0.0 --disable-host-check

#comando terminal para gerar a imagem e rodar o docker
# docker build -t webapp_bazar -f teste.DockerFile Barca
#comando que estara criando a img docker com o nome webapp_bazar e olhando para o arquivo .dockefile no diretorio de trabalho com nome Barca

# docker run --rm -it -p 4201:4200 webapp_bazar
#estara rodando o docker respondendo na porta 4201 da maquina mas 4200 no docker