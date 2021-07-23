namespace Interfaces
{
    public interface IStorage<T>
    {
        public T Get(int n);
        public void Add(int n);
    }
}