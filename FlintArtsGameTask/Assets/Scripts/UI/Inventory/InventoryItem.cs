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
