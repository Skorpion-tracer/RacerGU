using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource")]
    public class UpgradeItemConfigDataSource : ScriptableObject
    {
        [SerializeField] private UpgradeItemConfig[] _itemConfigs;

        public UpgradeItemConfig[] ItemConfigs => _itemConfigs;
    }
}
