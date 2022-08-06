using Control;
using UI.Inventory;
using UnityEngine;

namespace Pickable
{
    public class PickableItem : MonoBehaviour
    {
        [SerializeField] private UIItem uiItem;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.tag.Equals("Player")) return;

            if (other.gameObject.GetComponent<PlayerController>().AddItemToInventory(uiItem))
            {
                Destroy(gameObject);
            }
        }
    }
}
