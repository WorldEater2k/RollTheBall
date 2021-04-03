namespace RollTheBall
{
    internal interface IData<T>
    {
        public void Save(T data, string path);
        public T Load(string path);

    }
}
