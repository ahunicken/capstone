--Create a new database named RentWeelzDB
CREATE DATABASE RentWheelzDB;
GO

--Use the RentWeelzDB database
USE RentWheelzDB;
GO

--Create a new table named Users
CREATE TABLE Users
(
	UserID INT CONSTRAINT pk_Users_UserID PRIMARY KEY IDENTITY(1,1),
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	Password NVARCHAR(50) NOT NULL,
	PhoneNumber NVARCHAR(50) NOT NULL
);
GO

--Create a new table named Vehicles
CREATE TABLE Vehicles
(
	VehicleID INT CONSTRAINT pk_Vehicles_VehicleID PRIMARY KEY IDENTITY(1,1),
	Model NVARCHAR(50) NOT NULL,
	Year INT NOT NULL,
	RegistrationNumber NVARCHAR(50) NOT NULL,
	Price DECIMAL(18,2) NOT NULL,
	Available BIT NOT NULL,
	Thumbail NVARCHAR(100) NOT NULL
);
GO

--Create a new table named Reservation
CREATE TABLE Reservations
(
	ReservationID INT CONSTRAINT pk_Reservations_ReservationID PRIMARY KEY IDENTITY(1,1),
	UserID INT NOT NULL,
	VehicleID INT NOT NULL,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	Status NVARCHAR(50) NOT NULL,
	Duration INT CONSTRAINT df_Reservations_Duration DEFAULT 1 NOT NULL,
	FOREIGN KEY (UserID) REFERENCES Users(UserID),
	FOREIGN KEY (VehicleID) REFERENCES Vehicles(VehicleID)
);
GO

--Insert 5 different records into the Users table	
INSERT INTO Users (FirstName, LastName, Email, Password, PhoneNumber)
VALUES ('John', 'Doe', 'john.doe@gmail.com', '123456', '1234567890'),
	   ('Jane', 'Doe', 'jane.doe@gmail.com', '123456', '1234567890'),
	   ('Mike', 'Smith', 'mike.smith@gmail.com'	, '123456', '1234567890'),
	   ('Sara', 'Smith', 'sara.smith@gmail.com', '123456', '1234567890'),
	   ('Tom', 'Brown', 'tom.brown@gmail.com', '123456', '1234567890');

GO

--Insert 5 different records into the Vehicles table
INSERT INTO Vehicles (Model, Year, RegistrationNumber, Price, Available, Thumbail)
VALUES ('Toyota Camry', 2019, 'ABC123', 50.05, 1, 'https://www.rentwheelz.com/images/toyota-camry.jpg'),
	   ('Honda Accord', 2018, 'DEF456', 60.15, 1, 'https://www.rentwheelz.com/images/honda-accord.jpg'),
	   ('Ford Fusion', 2017, 'GHI789', 70.45, 1, 'https://www.rentwheelz.com/images/ford-fusion.jpg'),
	   ('Chevrolet Malibu', 2016, 'JKL012', 80.25, 1, 'https://www.rentwheelz.com/images/chevrolet-malibu.jpg'),
	   ('Nissan Altima', 2015, 'MNO345', 90.35, 1, 'https://www.rentwheelz.com/images/nissan-altima.jpg');
GO


--Insert 5 different records from start date this year 2024, month april, and try to random duration from 1 to 5 into the Reservations table
INSERT INTO Reservations (UserID, VehicleID, StartDate, EndDate, Status, Duration)
VALUES (1, 1, '2024-04-01', '2024-04-02', 'Reserved', 1),
	   (2, 2, '2024-04-03', '2024-04-04', 'Reserved', 2),
	   (3, 3, '2024-04-05', '2024-04-06', 'Reserved', 3),
	   (4, 4, '2024-04-07', '2024-04-08', 'Reserved', 4),
	   (5, 5, '2024-04-09', '2024-04-10', 'Reserved', 5);
GO

--Display all records from the Users table
SELECT * FROM Users;
GO

--Display all records from the Vehicles table
SELECT * FROM Vehicles;
GO

--Display all records from the Reservations table
SELECT * FROM Reservations;
GO

--Create a new stored procedure named sp_GetAllUsers
CREATE PROCEDURE sp_GetAllUsers
AS
BEGIN
	SELECT * FROM Users;
END
GO

