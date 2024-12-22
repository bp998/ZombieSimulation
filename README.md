# Zombie Simulation

Zombie Simulation is a simple simulation program that models the spread of a zombie infection among a population of units. The simulation allows you to observe how healthy units become infected and turn into zombies, and how zombies eventually die after a certain period.

## Features

- Initialize a population of units with random positions.
- Simulate the spread of a zombie infection.
- Pause and resume the simulation.
- Save and load the state of the simulation.
- Adjust the number of units and the simulation interval.
- Cure zombies by clicking on them.

## Installation

1. Clone the repository or download the source code.
2. Open the solution in Visual Studio.
3. Build the solution to restore the necessary dependencies.

## Usage

1. Run the application from Visual Studio or by executing the compiled `.exe` file.
2. Use the provided controls to interact with the simulation:
   - **Pause/Resume**: Pause or resume the simulation.
   - **Save**: Save the current state of the simulation to a file.
   - **Load**: Load a previously saved state of the simulation.
   - **Restart**: Restart the simulation with a specified number of units.
   - **Number of units**: Set the the number of units in the game after restart.
   - **Interval**: Set the interval (in milliseconds) for the simulation updates.
   - **Time Until Zombie Death**: Set the time (in milliseconds) until a zombie dies.

## Controls

- **Mouse Click**: Cure a zombie by clicking on it.
- **Mouse Move**: Change the cursor to a hand when hovering over a zombie.

## Code Structure

- `Forms/MainForm.cs`: Contains the main form and user interface logic.
- `Models/Unit.cs`: Defines the `Unit` class and its states (Healthy, Zombie, Dead).
- `Services/GameState.cs`: Contains the logic for updating the simulation and managing the game state.

## Acknowledgements

This program was created as part of the coursework for the Design Patterns course.
