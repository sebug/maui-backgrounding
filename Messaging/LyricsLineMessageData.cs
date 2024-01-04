using CommunityToolkit.Mvvm.Messaging.Messages;

namespace maui_backgrounding.Messaging;

public class LyricsLineMessageData : ValueChangedMessage<string>
{
    public LyricsLineMessageData(string line) : base(line)
    {
        
    }
}