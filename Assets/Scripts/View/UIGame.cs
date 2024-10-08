using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Zenject;

namespace View
{
    [RequireComponent(typeof(UIDocument))]
    public class UIGame : MonoBehaviour
    {
        private Model.GameModel _model;
        private Model.Timer _timer;
        private Model.Statistics _statistics;
        private Model.GameSettings _settings;

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
        private void InitGameSettings(Model.GameSettings gameSettings) 
        {
            _settings = gameSettings;
        }

        private void ShowUI()
        {
            // БОЖЕ, я лучше с канвасом поработаю, честно
            // это чудо очень тяжело настраивать так, как хотелось бы
            // баг словил: если указывать root в runtime, а не изначально заготовленный => 
            // стили на высоту перестают работать и сжимают все VisualElement внутри по контенту.
            // Чинится только если жестко указать высоту в пикселях, что само по себе ловушка джокера :)
            var uiDocument = GetComponent<UIDocument>();
            uiDocument.enabled = true;

            VisualElement root = uiDocument.rootVisualElement;
            
            var lblTime = root.Q<Label>("time");
            var lblAttempts = root.Q<Label>("attempts");
            var lblDifficulty = root.Q<Label>("difficulty");
            var btnRestart = root.Q<Button>("restart");
            var btnMenu = root.Q<Button>("menu");

            lblTime.text = _timer.ToString();
            lblAttempts.text = _statistics.WrongAttempts.ToString();
            lblDifficulty.text = _settings.Difficulty.ToString();

            // это как будто не должно быть тут
            // ---------------------------------
            btnRestart.RegisterCallback<ClickEvent>(ev =>
            {
                SceneManager.LoadScene(1);
            });

            btnMenu.RegisterCallback<ClickEvent>(ev => 
            {
                SceneManager.LoadScene(0);
            });
            // ---------------------------------
        }
    } 
}
