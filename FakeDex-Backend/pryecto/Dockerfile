FROM maven:alpine as build
ENV HOME=/usr/app
RUN mkdir -p $HOME
WORKDIR $HOME
ADD . $HOME
RUN mvn clean install

FROM openjdk:8-jdk-alpine
#ARG JAR_FILE=./target/pryecto-0.0.1-SNAPSHOT.jar
#COPY ${JAR_FILE} app.jar
COPY --from=build /usr/app/target/pryecto-0.0.1-SNAPSHOT.jar /app/app.jar
ENTRYPOINT ["java","-jar","/app/app.jar"]
EXPOSE 5000