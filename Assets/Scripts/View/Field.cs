using Zenject;
using System.Collections.Generic;
using System.Collections;
using Utils;
using UnityEngine;

namespace View
{
    public class Field : IInitializable
    {
        private Model.IModel _model;
        private Cell.Factory _factory;
        private const float _spacing = 0.2f;
        private Rect _fieldRect;

        [Inject]
        public void InitFactory(Cell.Factory factory)
        {
            _factory = factory;
        }

        [Inject]
        public void InitModel(Model.GameModel model)
        {
            _model = model;

        }

        public void Initialize()
        {
            _fieldRect = new(0, 0, 0, 0);

            for (byte i = 0; i < _model.Row; i++)
            {
                for (byte j = 0; j < _model.Column; j++)
                {
                    // как прокинуть в create, а не через setdata?
                    Cell cell = _factory.Create();
                    cell.SetData(_model.Table[i, j]);
                    cell.transform.position = new Vector3(j, 0, i);

                    _model.CorrectMove += cell.OnCorrectMove;
                    _model.WrongMove += cell.OnWrongMove;
                }
            }
        }
    } 
}
