using Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    internal class ItemsRepository : BaseController, IItemsRepository
    {
        public List<ItemConfig> ItemConfigs { get; }
        public IReadOnlyDictionary<int, IItem> Items => _itemsMapById;
        private Dictionary<int, IItem> _itemsMapById = new Dictionary<int, IItem>();

        public ItemsRepository(List<ItemConfig> itemConfigs)
        {
            PopulateItems(itemConfigs);
            ItemConfigs = itemConfigs;
        }

        protected override void OnDispose()
        {
            _itemsMapById.Clear();
        }

        private void PopulateItems(List<ItemConfig> configs)
        {
            foreach(var config in configs)
            {
                if (_itemsMapById.ContainsKey(config.Id))
                    continue;

                _itemsMapById.Add(config.Id, CreateItem(config));
            }
        }

        private IItem CreateItem(ItemConfig config)
        {
            var itemInfo = new ItemInfo 
            { 
                Title = config.Title,
                Sprite = config.Sprite
            };

            return new Item
            {
                Id = config.Id,
                Info = itemInfo
            };
        }
    }
}
