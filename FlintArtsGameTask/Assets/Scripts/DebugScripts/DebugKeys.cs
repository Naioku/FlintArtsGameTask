using UI.Inventory;
using UnityEngine;

namespace DebugScripts
{
    public class DebugKeys : MonoBehaviour
    {
        [SerializeField] private UIInventory uiInventory;
        
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                uiInventory.ClearView();
            }
        }
    }
}
