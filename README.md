Table of contents
=================

<!--ts-->
   * [Installation](#installation)
   * [REST-API](#end points)
   
<!--te-->

# Installation

To run the app you must have Docker installed and running and run the following commands.

in the project directory : 
```
docker compose up api connect --build
```

open another terminal tab :
```
docker exec -it db /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -i ./Sqlscript.sql
```

```
docker exec -it deb_connect bash
```

```
curl -i -X POST -H "Accept:application/json" -H "Content-Type:application/json" connect:8083/connectors/ -d '{ "name": "cqrs-connector","config": {"connector.class": "io.debezium.connector.sqlserver.SqlServerConnector","database.hostname": "db","database.port": "1433","database.user": "sa","database.password": "1Secure*Password1","database.dbname": "CQRS","database.server.name": "CQRS","database.history.kafka.bootstrap.servers": "kafka:9092","database.history.kafka.topic": "dbhistory.CQRSwithCDC_Write" } }'
```

```
curl -H "Accept:application/json" connect:8083/connectors/
```

Output should be:

```
["cqrs-connector"]
```
in the project directory : 
```
docker compose up read --build
```


# REST-API

The REST API to the CQRS app is described below.

## Get list of Students

### Request

`GET /api/Students/`

## Get Student

### Request

`GET /api/Students/{StudentId}`

## Register new Student

### Request

`POST /api/Students/`

### Body Example

`{
    "Name" :"test",
    "Email" : "test@gmail.com",
    "Courses" : [{
        "CourseId" : 2,
        "Grade" : 1
    }]
}`

## Enroll existed Student to existed course

### Request

`POST /api/students/{StudentId}/enrollments`

### Body Example
`{
    "CourseId" : 4,
    "Grade" : 3
}`

## Disenroll existed Student from course

### Request

`DELETE /api/students/{StudentId}/enrollments`

### Body Example

`{
    "EnrollmentNumber" : 0,
    "Comment" : "i don't need it anymore"
}`





    


