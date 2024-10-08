using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Model;
using DG.Tweening;

namespace Controller
{
    public class EntryPoint : MonoInstaller
    {
        [SerializeField]
        private List<GameConfig> _settings;

        [SerializeField]
        private View.Cell _cellPrefab;
        [SerializeField]
        private GameLoop _loopPrefab;

        public override void InstallBindings()
        {
            DOTween.Init();

            FileManager fileManager = new();
            Session session = fileManager.GetSession();
            GameConfig pickedSettings = _settings.First(item => item.Difficulty == session.Difficulty);

            RegisterModel(pickedSettings);
            RegisterView();
        }

        private void RegisterView()
        {
            Container.BindFactory<View.Cell, View.Cell.Factory>().FromComponentInNewPrefab(_cellPrefab).AsSingle();
            Container.BindInterfacesAndSelfTo<View.Field>().AsSingle();
        }

        private void RegisterModel(GameConfig pickedSettings)
        {
            Container.Bind<GameLoop>().FromComponentInNewPrefab(_loopPrefab).AsSingle();
            Container.BindInstance(pickedSettings).AsSingle();
            Container.BindInstance(new GameModel(pickedSettings)).AsSingle();
            Container.Bind<Timer>().AsSingle();
            Container.BindInterfacesAndSelfTo<Statistics>().AsSingle();
        }
    }
}
