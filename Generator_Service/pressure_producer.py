import pika
import time
import random
import json
import sys
from datetime import datetime


idOfInstance = sys.argv[1]
InstanceName = "P" + idOfInstance
SensorType = "Pressure"
connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='pressure')
initial = random.randint(1000, 5000)
for i in range(100):
    sleepTime = random.randint(2,15)
    time.sleep(sleepTime)
    value = initial + random.randint(0, 60) * random.choice([-1, 1])
    dt_string = datetime.now().strftime("%d/%m/%Y %H:%M:%S")
    x =  { "InstanceName":InstanceName, "Value":value, "Date":dt_string,"SensorType":SensorType}
    channel.basic_publish(exchange='',
                      routing_key='pressure',
                      body=json.dumps(x))
connection.close()