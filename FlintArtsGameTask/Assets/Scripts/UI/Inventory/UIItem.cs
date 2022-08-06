using UnityEngine;

namespace UI.Inventory
{
    [CreateAssetMenu(fileName = "UIItem", menuName = "CreateUIItem")]
    public class UIItem : ScriptableObject
    {
        [SerializeField] private Sprite image;
        public Sprite Image => image;
    }
}