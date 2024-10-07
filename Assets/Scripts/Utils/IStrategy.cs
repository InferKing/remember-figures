namespace Utils
{

	public interface IStrategy<T>
	{
		void Execute(T value);
	}
}
