namespace ZombieSimulation.Models
{
    public class Unit
    {
        public Point Position { get; set; }
        public UnitState State { get; set; }
        public int InfectionCounter { get; set; }

        public Unit(Point position, UnitState state)
        {
            Position = position;
            State = state;
            InfectionCounter = 0;
        }
    }
}
