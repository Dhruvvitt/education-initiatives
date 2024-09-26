using System;  // Add this line to ensure the Console class is recognized

// Command Interface
public interface ICommand {
    void Execute();
    void Undo();
}

// Concrete Command: Light
public class LightOnCommand : ICommand {
    private Light _light;

    public LightOnCommand(Light light) {
        _light = light;
    }

    public void Execute() {
        _light.TurnOn();
    }

    public void Undo() {
        _light.TurnOff();
    }
}

public class LightOffCommand : ICommand {
    private Light _light;

    public LightOffCommand(Light light) {
        _light = light;
    }

    public void Execute() {
        _light.TurnOff();
    }

    public void Undo() {
        _light.TurnOn();
    }
}

// Receiver: Light
public class Light {
    public void TurnOn() {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff() {
        Console.WriteLine("Light is OFF");
    }
}

// Invoker: Remote Control
public class RemoteControl {
    private ICommand _command;

    public void SetCommand(ICommand command) {
        _command = command;
    }

    public void PressButton() {
        _command.Execute();
    }

    public void PressUndo() {
        _command.Undo();
    }
}

// Usage Example
class Program {
    static void Main() {
        var light = new Light();
        var lightOn = new LightOnCommand(light);
        var lightOff = new LightOffCommand(light);

        var remote = new RemoteControl();

        remote.SetCommand(lightOn);
        remote.PressButton(); // Output: Light is ON

        remote.SetCommand(lightOff);
        remote.PressButton(); // Output: Light is OFF
        remote.PressUndo();   // Output: Light is ON
    }
}
