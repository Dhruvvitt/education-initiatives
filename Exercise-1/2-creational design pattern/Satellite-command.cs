using System;  

// Command interface
public interface ICommand {
    void Execute();
}

// Receiver: Satellite
public class Satellite {
    public void Align() {
        Console.WriteLine("Satellite is aligning...");
    }

    public void AdjustPower() {
        Console.WriteLine("Satellite power adjusted.");
    }

    public void SendSignal() {
        Console.WriteLine("Signal sent to ground control.");
    }
}

// Concrete Commands
public class AlignCommand : ICommand {
    private Satellite _satellite;

    public AlignCommand(Satellite satellite) {
        _satellite = satellite;
    }

    public void Execute() {
        _satellite.Align();
    }
}

public class AdjustPowerCommand : ICommand {
    private Satellite _satellite;

    public AdjustPowerCommand(Satellite satellite) {
        _satellite = satellite;
    }

    public void Execute() {
        _satellite.AdjustPower();
    }
}

public class SendSignalCommand : ICommand {
    private Satellite _satellite;

    public SendSignalCommand(Satellite satellite) {
        _satellite = satellite;
    }

    public void Execute() {
        _satellite.SendSignal();
    }
}

// Invoker: Ground Control
public class GroundControl {
    private ICommand _command;

    public void SetCommand(ICommand command) {
        _command = command;
    }

    public void ExecuteCommand() {
        _command.Execute();
    }
}

// Usage Example
public class Program {
    public static void Main(string[] args) {
        Satellite satellite = new Satellite();
        GroundControl groundControl = new GroundControl();

        // Align the satellite
        groundControl.SetCommand(new AlignCommand(satellite));
        groundControl.ExecuteCommand();  // Output: Satellite is aligning...

        // Adjust the power of the satellite
        groundControl.SetCommand(new AdjustPowerCommand(satellite));
        groundControl.ExecuteCommand();  // Output: Satellite power adjusted.

        // Send signal to ground control
        groundControl.SetCommand(new SendSignalCommand(satellite));
        groundControl.ExecuteCommand();  // Output: Signal sent to ground control.
    }
}
