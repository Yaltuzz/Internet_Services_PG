FROM python:3.9-alpine
WORKDIR /usr/src/app
RUN python -m pip install pika --upgrade
WORKDIR .
COPY . .
RUN chmod a+x run.py
ENTRYPOINT python run.py