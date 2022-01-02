using UnityEngine;

namespace Items
{
    [CreateAssetMenu(fileName = "ItemConfig", menuName = "ItemConfig")]
    public class ItemConfig : ScriptableObject
    {
        [SerializeField] private int _id;
        [SerializeField] private string _title;
        [SerializeField] private Sprite _sprite;

        public int Id => _id;
        public string Title => _title;
        public Sprite Sprite => _sprite;
    }
}
