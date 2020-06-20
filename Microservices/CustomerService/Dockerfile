FROM diamol/maven AS build
WORKDIR /app
COPY src ./src
COPY pom.xml .
RUN mvn clean install

FROM openjdk:8-jdk AS runtime
WORKDIR /app
COPY --from=build /app/target/ ./
ENTRYPOINT ["java","-jar","customerservice.jar"]