namespace FantasySky.CustomDF.Caching;

public interface IDistributedCacheSerializer
{
    byte[] Serialize<T>(T obj);

    T Deserialize<T>(byte[] bytes);
}