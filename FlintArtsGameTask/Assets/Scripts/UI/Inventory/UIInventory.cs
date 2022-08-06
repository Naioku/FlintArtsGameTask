using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class UIInventory : MonoBehaviour
    {
        [Tooltip("Content of the UI inventory.")]
        [SerializeField] private RectTransform content;
        
        [SerializeField] private GameObject inventorySlot;
        
        private Inventory _inventory;

        public void SetInventory(Inventory inventory)
        {
            _inventory = inventory;
            SetMaxSize();
        }

        public void RefreshView()
        {
            int childIndex = 0;
            foreach (var item in _inventory.GetAllItems)
            {
                var image = content.GetChild(childIndex).GetChild(0).GetComponent<Image>();
                image.sprite = item.Image;
                image.enabled = true;
                
                childIndex++;
            }
        }

        private void SetMaxSize()
        {
            for (int i = 0; i < _inventory.MaxSize; i++)
            {
                Instantiate(inventorySlot, content);
            }
        }
    }
}
