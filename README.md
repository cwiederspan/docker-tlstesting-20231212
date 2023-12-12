# TLS Testing

A quick repo test to see if a Docker container using .NET can access SQL Server

## Setting the DB Connection String

```bash

export DB_CONN_STR="YOUR_CONN_STR"

```

## Running a Query from Docker Container

```bash

cd MyConsole

docker build -t cdwmsft.azurecr.io/tlstesting:5.0 .

docker push cdwmsft.azurecr.io/tlstesting:5.0

docker run --rm -e DB_CONN_STR="$DB_CONN_STR" cdwmsft.azurecr.io/tlstesting:5.0

```