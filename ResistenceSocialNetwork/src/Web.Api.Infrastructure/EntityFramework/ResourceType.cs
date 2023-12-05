namespace src.Web.Api.Infrastructure.EntityFramework
{
    public enum ResourceType : int
    {
        Comida = 1,
        Agua = 2,
        Municao = 3,
        Arma = 4
    }  
    public static class ResourceTypeMethod
    {
        public static int GetPoints(ResourceType type)
        {
            return (int)type;
        }
        public static long GetTotalPoints(string type, long quantity)
        {
            var points = (int)ResourceType.Parse<ResourceType>(type, true);
            return quantity * points;
        }

    } 

}