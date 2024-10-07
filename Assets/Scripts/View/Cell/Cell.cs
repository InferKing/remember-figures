using UnityEngine;
using Utils;
using Zenject;

namespace View
{
    public class Cell : MonoBehaviour, IContext<Model.Cell>
    {
        public IStrategy<Model.Cell> Strategy { get; set; }

        private Model.Cell _cellData;

        public Cell(Model.Cell cellData, IStrategy<Model.Cell> strategy)
        {
            _cellData = cellData;
            Strategy = strategy;
        }

        public void Execute()
        {
            Strategy.Execute(_cellData);
        }

        public void OnCorrectMove()
        {
            // do smth...
        }

        public void OnWrongMove()
        {
            // do smth...
        }

        public class Factory: PlaceholderFactory<Model.Cell, Cell> { }
    }
}
