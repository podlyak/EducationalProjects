import smtplib
from email.mime.text import MIMEText
from email.header import Header
from email.mime.multipart import MIMEMultipart

HOST = "smtp.mail.ru"
SUBJECT = Header('Занятие по Web-технологиям 26.10', 'utf-8')
FROM = "viktorpolyakov1999@mail.ru"
text1 = "Здравствуйте, "
text2 = "!\n\nЗавтра 26.10 лабораторные работы по Web-технологиям будут проходить очно по расписанию.\n\nС уважением," \
        "\nВиктор Поляков "
with open('password.txt', 'r', encoding='utf-8') as file:
    password = file.readline()

server = smtplib.SMTP(HOST)
server.starttls()
server.login(FROM, password)

file_address = open('address.txt', 'r', encoding='utf-8')
for line in file_address:
    line = line.strip()
    parts = line.split(' ')
    msg = MIMEMultipart()
    msg["From"] = FROM
    msg["Subject"] = SUBJECT
    msg["To"] = parts[0]
    msg.attach(MIMEText(text1 + parts[1] + ' ' + parts[2] + text2, 'plain', 'utf-8'))
    server.sendmail(FROM, parts[0], msg.as_string())
file_address.close()
server.quit()
