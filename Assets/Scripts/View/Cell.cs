using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using DG.Tweening;

namespace View
{
    [RequireComponent(typeof(RectTransform)), RequireComponent(typeof(Canvas))]
    public class Cell : MonoBehaviour
    {
        [SerializeField]
        private float _motionTime = 0.25f;
        [SerializeField]
        private float _scaleValue = 0.95f;

        [SerializeField]
        private TMP_Text _text;
        [SerializeField]
        private Image _image;

        public event System.Action<byte, byte> Pressed;

        private Model.Cell _cellData;
        private Sequence _sequence;

        public void SetData(Model.Cell cellData)
        {
            _cellData = cellData;
            _text.text = _cellData.value.ToString();
            GetComponent<Canvas>().worldCamera = Camera.main;
        }

        public void Click()
        {
            if (_cellData.isLocked) return;

            Pressed?.Invoke(_cellData.row, _cellData.col);
        }

        public void OnCorrectMove(Model.Cell cell)
        {
            if (cell != _cellData) return;

            Show(Color.green);
        }

        public void OnWrongMove(Model.Cell cell)
        {
            if (cell != _cellData) return;

            if (_cellData.isShowed)
            {
                Hide();
            }
            else
            {
                Show(Color.red);
            }
        }

        public void Show(Color color)
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_scaleValue, _motionTime).SetEase(Ease.InOutBack))
                .AppendCallback(() =>
                {
                    _text.gameObject.SetActive(true);
                    SetColor(color);
                })
                .Append(transform.DOScale(1, _motionTime).SetEase(Ease.InOutBack));
        }

        public void Hide()
        {
            _sequence = DOTween.Sequence();
            _sequence.Append(transform.DOScale(_scaleValue, _motionTime).SetEase(Ease.InOutBack))
                .AppendCallback(() =>
                {
                    _text.gameObject.SetActive(false);
                    SetColor(Color.white);
                })
                .Append(transform.DOScale(1, _motionTime).SetEase(Ease.InOutBack));
        }

        private void SetColor(Color color)
        {
            _image.color = color;
        }

        public class Factory: PlaceholderFactory<Cell> { }
    }
}
