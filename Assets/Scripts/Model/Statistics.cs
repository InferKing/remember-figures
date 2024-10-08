using Zenject;

namespace Model
{
    public class Statistics : IInitializable
    {
        // ��� ��� ������ �������� ������ �� ������, ����� ���������� � ��� �������� - ���������� ������ �� ���
        // �������, �� ��� ���� ��� ������
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