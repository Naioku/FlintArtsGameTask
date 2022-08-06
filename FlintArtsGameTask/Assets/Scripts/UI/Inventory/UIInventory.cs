using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Inventory
{
    public class UIInventory : MonoBehaviour
    {
        [Tooltip("Content of the UI inventory.")]
        [SerializeField] private RectTransform content;
        
        [SerializeField] private GameObject inventorySlotPrefab;
        
        private Inventory _inventory;

        public void SetInventory(Inventory inventory)
        {
            _inventory = inventory;
            SetMaxSize();
        }

        public void RefreshView()
        {
            ClearView();
            int inventorySlotIndex = 0;
            foreach (var item in _inventory.GetAllItems)
            {
                Transform inventoryItem = content.GetChild(inventorySlotIndex).GetChild(0);
                var image = inventoryItem.GetComponent<Image>();
                image.sprite = item.UIImage;
                image.enabled = true;
                
                inventoryItem.GetComponent<Button>().interactable = true;

                inventoryItem.GetComponent<InventoryItem>().SetUIItem(item);
                
                inventorySlotIndex++;
            }
        }

        public void ClearView()
        {
            foreach (RectTransform itemSlot in content)
            {
                var image = itemSlot.GetChild(0).GetComponent<Image>();
                image.sprite = null;
                image.enabled = false;
            }
        }

        private void SetMaxSize()
        {
            for (int i = 0; i < _inventory.MaxSize; i++)
            {
                Instantiate(inventorySlotPrefab, content);
            }
        }
    }
}
