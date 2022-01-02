using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    public interface IItemsRepository
    {
        IReadOnlyDictionary<int, IItem> Items { get; }
        List<ItemConfig> ItemConfigs { get; }
    }
}
