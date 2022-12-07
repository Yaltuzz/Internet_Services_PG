from node:19.2-alpine
workdir /app
copy package*.json /app
RUN npm install --quiet
RUN npm install axios
copy . .
cmd ["npm", "run", "serve"]