--Create a new stored procedure named sp_GetAllVehicles
CREATE PROCEDURE sp_GetAllVehicles
AS
BEGIN
	SELECT * FROM Vehicles;
END
GO

--Create a new stored procedure named sp_GetAllReservations
CREATE PROCEDURE sp_GetAllReservations
AS
BEGIN
	SELECT * FROM Reservations;
END
GO

--Create new store procedure named usp_AddNewReservation with 5 parameters
CREATE PROCEDURE usp_AddNewReservation
	@UserID INT,
	@VehicleID INT,
	@StartDate DATE,
	@EndDate DATE

	AS
	BEGIN
		--Check if the vehicle is available, if not return -1
		IF EXISTS (SELECT * FROM Vehicles WHERE VehicleID = @VehicleID AND Available = 0)
		BEGIN
			RETURN -1;
		END

		--Check if the vehicle is available in the given date range, if not return -2
		IF EXISTS (SELECT * FROM Reservations WHERE VehicleID = @VehicleID AND StartDate <= @EndDate AND EndDate >= @StartDate)
		BEGIN
			RETURN -2;
		END
			
		--Check if the start date is less than the end date, if not return -3
		IF @StartDate > @EndDate
		BEGIN
			RETURN -3;
		END

		--Check if a startDate is a future date, if not return -4
		IF @StartDate < GETDATE()
		BEGIN
			RETURN -4;
		END

		--Set the vehicle to unavailable
		UPDATE Vehicles SET Available = 0 WHERE VehicleID = @VehicleID;

		
		--Insert the new reservation with status Reserved
		INSERT INTO Reservations (UserID, VehicleID, StartDate, EndDate, Status)
		VALUES (@UserID, @VehicleID, @StartDate, @EndDate, 'Reserved');
	END
GO

--Create a new stored procedure named usp_CancelReservation with 1 parameter
CREATE PROCEDURE usp_CancelReservation
	@ReservationID INT
	AS
	BEGIN
		--Check if the reservation exists, if not return -1
		IF NOT EXISTS (SELECT * FROM Reservations WHERE ReservationID = @ReservationID)
		BEGIN
			RETURN -1;
		END

		--Get the vehicleID for the reservation
		DECLARE @VehicleID INT;
		SELECT @VehicleID = VehicleID FROM Reservations WHERE ReservationID = @ReservationID;

		--Set the vehicle to available
		UPDATE Vehicles SET Available = 1 WHERE VehicleID = @VehicleID;

		--Cancel the reservation with status Canceled
		UPDATE Reservations SET Status = 'Canceled' WHERE ReservationID = @ReservationID;

	END
	GO

--Create a new stored procedure named usp_CloseReservation with 1 parameter
CREATE PROCEDURE usp_CloseReservation
	@ReservationID INT
	AS
	BEGIN
		--Check if the reservation exists, if not return -1
		IF NOT EXISTS (SELECT * FROM Reservations WHERE ReservationID = @ReservationID)
		BEGIN
			RETURN -1;
		END

		--Get the vehicleID for the reservation
		DECLARE @VehicleID INT;
		SELECT @VehicleID = VehicleID FROM Reservations WHERE ReservationID = @ReservationID;

		--Set the vehicle to available
		UPDATE Vehicles SET Available = 1 WHERE VehicleID = @VehicleID;

		--Close the reservation with status Closed
		UPDATE Reservations SET Status = 'Closed' WHERE ReservationID = @ReservationID;

	END
GO

--Create a new stored procedure named usp_GetUserReservations with an userID parameter, but only that reservations that are not closed and canceled
CREATE PROCEDURE usp_GetUserReservations
	@UserID INT
	AS
	BEGIN
		SELECT * FROM Reservations WHERE UserID = @UserID AND Status != 'Closed' AND Status != 'Canceled';
	END
GO

--Create a new stored procedure named usp_GetVehicleReservations with a vehicleID parameter, but only that reservations that are not closed and canceled
CREATE PROCEDURE usp_GetVehicleReservations
	@VehicleID INT
	AS
	BEGIN
		SELECT * FROM Reservations WHERE VehicleID = @VehicleID AND Status != 'Closed' AND Status != 'Canceled';
	END
GO

--Create a new stored procedure named usp_GetAvailableVehicles
CREATE PROCEDURE usp_GetAvailableVehicles
	AS
	BEGIN
		SELECT * FROM Vehicles WHERE Available = 1;
	END
GO

