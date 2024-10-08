using Zenject;
using UnityEngine;
using Controller;

namespace View
{
    public class Field : IInitializable
    {
        private const float Spacing = 0.2f;

        private Model.IModel _model;
        private Cell[,] _cells;
        private Cell.Factory _factory;
        private GameLoop _gameLoop;

        public void Initialize()
        {
            _cells = new Cell[_model.Row, _model.Column];

            for (byte i = 0; i < _model.Row; i++)
            {
                for (byte j = 0; j < _model.Column; j++)
                {
                    Cell cell = _factory.Create();
                    cell.SetData(_model.Table[i, j]);
                    cell.Show(Color.white);
                    _cells[i, j] = cell;
                    PlaceCellOnField(cell, i, j);

                    cell.Pressed += _model.Move;
                    _model.CorrectMove += cell.OnCorrectMove;
                    _model.WrongMove += cell.OnWrongMove;
                }
            }
        }

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

            float totalWidth = cellRect.width * _model.Column + (_model.Column - 1) * Spacing;
            float totalHeight = cellRect.height * _model.Row + (_model.Row - 1) * Spacing;

            float offsetX = (totalWidth - cellRect.width) / 2;
            float offsetZ = (totalHeight - cellRect.height) / 2;

            float posX = column * (cellRect.width + Spacing) - offsetX;
            float posZ = row * (cellRect.height + Spacing) - offsetZ;

            cell.transform.position = new Vector3(posX, 0, posZ);
        }
    } 
}
