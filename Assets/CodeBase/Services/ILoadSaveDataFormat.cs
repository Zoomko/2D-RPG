namespace Assets.CodeBase.Services
{
    public interface ILoadSaveDataFormat
    {

        T Load<T>(string path);
        void Save<T>(string path, T data);
    }
}