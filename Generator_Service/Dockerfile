FROM python:3.9-alpine
WORKDIR /usr/src/app
RUN python -m pip install pika --upgrade
WORKDIR .
COPY . .
ENTRYPOINT python producer_1.py