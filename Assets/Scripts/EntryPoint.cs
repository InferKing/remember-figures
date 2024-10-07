using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;
using Model;

namespace Controller
{
    public class EntryPoint : MonoInstaller
    {
        [SerializeField]
        private List<GameSettings> _settings;
        [SerializeField]
        private GameObject _cell;

        public override void InstallBindings()
        {
            FileManager fm = new();
            Session session = fm.LoadSession();
            GameSettings pickedSettings = _settings.First(item => item.Difficulty == session.difficulty);

            Container.BindInstance(new GameModel(pickedSettings)).AsSingle();
            Container.BindFactory<View.Cell, View.Cell.Factory>().FromComponentInNewPrefab(_cell);
            Container.BindInterfacesAndSelfTo<View.Field>().AsSingle();
        }
    } 
}
