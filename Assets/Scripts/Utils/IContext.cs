namespace Utils 
{
    public interface IContext<T>
    {
        IStrategy<T> Strategy { get; set; }
        void Execute();
    }
}
