using Game.InputLogic;
using Inventory;
using Items;
using Profile;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    internal class MainController : BaseController
    {
        public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfigs)
        {
            _profilePlayer = profilePlayer;
            _placeForUi = placeForUi;
            _itemConfigs = itemConfigs;
            OnChangeGameState(_profilePlayer.CurrentState.Value);
            profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
        }

        private MainMenuController _mainMenuController;
        private GameController _gameController;
        private InventoryController _inventoryController;

        private readonly Transform _placeForUi;
        private readonly ProfilePlayer _profilePlayer;
        private readonly List<ItemConfig> _itemConfigs;

        protected override void OnDispose()
        {
            _mainMenuController?.Dispose();
            _gameController?.Dispose();
            _profilePlayer.CurrentState.UnSubscriptionOnChange(OnChangeGameState);
            base.OnDispose();
        }

        private void OnChangeGameState(GameState state)
        {
            switch (state)
            {
                case GameState.Start:
                    _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                    _gameController?.Dispose();
                    break;
                case GameState.Game:
                    _inventoryController = new InventoryController(_itemConfigs, _placeForUi);
                    _inventoryController.ShowInventory();

                    _gameController = new GameController(_profilePlayer);
                    _profilePlayer.AnalyticsTools.SendMessage("Time before the start", ("Time", Time.realtimeSinceStartup));
                    _mainMenuController?.Dispose();
                    break;
                default:
                    _mainMenuController?.Dispose();
                    _gameController?.Dispose();
                    break;
            }
        }
    } 
}
