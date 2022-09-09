import os
import sys
from http.server import HTTPServer, CGIHTTPRequestHandler
# каталог с файлами HTML и подкаталогом cgi-bin для сценариев
directory = '.'
port = 80
if len(sys.argv) > 1:
    directory = sys.argv[1]
if len(sys.argv) > 2:
    port = int(sys.argv[2])
print('directory "%s", port %s' % (directory, port))
# перейти в корневой веб-каталог
os.chdir(directory)
server_address = ('', port)
server_object = HTTPServer(server_address, CGIHTTPRequestHandler)
# обслуживать клиентов до завершения
server_object.serve_forever()
