namespace FirstGame
{
    public class Player
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        
        public Player(string name = "John Doe", int age = 20)
        {
            Name = name;
            Age = age;
        }

        public void Initialize(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}