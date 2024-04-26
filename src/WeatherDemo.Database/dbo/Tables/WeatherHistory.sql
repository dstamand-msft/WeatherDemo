CREATE TABLE [dbo].[WeatherHistory] (
    [HistoryId]    BIGINT        IDENTITY (1, 1) NOT NULL,
    [CityName]     VARCHAR (100) NOT NULL,
    [Region]       VARCHAR (100) NOT NULL,
    [Country]      VARCHAR (100) NOT NULL,
    [Longitude]    FLOAT (53)    NOT NULL,
    [Latitude]     FLOAT (53)    NOT NULL,
    [TimeZoneId]   VARCHAR (50)  NOT NULL,
    [Date]         DATE          NOT NULL,
    [TemperatureC] FLOAT (53)    NOT NULL,
    [ModifiedDateUTC] DATETIME NOT NULL DEFAULT getutcdate(), 
    CONSTRAINT [PK_WeatherHistory] PRIMARY KEY CLUSTERED ([HistoryId] ASC)
);

