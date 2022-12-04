import pika
import time
import random

connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='third')
initial = 50.0
for i in range(100):
    value = initial + random.random() * random.choice([-1, 1]) * 2
    if value > 100:
        value = 200
    channel.basic_publish(exchange='',
                      routing_key='third',
                      body=value)
    time.sleep(6)
connection.close()