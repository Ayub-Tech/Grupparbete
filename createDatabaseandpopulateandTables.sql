-- CREATE DATABASE parkman;
GO
USE parkman;
GO*/
-- Skapa tabellen för parkeringsplatser
CREATE TABLE ParkingLot (
    lot_id INT IDENTITY(1,1) PRIMARY KEY,
    name VARCHAR(100) NOT NULL,
    location VARCHAR(255) NOT NULL,
    capacity INT NOT NULL
);

-- Skapa tabellen för fordon
CREATE TABLE Vehicle (
    vehicle_id INT IDENTITY(1,1) PRIMARY KEY,
    license_plate VARCHAR(20) UNIQUE NOT NULL,
    owner_name VARCHAR(100) NOT NULL,
    vehicle_type VARCHAR(20) CHECK (vehicle_type IN ('Car', 'Motorcycle', 'Truck')) NOT NULL
);

-- Skapa tabellen för parkeringshändelser
CREATE TABLE ParkingTransaction (
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    lot_id INT,
    vehicle_id INT,
    entry_time DATETIME NOT NULL DEFAULT GETDATE(),
    exit_time DATETIME NULL,
    fee DECIMAL(10,2) DEFAULT 0.00,
    FOREIGN KEY (lot_id) REFERENCES ParkingLot(lot_id) ON DELETE CASCADE,
    FOREIGN KEY (vehicle_id) REFERENCES Vehicle(vehicle_id) ON DELETE CASCADE
);

