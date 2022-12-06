import pika
import time
import random
import json

connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='first')
initial = random.randint(200, 1000)
for i in range(100):
    value = initial + random.randint(0, 5) * random.choice([-1, 1])
    x =  { "InstanceName":"Temperature-1", "PressureValue":value}
    channel.basic_publish(exchange='',
                      routing_key='first',
                      body=json.dumps(x))
    time.sleep(1)
connection.close()