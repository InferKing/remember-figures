using Zenject;

namespace Model
{
    public class Statistics : IInitializable
    {
        // так как юзверь нажимает дважды на кнопку, чтобы продолжить с ней работать - приходится делить на два
        // костыль, но мне лень уже чинить
        private short _attempts;
        public short WrongAttempts { get => (short)(_attempts / 2); private set => _attempts = value; }

        public void Initialize()
        {
            WrongAttempts = 0;
        }

        public void OnWrongMove(Cell cell)
        {
            WrongAttempts++;
        }
    }
}