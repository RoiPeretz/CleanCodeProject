namespace MapRepositoryService.Core.Data.Maps.Queries
{
    public interface IMapExistsQuery
    {
        public bool Exists(string name);
    }
}
