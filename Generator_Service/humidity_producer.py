import pika
import time
import random
import json
import sys
from datetime import datetime


idOfInstance = sys.argv[1]
InstanceName = "H" + idOfInstance
SensorType = "Humidity"
connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
channel = connection.channel()
channel.queue_declare(queue='humidity')
initial = random.randint(1, 100)/100
for i in range(100):
    sleepTime = random.randint(2,15)
    time.sleep(sleepTime)
    value = initial + random.randint(0, 5)/100 * random.choice([-1, 1])
    if value<0:
        value=value*-1
    dt_string = datetime.now().strftime("%d/%m/%Y %H:%M:%S")
    x =  { "InstanceName":InstanceName, "HumidityValue":value, "Date":dt_string,"SensorType":SensorType}
    channel.basic_publish(exchange='',
                      routing_key='humidity',
                      body=json.dumps(x))
connection.close()