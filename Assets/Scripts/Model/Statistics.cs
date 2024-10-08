using Zenject;

namespace Model
{
    public class Statistics : IInitializable
    {
        private int _attempts;

        public void Initialize()
        {
            WrongAttempts = 0;
        }

        public int WrongAttempts { get => _attempts / 2; private set => _attempts = value; }

        public void OnWrongMove(Cell cell)
        {
            WrongAttempts++;
        }
    }
}