import pika
import time
import random

connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='fourth')
initial = random.randint(10000, 30000)
for i in range(100):
    value = initial + random.randint(0, 50) * random.choice([-1, 1])
    channel.basic_publish(exchange='',
                      routing_key='fourth',
                      body=value)
    time.sleep(5)
connection.close()