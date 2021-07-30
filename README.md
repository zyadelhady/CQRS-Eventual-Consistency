To run the app you must have Docker installed and run the following commands.

```
docker compose up api connect --build
```

```
docker exec -it db /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P 1Secure*Password1 -i ./Sqlscript.sql
```

Output should be:

```
  # Changed database context to 'master'.
  # Changed database context to 'CQRS'.
  # Changed database context to 'master'.
  # Changed database context to 'CQRS'.
  # Job 'cdc.CQRS_capture' started successfully.
  # Job 'cdc.CQRS_cleanup' started successfully.
  # (1 rows affected)
  # (1 rows affected)
  # (1 rows affected)
  # (1 rows affected)
  # (1 rows affected)

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

```
docker compose up read --build
```
