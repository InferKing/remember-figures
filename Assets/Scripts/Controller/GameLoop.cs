using Model;
using System;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Controller
{
    public class GameLoop : MonoBehaviour
    {
        public event Action GameStarted;

        private Timer _timer;
        private GameConfig _settings;
        private GameModel _model;
        private Statistics _statistics;

        [Inject]
        private void InitTimer(Timer timer)
        {
            _timer = timer;
        }

        [Inject]
        private void InitSettings(GameConfig settings)
        {
            _settings = settings;
        }

        [Inject]
        private void InitModel(GameModel model)
        {
            _model = model;
            _model.EndOfGame += OnGameEnded;
        }

        [Inject]
        private void InitStatistics(Statistics statistics)
        {
            _statistics = statistics;
        }

        private void Start()
        {
            _model.WrongMove += _statistics.OnWrongMove;
            StartCoroutine(DelayBeforeStart());
        }

        private void OnGameEnded()
        {
            _timer.Stop();
        }

        private IEnumerator DelayBeforeStart()
        {
            yield return new WaitForSeconds(_settings.TimeBeforeHide);
            _timer.Start();
            GameStarted?.Invoke();
        }
    } 
}
