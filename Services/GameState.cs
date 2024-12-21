using System.Text.Json;
using ZombieSimulation.Models;

namespace ZombieSimulation.Services
{
    public class GameState
    {
        private static GameState? instance;
        public List<Unit> Units { get; private set; }
        public bool IsPaused { get; set; }

        private GameState()
        {
            Units = new List<Unit>();
            IsPaused = false;
        }

        public static GameState Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameState();
                }
                return instance;
            }
        }

        public void InitializeUnits(int count)
        {
            Random random = new Random();
            Units.Clear();
            for (int i = 0; i < count; i++)
            {
                UnitState state = i < count / 10 ? UnitState.Zombie : UnitState.Healthy; // 10% jednostek to zombie
                Units.Add(new Unit(
                    new System.Drawing.Point(random.Next(5, 80), random.Next(5, 60)),
                    state
                ));
            }
        }

        public void SaveState(string filePath)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(Units, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void LoadState(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            Units = JsonSerializer.Deserialize<List<Unit>>(jsonString) ?? new List<Unit>();
        }
        public void UpdateSimulation(int timeUntilZombieDeath)
        {
            Random random = new Random();
            var unitsToRemove = new List<Unit>();

            foreach (var unit in Units)
            {
                unit.Position = new Point(
                    Math.Max(0, Math.Min(79, unit.Position.X + random.Next(-1, 2))),
                    Math.Max(0, Math.Min(59, unit.Position.Y + random.Next(-1, 2)))
                );

                if (unit.State == UnitState.Healthy)
                {
                    foreach (var other in Units)
                    {
                        if (other.State == UnitState.Zombie && IsNearby(unit, other))
                        {
                            unit.State = UnitState.Zombie;
                            break;
                        }
                    }
                }
                else if (unit.State == UnitState.Zombie)
                {
                    unit.InfectionCounter++;
                    if (unit.InfectionCounter >= timeUntilZombieDeath)
                    {
                        unit.State = UnitState.Dead;
                        unitsToRemove.Add(unit);
                    }
                }
            }

            foreach (var unit in unitsToRemove)
            {
                Units.Remove(unit);
            }
        }

        private bool IsNearby(Unit a, Unit b)
        {
            return Math.Abs(a.Position.X - b.Position.X) <= 1 && Math.Abs(a.Position.Y - b.Position.Y) <= 1;
        }
    }
}

