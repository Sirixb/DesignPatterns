using Core.Serializares;
using UnityEngine;

namespace Core.DataStorage
{
    public class PlayerPrefsDataStoreAdapter : DataStore
    {
        private readonly Serializer _serializar;
        
        public PlayerPrefsDataStoreAdapter(Serializer serializer)
        {
            _serializar = serializer;
        }

        public void SetData<T>(T data, string name)
        {
            var json = _serializar.ToJson<T>(data);
            PlayerPrefs.SetString(name, json);
            PlayerPrefs.Save();
        }

        public T GetData<T>(string name) /*where T: new()*/
        {
            //var defaultValue = new T();
            //var json = PlayerPrefs.GetString(name, _serializar.ToJson(defaultValue));  //Se cancela esta forma Debido a que el GetData me lo podria dar una libreria a la que no tenga acceso
            var json = PlayerPrefs.GetString(name);
            return _serializar.FromJson<T>(json);
        }
    }
}
