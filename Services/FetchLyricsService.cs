namespace maui_backgrounding.Services;

public partial class FetchLyricsService : IFetchLyricsService
{
    private string _lyricsUrl = "https://lyrics.lyricfind.com/lyrics/death-cab-for-cutie-no-room-in-frame";
    protected async Task<string> FetchLyrics()
    {
        using (var client = new HttpClient())
        {
            string content = await client.GetStringAsync(_lyricsUrl);
            return content;
        }
    }
}