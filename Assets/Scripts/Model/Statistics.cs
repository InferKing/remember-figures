using Zenject;

namespace Model
{
    public class Statistics : IInitializable
    {
        public short WrongAttempts { get; private set; }

        public void Initialize()
        {
            WrongAttempts = 0;
        }

        public void OnWrongMove()
        {
            WrongAttempts++;
        }
    }
}