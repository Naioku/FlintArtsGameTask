using Movement;
using UI.Inventory;
using UnityEngine;

namespace Control
{
    [RequireComponent(typeof(Mover))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private UIInventory uiInventory;
        private Inventory _inventory;

        private void Start()
        {
            _inventory = new Inventory();
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
            return true;

        }
        
        private void InteractWithMovement()
        {
            RaycastHit hit;
            bool hasHit = Physics.Raycast(GetMouseRay(), out hit);
            if (hasHit)
            {
                if (Input.GetMouseButton(0))
                {
                    GetComponent<Mover>().MoveTo(hit.point, 1f);
                }
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
