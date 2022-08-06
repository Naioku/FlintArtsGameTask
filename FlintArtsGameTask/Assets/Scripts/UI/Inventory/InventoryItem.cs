using Control;
using UnityEngine;

namespace UI.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        private UIItem _uiItem;

        public void SetUIItem(UIItem uiItem)
        {
            _uiItem = uiItem;
        }

        public void OnDropItem()
        {
            var playerController = FindObjectOfType<PlayerController>();
            playerController.RemoveItemFromInventory(_uiItem);
            Transform playerTransform = playerController.transform;
            Vector3 dropPosition = playerTransform.position + playerTransform.forward * 2f;
            Instantiate(_uiItem.Prefab, dropPosition, Quaternion.identity);
        }
    }
}
