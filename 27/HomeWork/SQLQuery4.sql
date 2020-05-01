ÑREATE DATABASE AirportInfo

USE AirportInfo

/*CREATE TABLE [dbo].[DepartureBoard](
	[Flight number] [char](10) NOT NULL,
	[Departure] [varchar](50) NOT NULL,
	[Arrival] [varchar](50) NOT NULL,
	[Date departure] [datetimeoffset](7) NULL,
	[Date arrival] [datetimeoffset](7) NULL,
	[Time of flight] [time](7) NOT NULL,
	[Airline] [varchar](50) NOT NULL,
	[Model of plane] [char](20) NOT NULL
) ON [PRIMARY]
GO

SELECT * FROM dbo.DepartureBoard
*/
/*INSERT INTO [dbo].DepartureBoard (
[Flight number],
[Departure],
[Arrival],
[Date departure],
[Date arrival],
[Time of flight],
[Airline],
[Model of plane])
VALUES ('SU2517', 'Russia, Moscow',	'Russia, Barnaul', '2020-04-09 17:25:00.0000000 +03:00', '2020-04-09 20:25:00.0000000 +03:00', '03:00:00', 'Aeroflot', 'Airbus A320')*/
/*
INSERT INTO [dbo].DepartureBoard VALUES ('SU2517', 'Russia, Moscow', 'Russia, Barnaul', '2020-04-09 17:25:00.0000000 +03:00', '2020-04-09 20:25:00.0000000 +03:00', '03:00:00', 'Aeroflot', 'Airbus A320')

INSERT INTO [dbo].DepartureBoard VALUES('S71176', 'Russia, Moscow',	'Spain, Barcelona',	'2020-04-11 00:30:00.0000000 +03:00', '2020-04-11 04:50:00.0000000 +03:00',	'04:20:00',	'S7', 'Boeing 737')

INSERT INTO [dbo].DepartureBoard VALUES ('UT571', 'Russia, Moscow', 'Russia, Sochi', '2020-04-12 12:00:00.0000000 +03:00',	'2020-04-12 14:30:00.0000000 +03:00', '02:30:00', 'Utair', 'Sukhoi Superjet 100') 


SELECT * FROM dbo.DepartureBoard

DROP TABLE  [dbo].DepartureBoard
*/
DROP DATABASE AirportInfo