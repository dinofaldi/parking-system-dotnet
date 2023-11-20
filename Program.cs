using System;
using System.Collections.Generic;
using System.Linq;

namespace parking_system
{
    class Program
    {
        static Dictionary<int, Vehicle> parkingLot = new Dictionary<int, Vehicle>();
        static int totalLots = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("$ ");
                string input = Console.ReadLine();
                string[] command = input.Split(' ');

                switch (command[0].ToLower())
                {
                    case "create_parking_lot":
                        CreateParkingLot(command);
                        break;
                    case "park":
                        ParkVehicle(command);
                        break;
                    case "leave":
                        LeaveParkingLot(command);
                        break;
                    case "status":
                        DisplayParkingStatus();
                        break;
                    case "type_of_vehicles":
                        CountVehiclesByType(command);
                        break;
                    case "registration_numbers_for_vehicles_with_odd_plate":
                        DisplayVehiclesByOddPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_even_plate":
                        DisplayVehiclesByEvenPlate();
                        break;
                    case "registration_numbers_for_vehicles_with_colour":
                        DisplayVehiclesByColour(command);
                        break;
                    case "slot_numbers_for_vehicles_with_colour":
                        DisplaySlotsByColour(command);
                        break;
                    case "slot_number_for_registration_number":
                        DisplaySlotByRegistrationNumber(command);
                        break;
                    case "report":
                        DisplayParkingReport();
                        break;
                    case "exit":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid command");
                        break;
                }
            }
        }

        static void CreateParkingLot(string[] command)
        {
            if (int.TryParse(command[1], out totalLots))
            {
                Console.WriteLine($"Created a parking lot with {totalLots} slots");
            }
            else
            {
                Console.WriteLine("Invalid number of slots");
            }
        }

        static void ParkVehicle(string[] command)
        {
            if (totalLots == 0)
            {
                Console.WriteLine("Parking lot is not created");
                return;
            }

            if (parkingLot.Count < totalLots)
            {
                if (parkingLot.Any(v => v.Value.RegistrationNumber.Equals(command[1], StringComparison.OrdinalIgnoreCase)))
                {
                    Console.WriteLine("Vehicle is already parked");
                    return;
                }

                if (command[3] != "Mobil" && command[3] != "Motor")
                {
                    Console.WriteLine("Invalid type of vehicle");
                    return;
                }

                int slotNumber = 0;
                for (int i = 1; i <= totalLots; i++)
                {
                    if (!parkingLot.ContainsKey(i))
                    {
                        slotNumber = i;
                        break;
                    }
                }

                string registrationNumber = command[1];
                string colour = command[2];
                string type = command[3];

                parkingLot.Add(slotNumber, new Vehicle(registrationNumber, colour, type));
                Console.WriteLine($"Allocated slot number: {slotNumber}");
            }
            else
            {
                Console.WriteLine("Sorry, parking lot is full");
            }
        }

        static void LeaveParkingLot(string[] command)
        {
            int slotNumber = int.Parse(command[1]);
            if (parkingLot.ContainsKey(slotNumber))
            {
                parkingLot.Remove(slotNumber);
                Console.WriteLine($"Slot number {slotNumber} is free");
            }
            else
            {
                Console.WriteLine($"Slot number {slotNumber} not found");
            }
        }

        static void DisplayParkingStatus()
        {
            Console.WriteLine("Slot No.  Type    Registration No  Colour");
            foreach (var kvp in parkingLot)
            {
                Console.WriteLine($"{kvp.Key,-8} {kvp.Value.Type,-7} {kvp.Value.RegistrationNumber,-15} {kvp.Value.Colour}");
            }
        }

        static void CountVehiclesByType(string[] command)
        {
            string type = command[1];
            int count = parkingLot.Count(v => v.Value.Type.Equals(type, StringComparison.OrdinalIgnoreCase));
            Console.WriteLine(count);
        }

        static void DisplayVehiclesByOddPlate()
        {
            var oddPlates = parkingLot.Where(v => v.Value.RegistrationNumber.Split('-')[1].Last() % 2 != 0)
                .Select(v => v.Value.RegistrationNumber);
            Console.WriteLine(string.Join(", ", oddPlates));
        }

        static void DisplayVehiclesByEvenPlate()
        {
            var evenPlates = parkingLot.Where(v => v.Value.RegistrationNumber.Split('-')[1].Last() % 2 == 0)
                .Select(v => v.Value.RegistrationNumber);
            Console.WriteLine(string.Join(", ", evenPlates));
        }

        static void DisplayVehiclesByColour(string[] command)
        {
            string colour = command[1];
            var vehicles = parkingLot.Where(v => v.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
                .Select(v => v.Value.RegistrationNumber);
            if (vehicles.Count() == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(string.Join(", ", vehicles));
        }

        static void DisplaySlotsByColour(string[] command)
        {
            string colour = command[1];
            var slots = parkingLot.Where(v => v.Value.Colour.Equals(colour, StringComparison.OrdinalIgnoreCase))
                .Select(v => v.Key.ToString());
            if (slots.Count() == 0)
            {
                Console.WriteLine("Not found");
                return;
            }

            Console.WriteLine(string.Join(", ", slots));
        }

        static void DisplaySlotByRegistrationNumber(string[] command)
        {
            string registrationNumber = command[1];
            var slot = parkingLot.FirstOrDefault(v => v.Value.RegistrationNumber.Equals(registrationNumber, StringComparison.OrdinalIgnoreCase));
            if (slot.Key != 0)
            {
                Console.WriteLine(slot.Key);
            }
            else
            {
                Console.WriteLine("Not found");
            }
        }

        static void DisplayParkingReport()
        {
            int occupiedSlots = parkingLot.Count;
            Console.WriteLine($"Number of occupied slots: {occupiedSlots}");

            int availableSlots = totalLots - occupiedSlots;
            Console.WriteLine($"Number of available slots: {availableSlots}");

            int oddPlates = parkingLot.Count(v => v.Value.RegistrationNumber.Split('-')[1].Last() % 2 != 0);
            Console.WriteLine($"Number of vehicles with odd registration number: {oddPlates}");

            int evenPlates = parkingLot.Count(v => v.Value.RegistrationNumber.Split('-')[1].Last() % 2 == 0);
            Console.WriteLine($"Number of vehicles with even registration number: {evenPlates}");

            int motor = parkingLot.Count(v => v.Value.Type.Equals("Motor", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Number of Motor vehicles: {motor}");
            int mobil = parkingLot.Count(v => v.Value.Type.Equals("Mobil", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine($"Number of Mobil vehicles: {mobil}");

            var colours = parkingLot.GroupBy(v => v.Value.Colour)
                .Select(v => new { Colour = v.Key, Count = v.Count() });
            foreach (var colour in colours)
            {
                Console.WriteLine($"Number of {colour.Colour} vehicles: {colour.Count}");
            }
        }
    }

    class Vehicle
    {
        public string RegistrationNumber { get; }
        public string Colour { get; }
        public string Type { get; }

        public Vehicle(string registrationNumber, string colour, string type)
        {
            RegistrationNumber = registrationNumber;
            Colour = colour;
            Type = type;
        }
    }

}
