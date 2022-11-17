# SuperShop
Welcome to this incredible journey of setting up your dev environment.
![Image](superstore.jpg)

## Pre-requisites
1. Net 6.0 [Download Link](https://dotnet.microsoft.com/en-us/download/dotnet/6.0).
2. [Docker Desktop](https://hub.docker.com/editions/community/docker-ce-desktop-windows/) or [Docker Machine](https://docs.docker.com/machine/install-machine/)

## Setup Step by Step

1. In a terminal run the script located at the root folder  
   Run the _.sh_ file using this command in the terminal.
    ```
       sh ./setup.sh
    ```
This Bash Script will run the following instructions:

    I. Install the necesary .NetCore tools for running Entity Framework Migrations.  
    II. Run Docker Compose command for Dev Environment.  
    III. Run the latest migration of the Database. (Seeding not included).

## Run With Locally with Docker

1. To start the proyect with docker run in a terminal this command:
    ```
       docker-compose -f docker-compose.DockerEnv.yml up --build
    ```
   
2. Use Ctrl+C to ende the process when needed to stop
1. To finish the daemon run in a terminal this command:
    ```
       docker-compose -f docker-compose.DockerEnv.yml down
    ```