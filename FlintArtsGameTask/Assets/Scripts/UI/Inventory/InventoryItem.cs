using Control;
using UnityEngine;

namespace UI.Inventory
{
    /// <summary>
    /// Manages inventory item displayed in the UI side of inventory.
    /// </summary>
    public class InventoryItem : MonoBehaviour
    {
        private UIItem _uiItem;

        public void SetUIItem(UIItem uiItem)
        {
            _uiItem = uiItem;
        }

        /// <summary>
        /// Method used by Button component. Manages dropping item from inventory to the world space.
        /// </summary>
        public void OnDropItem()
        {
            var playerController = FindObjectOfType<PlayerController>();
            InstantiateItem(playerController);
            playerController.RemoveItemFromInventory(_uiItem);
        }

        private void InstantiateItem(PlayerController playerController)
        {
            Transform playerTransform = playerController.transform;
            Vector3 dropPosition = playerTransform.position + playerTransform.forward * 2f;
            GameObject pickupsContainer = GameObject.FindWithTag("PickupsContainer");
            Instantiate(_uiItem.Prefab, dropPosition, Quaternion.identity).transform.SetParent(pickupsContainer.transform);
        }
    }
}
