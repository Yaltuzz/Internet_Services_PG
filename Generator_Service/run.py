import os
import pika
import time
import subprocess

while True:
    try:
        connection = pika.BlockingConnection(pika.ConnectionParameters('si_176446_rabbit'))
        channel = connection.channel()
        break
    except:
        print("Rabbit is not active yet")
        time.sleep(5)
for x in range(8):
    command = 'python temperature_producer.py '+str(x)
    subprocess.Popen(command, shell=True)
    command = 'python humidity_producer.py '+str(x)
    subprocess.Popen(command, shell=True)
    command = 'python pressure_producer.py '+str(x)
    subprocess.Popen(command, shell=True)
    command = 'python radiation_producer.py '+str(x)
    subprocess.Popen(command, shell=True)

time.sleep(100000)