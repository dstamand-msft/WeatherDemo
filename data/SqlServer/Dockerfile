FROM mcr.microsoft.com/mssql/server:2022-latest

# Switch to root user for access to apt-get install
USER root

# Install dos2unix
RUN apt-get -y update && \
        apt-get install -y dos2unix

# Create app directory
RUN mkdir -p /usr/src/app
WORKDIR /usr/src/app

# Bundle artifacts
COPY restore-db.sh entrypoint.sh WeatherDemo.bak /usr/src/app

RUN dos2unix *.sh

# Grant permissions for the import-data script to be executable
RUN chmod +x /usr/src/app/restore-db.sh

EXPOSE 1433

# Switch back to mssql user and run the entrypoint script
USER mssql
ENTRYPOINT /bin/bash ./entrypoint.sh