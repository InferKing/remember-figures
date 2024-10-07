using UnityEngine;
using Utils;
using TMPro;

namespace View
{
    public class CellText : MonoBehaviour, IStrategy<Model.Cell>
    {
        [SerializeField]
        private TMP_Text _text;

        public void Execute(Model.Cell cell)
        {

        }
    } 
}
