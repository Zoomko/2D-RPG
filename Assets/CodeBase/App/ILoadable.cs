namespace Assets.CodeBase.App
{
    public interface ILoadable<T>
    {
        void Load(T obj);
    }
}
