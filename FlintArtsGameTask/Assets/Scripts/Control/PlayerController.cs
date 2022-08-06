using Movement;
using UI;
using UI.Inventory;
using UnityEngine;

namespace Control
{
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

        public bool AddItemToInventory(UIItem uiItem)
        {
            if (!_inventory.AddItem(uiItem)) return false;
            
            uiInventory.RefreshView();
            hudInfoCanvas.FadeInOutMessage(Messages.ItemCollected(uiItem.Prefab.name));
            return true;

        }
        
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
