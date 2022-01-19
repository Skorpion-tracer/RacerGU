using Items;
using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UObject = UnityEngine.Object;

namespace Inventory
{
    public class InventoryView : MonoBehaviour, IInventoryView
    {
        [SerializeField] private RectTransform _placeForItems;
        
        private readonly Button _changeItem;
        private readonly ResourcePath _viewPath = new ResourcePath
        {
            PathResource = "Prefabs/ItemInventory"
        };

        public event EventHandler<IItem> Selected;
        public event EventHandler<IItem> Deselected;

        public void Display(IReadOnlyList<IItem> items)
        {
            foreach (var item in items)
            {
                Debug.Log($"Id item: {item.Id} title: {item.Info.Title}");
            }
        }

        public void Init(IReadOnlyList<IItem> items)
        {
            foreach (var item in items)
            {
                ItemView itemView = LoadItemsView();
                itemView.SetItems(item.Info);
            }
        }

        private ItemView LoadItemsView()
        {
            GameObject item = UObject.Instantiate(ResourceLoader.LoadPrefab(_viewPath), _placeForItems);
            return item.GetComponent<ItemView>();
        }
    }
}
