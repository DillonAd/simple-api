#!/bin/bash

docker build -t docker-demo-api .
docker run --rm -it -p 5000:5000 docker-demo-api