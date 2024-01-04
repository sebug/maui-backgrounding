using CommunityToolkit.Mvvm.Messaging.Messages;

namespace maui_backgrounding.Messaging;

public class MessageData : ValueChangedMessage<string>
{
    public bool Start { get; }
    public MessageData(string message, bool start) : base(message)
    {
        this.Start = start;
    }
}

