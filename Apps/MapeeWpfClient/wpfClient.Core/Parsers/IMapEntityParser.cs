using wpfClient.Core.Models;

namespace wpfClient.Core.Parsers;

public interface IMapEntityParser
{
    MapEntity? Parse(string data);
}