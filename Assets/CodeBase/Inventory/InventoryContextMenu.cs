using UnityEngine;
using UnityEngine.UI;

namespace Assets.CodeBase.Inventory
{
    public class InventoryContextMenu : MonoBehaviour
    {
        [SerializeField]
        private GameObject _panel;
        [SerializeField]
        private Button _deleteButton;

        private int _idItem;
        private InventoryController _inventoryController;

        public void Contructor(InventoryController inventoryController, int idItem)
        {
            _inventoryController = inventoryController;
            _idItem = idItem;
        }

        private void Awake()
        {
            _deleteButton.onClick.AddListener(OnDeleteButtonClicked);
        }

        public void SetContextMenuToPosition(Vector2 position)
        {
            _panel.transform.position = position;
        }

        private void OnDeleteButtonClicked()
        {
            _inventoryController.RemoveItem(_idItem);
            Destroy(gameObject);
        }
    }
}
