using Items;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public interface IInventoryView
    {
        event EventHandler<IItem> Selected;
        event EventHandler<IItem> Deselected;
        void Display(IReadOnlyList<IItem> items);
    }
}
