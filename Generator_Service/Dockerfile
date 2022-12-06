FROM python:3.9-alpine
WORKDIR /usr/src/app
RUN python -m pip install pika --upgrade
WORKDIR .
COPY . .
RUN chmod a+x run.sh
ENTRYPOINT python producer_1.py