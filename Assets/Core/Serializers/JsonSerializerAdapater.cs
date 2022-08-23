using UnityEngine;

namespace Core.Serializares
{
    public class JsonSerializerAdapater : Serializer
    {
               
        string Serializer.ToJson<T>(T data)
        {
            return JsonUtility.ToJson(data);
        }

        T Serializer.FromJson<T>(string data)
        {
           return JsonUtility.FromJson<T>(data);
        }
    }
}