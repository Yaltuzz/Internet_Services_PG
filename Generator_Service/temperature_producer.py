import pika
import time
import random
import json
import sys
from datetime import datetime


idOfInstance = sys.argv[1]
InstanceName = "T" + idOfInstance
SensorType = "Temperature"
connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='temperature')
initial = random.randint(20, 100)
for i in range(100):
    sleepTime = random.randint(2,15)
    time.sleep(sleepTime)
    value = initial + random.randint(0, 5) * random.choice([-1, 1])
    dt_string = datetime.now().strftime("%d/%m/%Y %H:%M:%S")
    x =  { "InstanceName":InstanceName, "TemperatureValue":value, "Date":dt_string,"SensorType":SensorType}
    channel.basic_publish(exchange='',
                      routing_key='temperature',
                      body=json.dumps(x))
connection.close()