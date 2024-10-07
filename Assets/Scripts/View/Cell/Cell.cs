using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using DG.Tweening;

namespace View
{
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Image _image; 
        private Model.Cell _cellData;

        public void SetData(Model.Cell cellData)
        {
            _cellData = cellData;
            _text.text = _cellData.value.ToString();
        }

        public void OnCorrectMove()
        {
            Debug.Log("Correct");
        }

        public void OnWrongMove()
        {
            Debug.Log("Wrong");
        }

        public class Factory: PlaceholderFactory<Cell> { }
    }
}
