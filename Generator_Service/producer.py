import pika
import time

connection = pika.BlockingConnection(pika.ConnectionParameters('rabbit'))
channel = connection.channel()
channel.queue_declare(queue='hello')
for i in range(100):

    channel.basic_publish(exchange='',
                      routing_key='hello',
                      body='Hello, test message!')
    time.sleep(2.5)
connection.close()