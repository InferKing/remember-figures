using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Zenject;

namespace View
{
    [RequireComponent(typeof(UIDocument))]
    public class UIGame : MonoBehaviour
    {
        private const string LabelTime = "time";
        private const string LabelAttempts = "attempts";
        private const string LabelDifficulty = "difficulty";
        private const string ButtonRestart = "restart";
        private const string ButtonMenu = "menu";

        private Model.GameModel _model;
        private Model.Timer _timer;
        private Model.Statistics _statistics;
        private Model.GameConfig _settings;

        [Inject]
        private void InitModel(Model.GameModel model)
        {
            _model = model;
            _model.EndOfGame += ShowUI;
        }

        [Inject]
        private void InitTimer(Model.Timer timer)
        {
            _timer = timer;
        }

        [Inject]
        private void InitStatistics(Model.Statistics statistics) 
        {
            _statistics = statistics;
        }

        [Inject]
        private void InitGameConfig(Model.GameConfig GameConfig) 
        {
            _settings = GameConfig;
        }

        private void ShowUI()
        {
            var uiDocument = GetComponent<UIDocument>();
            uiDocument.enabled = true;

            VisualElement root = uiDocument.rootVisualElement;
            
            var labelTime = root.Q<Label>(LabelTime);
            var labelAttempts = root.Q<Label>(LabelAttempts);
            var labelDifficulty = root.Q<Label>(LabelDifficulty);
            var buttonRestart = root.Q<Button>(ButtonRestart);
            var buttonMenu = root.Q<Button>(ButtonMenu);

            labelTime.text = _timer.ToString();
            labelAttempts.text = _statistics.WrongAttempts.ToString();
            labelDifficulty.text = _settings.Difficulty.ToString();

            buttonRestart.RegisterCallback<ClickEvent>(ev =>
            {
                SceneManager.LoadScene(1);
            });

            buttonMenu.RegisterCallback<ClickEvent>(ev => 
            {
                SceneManager.LoadScene(0);
            });
        }
    } 
}
