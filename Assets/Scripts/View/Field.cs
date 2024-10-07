using Zenject;

namespace View
{
    public class Field : IInitializable
    {
        private Model.IModel _model;
        private Cell.Factory _factory;

        [Inject]
        public void InitFactory(Cell.Factory factory)
        {
            _factory = factory;
        }

        [Inject]
        public void InitModel(Model.IModel model)
        {
            _model = model;
        }

        public void Initialize()
        {
            for (byte i = 0; i < _model.Row; i++)
            {
                for (byte j = 0; j < _model.Column; j++)
                {
                    Cell cell = _factory.Create(_model.Table[i, j]);
                    _model.CorrectMove += cell.OnCorrectMove;
                    _model.WrongMove += cell.OnWrongMove;
                }
            }
        }
    } 
}
