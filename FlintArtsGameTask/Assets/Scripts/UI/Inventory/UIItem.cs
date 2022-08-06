using UnityEngine;

namespace UI.Inventory
{
    [CreateAssetMenu(fileName = "UIItem", menuName = "CreateUIItem")]
    public class UIItem : ScriptableObject
    {
        [SerializeField] private Sprite uiImage;
        [SerializeField] private GameObject prefab;
        
        public Sprite UIImage => uiImage;
        public GameObject Prefab => prefab;
    }
}