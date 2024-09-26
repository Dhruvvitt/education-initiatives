using System; 

// Old Messaging Service (Legacy)
public class OldMessagingService {
    public void SendMessage(string text) {
        Console.WriteLine($"Sending message via old system: {text}");
    }
}

// New Messaging Service (Target)
public interface INewMessagingService {
    void Send(string text);
}

// Adapter Class
public class MessagingAdapter : INewMessagingService {
    private readonly OldMessagingService _oldService;

    public MessagingAdapter(OldMessagingService oldService) {
        _oldService = oldService;
    }

    public void Send(string text) {
        _oldService.SendMessage(text);
    }
}

// Usage Example
class Program {
    static void Main() {
        var oldService = new OldMessagingService();
        var newChatApp = new MessagingAdapter(oldService);

        newChatApp.Send("Hello, World!"); // Output: Sending message via old system: Hello, World!
    }
}
