import pika
import time
import random
import json
import sys
from datetime import datetime


idOfInstance = sys.argv[1]
InstanceName = "R" + idOfInstance
connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='radiation')
initial = random.randint(1, 5000)/1000
for i in range(100):
    sleepTime = random.randint(2,15)
    time.sleep(sleepTime)
    value = initial + random.randint(0, 5)/1000 * random.choice([-1, 1])
    if value<0
        value=value*-1
    dt_string = datetime.now().strftime("%d/%m/%Y %H:%M:%S")
    x =  { "InstanceName":InstanceName, "RadiationValue":value, "Date":dt_string}
    channel.basic_publish(exchange='',
                      routing_key='radiation',
                      body=json.dumps(x))
connection.close()