using Zenject;
using UnityEngine;
using Controller;

namespace View
{
    public class Field : IInitializable
    {
        private const float _spacing = 0.2f;

        private Model.IModel _model;
        private Cell[,] _cells;
        private Cell.Factory _factory;
        private GameLoop _gameLoop;

        [Inject]
        private void InitFactory(Cell.Factory factory)
        {
            _factory = factory;
        }

        [Inject]
        private void InitModel(Model.GameModel model)
        {
            _model = model;
        }

        [Inject]
        private void InitGameLoop(GameLoop gameLoop) 
        {
            _gameLoop = gameLoop;
            _gameLoop.GameStarted += OnGameStarted;
        }

        public void Initialize()
        {
            _cells = new Cell[_model.Row, _model.Column];

            for (byte i = 0; i < _model.Row; i++)
            {
                for (byte j = 0; j < _model.Column; j++)
                {
                    // как прокинуть в create, а не через setdata?
                    Cell cell = _factory.Create();
                    cell.SetData(_model.Table[i, j]);
                    cell.Show(Color.white);
                    _cells[i, j] = cell;
                    PlaceCellOnField(cell, i, j);

                    // field выступает в роли контроллера, хотя это view
                    // mvc говно (у меня не он, но я пытался)
                    // mvvm скорее всего лучше бы смотрелся
                    cell.Pressed += _model.Move;
                    _model.CorrectMove += cell.OnCorrectMove;
                    _model.WrongMove += cell.OnWrongMove;
                }
            }
        }

        private void OnGameStarted()
        {
            HideCells();
        }

        private void HideCells()
        {
            for (byte i = 0; i < _model.Row; i++)
            {
                for (byte j = 0; j < _model.Column; j++)
                {
                    _cells[i, j].Hide();
                }
            }
        }

        private void PlaceCellOnField(Cell cell, byte row, byte column)
        {
            Rect cellRect = cell.GetComponent<RectTransform>().rect;

            float totalWidth = cellRect.width * _model.Column + (_model.Column - 1) * _spacing;
            float totalHeight = cellRect.height * _model.Row + (_model.Row - 1) * _spacing;

            float offsetX = (totalWidth - cellRect.width) / 2;
            float offsetZ = (totalHeight - cellRect.height) / 2;

            float posX = column * (cellRect.width + _spacing) - offsetX;
            float posZ = row * (cellRect.height + _spacing) - offsetZ;

            cell.transform.position = new Vector3(posX, 0, posZ);
        }
    } 
}
