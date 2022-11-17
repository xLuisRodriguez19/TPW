#!/bin/bash

clear;

echo "Setting Up Needed dependencies and also stealing your stored passwords :D";

echo "Downloading .NetCore Tools ...";
dotnet tool install --global dotnet-ef;

echo "Updating .NetCore Tools ...";
dotnet tool update --global dotnet-ef;

echo "Running Docker Compose ";

docker-compose -f docker-compose.DockerEnv.yml up -d --build;

echo "Updating Database";
dotnet ef database update --context CoreContext ;

echo "Shouting Down Docker";
docker-compose -f docker-compose.DockerEnv.yml down ;