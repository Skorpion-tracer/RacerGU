using Controllers;
using Items;
using System.Collections;
using System.Collections.Generic;
using Tools;
using UnityEngine;

namespace Inventory
{
    internal class InventoryController : BaseController, IInventoryController
    {
        private readonly IInventoryModel _inventoryModel;
        private readonly IInventoryView _inventoryView;
        private readonly IItemsRepository _itemsRepository;

        private readonly Transform _placeForUi;

        public InventoryController(List<ItemConfig> itemConfigs, Transform placeForUi)
        {
            _inventoryModel = new InventoryModel();
            _inventoryView = new InventoryView();
            _itemsRepository = new ItemsRepository(itemConfigs);
            _placeForUi = placeForUi;

            _view = LoadView();            
        }

        private readonly ResourcePath _viewPath = new ResourcePath
        {
            PathResource = "Prefabs/InventoryPanel"
        };
        private InventoryView _view;
        private InventoryView LoadView()
        {
            GameObject objView = Object.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeForUi);
            AddGameObjects(objView);
            return objView.GetComponent<InventoryView>();
        }

        public void ShowInventory()
        {
            foreach (var item in _itemsRepository.Items.Values)
            {
                _inventoryModel.EquipItem(item);
            }

            var equippedItem = _inventoryModel.GetEquippedItems();
            _inventoryView.Display(equippedItem);
            _view.Init(equippedItem);
        }
    }
}
