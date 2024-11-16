namespace FirstGame;

public class FuelTank
{
    public float Capacity { get; private set; }
    public float CurrentLevel { get; private set; }

    public FuelTank(float capacity)
    {
        Capacity = capacity;
        CurrentLevel = capacity;
    }

    public void UseFuel(float amount)
    {
        CurrentLevel = CurrentLevel - amount < 0f ? 0f : CurrentLevel - amount;
    }
}