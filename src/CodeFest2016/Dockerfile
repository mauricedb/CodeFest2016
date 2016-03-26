FROM microsoft/aspnet:1.0.0-rc1-update1-coreclr

# Usage:
#	docker build -t codefest .
#	docker run -p 5000:5000 -d codefest

MAINTAINER Maurice de Beijer <maurice.de.beijer@gmail.com>

COPY ./project.json ./app/
 
WORKDIR ./app
RUN dnu restore

COPY . .

EXPOSE 5000

CMD ["dnx", "web", "--server.urls", "http://*:5000"]
