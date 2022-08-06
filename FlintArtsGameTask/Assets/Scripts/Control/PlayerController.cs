using Movement;
using UI;
using UI.Inventory;
using UnityEngine;

namespace Control
{
    /// <summary>
    /// Controls whole player action like movement and manage inventory.
    /// </summary>
    [RequireComponent(typeof(Mover))]
    public class PlayerController : MonoBehaviour
    {
        [Header("HUD")]
        [SerializeField] private HUDInfoCanvas hudInfoCanvas;
        
        [Header("Inventory")]
        [SerializeField] private UIInventory uiInventory;
        [SerializeField] private int inventoryMaxSize = 2;
        
        [Header("Movement")]
        [SerializeField] private float speedFraction = 1f;
        
        private Inventory _inventory;

        private void Start()
        {
            _inventory = new Inventory(inventoryMaxSize);
            uiInventory.SetInventory(_inventory);
        }

        private void Update()
        {
            InteractWithMovement();
        }

        /// <summary>
        /// Manages addition of items to the inventory.
        /// </summary>
        /// <param name="uiItem">Item which is added to the inventory.</param>
        /// <returns>Returns a bool based on whether addition had been completed successfully or not.</returns>
        public bool AddItemToInventory(UIItem uiItem)
        {
            if (!_inventory.AddItem(uiItem)) return false;
            
            uiInventory.RefreshView();
            hudInfoCanvas.FadeInOutMessage(Messages.ItemCollected(uiItem.Prefab.name));
            return true;

        }
        
        /// <summary>
        /// Manages removal of items from the inventory.
        /// </summary>
        /// <param name="uiItem">Item which is removed from the inventory.</param>
        public void RemoveItemFromInventory(UIItem uiItem)
        {
            _inventory.RemoveItem(uiItem);
            uiInventory.RefreshView();
            hudInfoCanvas.FadeInOutMessage(Messages.ItemRemovedFromInventory(uiItem.Prefab.name));
        }
        
        private void InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point, speedFraction);
                }
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
