import pika
import time
import random

connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='second')
initial = 30.0
for i in range(100):
    value = initial + random.random() * random.choice([-1, 1]) * 3
    channel.basic_publish(exchange='',
                      routing_key='second',
                      body=value)
    time.sleep(13)
connection.close()