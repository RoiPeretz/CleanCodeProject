using wpfClient.Core.Models;
using static System.Int32;

namespace wpfClient.Core.Parsers;

public class MapEntityParser : IMapEntityParser
{
    public MapEntity? Parse(string data)
    {
        var parts = data.Split(' ');
        if (parts is not { Length: 3 }) return null;

        var title = parts[0];
        var tryParseX = TryParse(parts[1], out var x);
        var tryParseY = TryParse(parts[2], out var y);

        if (tryParseX && tryParseY) return new MapEntity(title, x, y);
        return null;
    }
}