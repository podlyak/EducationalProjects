import cgi
import os

form = cgi.FieldStorage()
print("Content-type: text/html")

html = """
<html>
    <head>
        <link rel="stylesheet" type="text/css" href="../lab2.css">
        <meta name="Viktor Polyakov 4832" charset="utf-8">
        <title>Опрос</title>
        <style>
            h2 {
                color: #FF6A6A;
            }
            h3, h4 {
                color: #8B4500;
            }
        </style>
    </head>
    <body>
        <header>
            <h1>Опрос пользователя</h1>
        </header>
        <hr>
        <h2>Спасибо за ответы!</h2>
        <h3>Отправленные данные</h3>
        <h4>Вас зовут: %(name)s</h4>
        <h4>Пол: %(gender)s</h4>
        <h4>Возраст: %(age)s</h4>
        <h4>Род деятельности: %(kind_of_activity)s</h4>
        <h4>Любимые соцсети: %(social_media)s</h4>
        <br><br><br><br><br><br><br><br><br><br>
        <a title="Нажмите на меня!" href="../lab5.html">Вернуться</a>
        <hr>
        <footer>
            <p>© Поляков В. В., 2021</p>
        </footer>
    </body>
</html>"""

output_txt = 'data.txt'
output_file = ''
if not os.path.exists(output_txt):
    output_file = open(output_txt, 'w', encoding='utf-8')
else:
    output_file = open(output_txt, 'a', encoding='utf-8')

data = {}
for key in form.keys():
    if key != 'x' or key != 'y':
        if not isinstance(form.getvalue(key), list):
            data[key] = form.getvalue(key)
        else:
            values = form.getlist(key)
            data[key] = ', '.join(values)
print(html % data)

for key in sorted(data):
    output_file.write(data[key] + '\n')
output_file.write('\n')
output_file.close()
