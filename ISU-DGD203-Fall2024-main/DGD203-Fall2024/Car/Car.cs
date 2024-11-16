namespace FirstGame;

public class Car : Vehicle
{
    private IEngine _engine;
    private FuelTank? _fuelTank;
    private Tire[] _tires;
    private Seat[] _seats;
    public int Doors { get; private set; }
    public string Comfort { get; private set; }

    public Car(float fuelAmount, IEngine engine, int doors, string tireType, string comfort, float? fuelTankCapacity)
    {
        Fuel = fuelAmount;
        _engine = engine;
        _fuelTank = fuelTankCapacity.HasValue ? new FuelTank(fuelTankCapacity.Value) : null;
        _tires = new Tire[4] { new Tire(tireType), new Tire(tireType), new Tire(tireType), new Tire(tireType) };
        _seats = new Seat[4] { new Seat(), new Seat(), new Seat(), new Seat() };
        Doors = doors;
        Comfort = comfort;
    }

    public void StartCar()
    {
        _engine.Start();
        // Diğer araba başlatma işlemleri
    }

    public new void UseFuel(float amount)
    {
        _fuelTank?.UseFuel(amount);
    }

    public Seat[] Seats => _seats;
    public Tire[] Tires => _tires;
    public string FuelTankCapacity => _fuelTank?.Capacity.ToString() ?? "NO! You didn't expect a fuel tank in an electric car, did you?";
}