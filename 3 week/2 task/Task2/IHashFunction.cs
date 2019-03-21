namespace Task2
{
    public interface IHashFunction<T>
    {
        int Calculate(T key);
    }
}
