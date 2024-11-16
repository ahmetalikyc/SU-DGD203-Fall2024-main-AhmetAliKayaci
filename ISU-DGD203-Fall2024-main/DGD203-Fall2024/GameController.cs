using FirstGame.Engines;

namespace FirstGame;

public class GameController
{
    private Player _player;
    private Car _car;
    private IEngine _engine;
    
    public GameController()
    {
        _player = new Player();
        _engine = null!;
        _car = null!;
    }

    public void StartGame()

    {
        Console.WriteLine("Welcome to piston cup race!");
        Console.Write("Please enter your name: ");
        string playerName = Console.ReadLine() ?? "Player";
        _player.Initialize(playerName, 20);

        Console.WriteLine("Choose your car's engine type:");
        Console.WriteLine("1. Petrol Engine");
        Console.WriteLine("2. Electric Engine");
        Console.WriteLine("3. Diesel Engine");
        string engineChoice = Console.ReadLine() ?? "1";

        var carDetails = GetCarDetails(engineChoice);
        _engine = carDetails.Engine;
        _car = new Car(100f, _engine, carDetails.Doors, carDetails.TireType, carDetails.Comfort, carDetails.FuelTankCapacity);
        _car.StartCar();

        Console.WriteLine("\nYour car is ready for the race!");
        Console.WriteLine($"- Engine: {_engine.GetType().Name}");
        Console.WriteLine($"- Car: {carDetails.Brand}");
        Console.WriteLine("- Fuel: 100%");
        Console.WriteLine($"- Tires: {_car.Tires[0].Type}");
        Console.WriteLine($"- Seats: {_car.Seats.Length} seats");
        Console.WriteLine($"- Doors: {_car.Doors} doors");
        Console.WriteLine($"- Comfort: {_car.Comfort}");
        Console.WriteLine($"- Fuel Tank Capacity: {_car.FuelTankCapacity}");

        Console.WriteLine("\nPress any key to start the race...");
        Console.ReadKey();

        Console.WriteLine("\nStarting the race on Asphalt track...");
        Console.WriteLine("3... 2... 1... GO!");

        SimulateRace(carDetails.FuelCost);
    }

    private (IEngine Engine, string Brand, float FuelCost, int Doors, string TireType, string Comfort, float? FuelTankCapacity) GetCarDetails(string engineChoice)
    {
        return engineChoice switch
        {
            "1" => (new PetrolEngine(), "Mercedes", 25, 2, "Racing", "Low", 60f),
            "2" => (new ElectricEngine(), "Tesla", 2, 4, "Summer", "High", null),
            "3" => (new DieselEngine(), "Renault", 20, 4, "Snow", "Mid", 70f),
            _ => (new PetrolEngine(), "Mercedes", 25, 2, "Racing", "Low", 60f)
        };
    }

    private void SimulateRace(float fuelCost)
    {
        var raceDetails = GetRaceDetails(_engine);

        Console.WriteLine("\nLap 1:");
        Console.WriteLine("Press any key to start Lap 1...");
        Console.ReadKey();
        Console.WriteLine($"- Speed: {raceDetails.MaxSpeedLap1} km/h");
        Console.WriteLine($"- Remaining Fuel: {raceDetails.RemainingFuelLap1}%");
        Console.WriteLine("- Status: In Race");

        Console.WriteLine("\nLap 2:");
        Console.WriteLine("Press any key to start Lap 2...");
        Console.ReadKey();
        Console.WriteLine($"- Speed: {raceDetails.MaxSpeedLap2} km/h");
        Console.WriteLine($"- Remaining Fuel: {raceDetails.RemainingFuelLap2}%");
        Console.WriteLine("- Status: In Race");
        Console.WriteLine("You are leading the race!");

        Console.WriteLine("\nLap 3:");
        Console.WriteLine("Press any key to start Lap 3...");
        Console.ReadKey();
        Console.WriteLine($"- Speed: {raceDetails.MaxSpeedLap3} km/h");
        Console.WriteLine($"- Remaining Fuel: {raceDetails.RemainingFuelLap3}%");
        Console.WriteLine("- Status: In Race");

        Console.WriteLine("\nFinal Stretch:");
        Console.WriteLine("Press any key to start the Final Stretch...");
        Console.ReadKey();
        Console.WriteLine($"- Speed: {raceDetails.FinalStretchSpeed} km/h");
        Console.WriteLine($"- Remaining Fuel: {raceDetails.RemainingFuelFinal}%");
        Console.WriteLine("- Status: In Race");
        Console.WriteLine("You crossed the finish line!");
        Console.ReadKey();
        Console.WriteLine("\nRace Results:");
        Console.WriteLine($"- Position: {raceDetails.FinalPosition}");
        Console.WriteLine($"- Time: {raceDetails.RaceTime}");
        Console.WriteLine($"- Remaining Fuel: {raceDetails.RemainingFuelFinal}%");
        Console.WriteLine($"- Fuel Cost: ${fuelCost}");
        Console.WriteLine($"Congratulations, {_player.Name}! You are the champion of Piston Cup!");
        Console.ReadKey();
    }

    private (int MaxSpeedLap1, int MaxSpeedLap2, int MaxSpeedLap3, int FinalStretchSpeed, string FinalPosition, string RaceTime, float RemainingFuelLap1, float RemainingFuelLap2, float RemainingFuelLap3, float RemainingFuelFinal) GetRaceDetails(IEngine engine)
    {
        return engine switch
        {
            ElectricEngine => (200, 210, 210, 210, "3rd Place", "3:15", 79, 64, 49, 39),
            PetrolEngine => (120, 220, 280, 300, "1st Place", "2:05", 85, 70, 55, 45),
            DieselEngine => (160, 225, 250, 265, "2nd Place", "2:40", 95, 80, 65, 55),
            _ => (150, 150, 150, 150, "Unknown Position", "Unknown Time", 85, 70, 55, 45)
        };
    }
}
