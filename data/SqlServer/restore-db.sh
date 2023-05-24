#run the setup script to restore the DB
#do this in a loop because the timing for when the SQL instance is ready is indeterminate

for i in {1..50};
do
    /opt/mssql-tools/bin/sqlcmd -S localhost -U sa -P $MSSQL_SA_PASSWORD -Q "RESTORE DATABASE [WeatherDemo] FROM DISK=N'/usr/src/app/WeatherDemo.bak' WITH RECOVERY" 
    if [ $? -eq 0 ]
    then
        echo "DB restore completed"
        break
    else
        echo "not ready yet..."
        sleep 1
    fi
done