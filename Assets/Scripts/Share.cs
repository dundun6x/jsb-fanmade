public class Share<T> where T : struct
{
    public T value;

    public Share() => value = default(T);
    public Share(T value) => this.value = value;
}