namespace Interfaces
{
    public interface IStorage<T>
    {
        public T Get(float n);
        public void Add(float n);
    }
}