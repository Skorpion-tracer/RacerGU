using UnityEngine;
using UnityEngine.UI;

namespace Items
{
    public class ItemView : MonoBehaviour
    {
        [SerializeField] private Image _sprite;
        [SerializeField] private Text _title;

        public void SetItems(ItemInfo item)
        {
            _sprite.sprite = item.Sprite;
            _title.text = item.Title;
        }
    }
}
