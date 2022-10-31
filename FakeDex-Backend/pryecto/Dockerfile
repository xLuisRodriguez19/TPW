FROM maven:3.8.2-jdk-8
WORKDIR /pryecto
COPY . .
RUN mvn clean install


FROM openjdk:8-jdk-alpine
ARG JAR_FILE=./target/pryecto-0.0.1-SNAPSHOT.jar
COPY ${JAR_FILE} app.jar
ENTRYPOINT ["java","-jar","/app.jar"]
EXPOSE 5000