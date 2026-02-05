# Sample Seed Data
```sql
-- Insert statements for WeatherHistory table (without HistoryId)
INSERT INTO [dbo].[WeatherHistory] ([CityName], [Region], [Country], [Longitude], [Latitude], [TimeZoneId], [Date], [TemperatureC])
VALUES ('London', 'City of London, Greater London', 'United Kingdom', -0.11, 51.52, 'Europe/London', '2023-05-23', 18);

INSERT INTO [dbo].[WeatherHistory] ([CityName], [Region], [Country], [Longitude], [Latitude], [TimeZoneId], [Date], [TemperatureC])
VALUES ('Paris', 'Ile-de-France', 'France', 2.33, 51.52, 'Europe/Paris', '2023-05-23', 18);

INSERT INTO [dbo].[WeatherHistory] ([CityName], [Region], [Country], [Longitude], [Latitude], [TimeZoneId], [Date], [TemperatureC])
VALUES ('Montreal', 'Quebec', 'Canada', -73.58, 45.5, 'America/Toronto', '2023-05-23', 19);
```