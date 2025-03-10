-- CREATE DATABASE parkman;
GO
USE parkman;
GO
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

CREATE TABLE Vehicle (
    vehicle_id INT IDENTITY(1,1) PRIMARY KEY,
    license_plate VARCHAR(20) UNIQUE NOT NULL,
    owner_name VARCHAR(100) NOT NULL,
    vehicle_type VARCHAR(20) CHECK (vehicle_type IN ('Car', 'Motorcycle', 'Truck')) NOT NULL
);

INSERT INTO ParkingLot (name, location, capacity)
VALUES 
('Central Park', 'Downtown', 100),
('West Side Lot', 'West District', 150),
('East End Parking', 'East District', 75);

INSERT INTO Vehicle (license_plate, owner_name, vehicle_type)
VALUES
('ABC123', 'John Doe', 'Car'),
('XYZ456', 'Jane Doe', 'Motorcycle'),
('LMN789', 'Alice Smith', 'Truck');

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
INSERT INTO ParkingTransaction (lot_id, vehicle_id, entry_time, exit_time, fee)
VALUES
(1, 1, '2025-03-10 08:00:00', '2025-03-10 12:00:00', 80.00),
(2, 2, '2025-03-10 09:00:00', '2025-03-10 11:30:00', 60.00),
(3, 3, '2025-03-10 10:00:00', NULL, 0.00);  -- Ingen utcheckning än
