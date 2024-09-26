using System;  

// Command interface
public interface ICommand {
    void Execute();
}

// Rover class
public class Rover {
    public int X { get; private set; }
    public int Y { get; private set; }
    public char Direction { get; private set; }

    public Rover(int x, int y, char direction) {
        X = x;
        Y = y;
        Direction = direction;
    }

    public void MoveForward() {
        switch (Direction) {
            case 'N':
                Y += 1;
                break;
            case 'S':
                Y -= 1;
                break;
            case 'E':
                X += 1;
                break;
            case 'W':
                X -= 1;
                break;
            default:
                throw new ArgumentException("Invalid direction");
        }
        Console.WriteLine($"Rover moved to ({X}, {Y}) facing {Direction}");
    }

    public void TurnLeft() {
        Direction = Direction switch {
            'N' => 'W',
            'W' => 'S',
            'S' => 'E',
            'E' => 'N',
            _ => throw new ArgumentException("Invalid direction")
        };
        Console.WriteLine($"Rover turned left, now facing {Direction}");
    }

    public void TurnRight() {
        Direction = Direction switch {
            'N' => 'E',
            'E' => 'S',
            'S' => 'W',
            'W' => 'N',
            _ => throw new ArgumentException("Invalid direction")
        };
        Console.WriteLine($"Rover turned right, now facing {Direction}");
    }
}

// Concrete commands
public class MoveCommand : ICommand {
    private Rover _rover;

    public MoveCommand(Rover rover) {
        _rover = rover;
    }

    public void Execute() {
        _rover.MoveForward();
    }
}

public class TurnLeftCommand : ICommand {
    private Rover _rover;

    public TurnLeftCommand(Rover rover) {
        _rover = rover;
    }

    public void Execute() {
        _rover.TurnLeft();
    }
}

public class TurnRightCommand : ICommand {
    private Rover _rover;

    public TurnRightCommand(Rover rover) {
        _rover = rover;
    }

    public void Execute() {
        _rover.TurnRight();
    }
}

// Invoker class
public class RemoteControl {
    private ICommand _command;

    public void SetCommand(ICommand command) {
        _command = command;
    }

    public void PressButton() {
        _command.Execute();
    }
}

// Usage Example
public class Program {
    public static void Main(string[] args) {
        Rover rover = new Rover(0, 0, 'N');
        RemoteControl remote = new RemoteControl();

        // Move Forward
        remote.SetCommand(new MoveCommand(rover));
        remote.PressButton(); // Output: Rover moved to (0, 1) facing N

        // Turn Left
        remote.SetCommand(new TurnLeftCommand(rover));
        remote.PressButton(); // Output: Rover turned left, now facing W

        // Turn Right
        remote.SetCommand(new TurnRightCommand(rover));
        remote.PressButton(); // Output: Rover turned right, now facing N
    }
}
