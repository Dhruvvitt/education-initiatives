#Problem Statement: Design a console-based application to manage a smart office facility that handles conference 
                 #  room bookings, occupancy detection, and automated control of air conditioning and lighting. 


using System;
using System.Collections.Generic;

// Observer Pattern: Define Observer interface for sensors
public interface IObserver {
    void Update(bool occupied);
}

// Room class (Subject)
public class Room {
    private List<IObserver> _observers = new List<IObserver>();
    public bool IsOccupied { get; private set; }

    public void AddObserver(IObserver observer) {
        _observers.Add(observer);
    }

    public void SetOccupied(bool occupied) {
        IsOccupied = occupied;
        NotifyObservers();
    }

    private void NotifyObservers() {
        foreach (var observer in _observers) {
            observer.Update(IsOccupied);
        }
    }
}

// Concrete Observers: Lights and Air Conditioning
public class Lights : IObserver {
    public void Update(bool occupied) {
        Console.WriteLine(occupied ? "Lights turned on." : "Lights turned off.");
    }
}

public class AirConditioning : IObserver {
    public void Update(bool occupied) {
        Console.WriteLine(occupied ? "Air conditioning turned on." : "Air conditioning turned off.");
    }
}

// Singleton: OfficeManager
public class OfficeManager {
    private static OfficeManager _instance;
    private Dictionary<int, Room> _rooms = new Dictionary<int, Room>();

    private OfficeManager() {}

    public static OfficeManager Instance {
        get {
            if (_instance == null) {
                _instance = new OfficeManager();
            }
            return _instance;
        }
    }

    // Configure office rooms
    public void AddRoom(int roomId) {
        if (!_rooms.ContainsKey(roomId)) {
            Room room = new Room();
            _rooms.Add(roomId, room);
            Console.WriteLine($"Room {roomId} configured.");
        }
    }

    // Book a room (Command pattern can be extended here)
    public void BookRoom(int roomId) {
        if (_rooms.ContainsKey(roomId)) {
            Console.WriteLine($"Room {roomId} booked.");
        }
    }

    // Simulate room occupancy
    public void SetRoomOccupied(int roomId, bool occupied) {
        if (_rooms.ContainsKey(roomId)) {
            _rooms[roomId].SetOccupied(occupied);
        }
    }

    public Room GetRoom(int roomId) {
        return _rooms.ContainsKey(roomId) ? _rooms[roomId] : null;
    }
}

// Usage Example
public class Program {
    public static void Main(string[] args) {
        OfficeManager officeManager = OfficeManager.Instance;

        // Configure rooms
        officeManager.AddRoom(1);
        officeManager.AddRoom(2);

        // Attach observers (Lights and AC) to Room 1
        Room room1 = officeManager.GetRoom(1);
        room1.AddObserver(new Lights());
        room1.AddObserver(new AirConditioning());

        // Set occupancy to trigger observers
        officeManager.SetRoomOccupied(1, true);  // Output: Lights turned on, AC turned on
        officeManager.SetRoomOccupied(1, false); // Output: Lights turned off, AC turned off

        // Book a room
        officeManager.BookRoom(2);
    }
}
