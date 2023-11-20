# .NET 5 Parking System Console App

## Author

Name: Achmad Dinofaldi Firmansyah

## Description

This is a console application that simulates a parking system. It is written in C# and .NET 5.0. It is a simple application that allows the user to add a vehicle to the parking lot, remove a vehicle from the parking lot, and view the current status of the parking lot. The user can add a Mobil and Motor to the parking lot.

## Requirements

- .NET 5.0 SDK
- Visual Studio 2019

## How to run

1. Clone this repository
2. Open the solution file in Visual Studio 2019
3. Run the application

## How to use

1. Run the application
2. Select the menu option
3. Follow the instructions

## Commands Input Format and Example

### Creates a parking lot with 6 slots
  
  - Command
    ```bash
    create_parking_lot 6
    ```
  - Output
    ```bash
    Created a parking lot with 6 slots
    ```

### Parks a vehicle with the given registration number and color

  - Command
    ```bash
    park B-1234-XYZ Putih Mobil
    ```
  - Output
    ```bash
    Allocated slot number: 1
    ```

### Removes vehicle from slot number 4

  - Command
    ```bash
    leave 4
    ```
  - Output
    ```bash
    Slot number 4 is free
    ```

### Prints the parking lot status

  - Command
    ```bash
    status
    ```
  - Output
    ```bash
    Slot No.    Registration No    Colour    Type
    1           B-1234-XYZ         Putih     Mobil
    2           B-1235-XYZ         Putih     Motor
    3           B-1236-XYZ         Putih     Mobil
    4           B-1237-XYZ         Putih     Motor
    5           B-1238-XYZ         Putih     Mobil
    6           B-1239-XYZ         Putih     Motor
    ```

### Prints Number Vehicles By Type

  - Command
    ```bash
    type_of_vehicles Motor
    ```
  - Output
    ```bash
    2
    ```

### Prints Vehicles By Odd Plate

  - Command
    ```bash
    registration_numbers_for_vehicles_with_odd_plate
    ```
  - Output
    ```bash
    B-9999-XYZ, D-0001-HIJ, B-2701-XXX
    ```

### Prints Vehicles By Even Plate

  - Command
    ```bash
    registration_numbers_for_vehicles_with_even_plate
    ```
  - Output
    ```bash
    B-1234-XYZ, B-1236-XYZ,B-1238-XYZ
    ```

### Prints Vehicles By Colour

  - Command
    ```bash
    registration_numbers_for_vehicles_with_colour Putih
    ```
  - Output
    ```bash
    B-1234-XYZ, B-9999-XYZ, B-333-SSS
    ```

### Prints Slots By Colour

  - Command
    ```bash
    slot_numbers_for_vehicles_with_colour Putih
    ```
  - Output
    ```bash
    1, 2, 3
    ```

### Prints Slot By Registration Number

  - Command
    ```bash
    slot_number_for_registration_number B-1234-XYZ
    ```
  - Output
    ```bash
    1
    ```

### Prints Parking Report

  - Command
    ```bash
    report
    ```
  - Output
    ```bash
    Number of occupied slots: 6
    Number of available slots: 0
    Number of vehicles with odd registration number: 5
    Number of vehicles with even registration number: 1
    Number of motor vehicles: 2
    Number of mobil vehicles: 4
    Number of Putih vehicles: 2
    Number of Hitam vehicles: 2
    Number of Red vehicles: 1
    Number of Biru vehicles: 1
    ```

### Exit Command
  
  - Command
    ```bash
    exit
    ```
