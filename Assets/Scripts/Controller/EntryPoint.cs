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
        private List<GameSettings> _settings;
        [SerializeField]
        private GameObject _cell;
        [SerializeField]
        private GameLoop _loop;

        public override void InstallBindings()
        {
            DOTween.Init();

            FileManager fm = new();
            Session session = fm.GetSession();
            GameSettings pickedSettings = _settings.First(item => item.Difficulty == session.difficulty);

            RegisterModel(pickedSettings);
            RegisterView();
        }

        private void RegisterView()
        {
            Container.BindFactory<View.Cell, View.Cell.Factory>().FromComponentInNewPrefab(_cell).AsSingle();
            Container.BindInterfacesAndSelfTo<View.Field>().AsSingle();
        }

        private void RegisterModel(GameSettings pickedSettings)
        {
            Container.Bind<GameLoop>().FromComponentInNewPrefab(_loop).AsSingle();
            Container.BindInstance(pickedSettings).AsSingle();
            Container.BindInstance(new GameModel(pickedSettings)).AsSingle();
            Container.Bind<Timer>().AsSingle();
            Container.BindInterfacesAndSelfTo<Statistics>().AsSingle();
        }
    }
}
