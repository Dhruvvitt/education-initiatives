using System;  

// Command interface
public interface ICommand {
    void Execute();
}

// Receiver: Rocket
public class Rocket {
    public void StartEngines() {
        Console.WriteLine("Engines started!");
    }

    public void Launch() {
        Console.WriteLine("Rocket launched!");
    }

    public void DetachStages() {
        Console.WriteLine("Stages detached!");
    }
}

// Concrete Commands
public class StartEnginesCommand : ICommand {
    private Rocket _rocket;

    public StartEnginesCommand(Rocket rocket) {
        _rocket = rocket;
    }

    public void Execute() {
        _rocket.StartEngines();
    }
}

public class LaunchCommand : ICommand {
    private Rocket _rocket;

    public LaunchCommand(Rocket rocket) {
        _rocket = rocket;
    }

    public void Execute() {
        _rocket.Launch();
    }
}

public class DetachStagesCommand : ICommand {
    private Rocket _rocket;

    public DetachStagesCommand(Rocket rocket) {
        _rocket = rocket;
    }

    public void Execute() {
        _rocket.DetachStages();
    }
}

// Invoker: Launch Control
public class LaunchControl {
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
        Rocket rocket = new Rocket();
        LaunchControl launchControl = new LaunchControl();

        // Start engines
        launchControl.SetCommand(new StartEnginesCommand(rocket));
        launchControl.PressButton();  // Output: Engines started!

        // Launch the rocket
        launchControl.SetCommand(new LaunchCommand(rocket));
        launchControl.PressButton();  // Output: Rocket launched!

        // Detach stages
        launchControl.SetCommand(new DetachStagesCommand(rocket));
        launchControl.PressButton();  // Output: Stages detached!
    }
}
