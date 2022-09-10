namespace Core.DataStorage
{
    public interface DataStore
    {
        void SetData<T>(T data, string name);
        T GetData<T>(string name) /*where T : new()*/;
    }
}