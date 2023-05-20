using Assets.CodeBase.App.Services.Input;
using Assets.CodeBase.Data.StaticData;
using Assets.CodeBase.Factories;
using Assets.CodeBase.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor.Graphs;
using UnityEngine;

namespace Assets.CodeBase.Inventory
{
    public class InventoryController
    {
        private readonly int _countOfItemsInInventory = 16;
        private readonly InventoryModel _inventoryModel;
        private readonly IWindowsFactory _windowsFactory;
        private readonly IStaticDataService _staticDataService;
        private readonly IUIInputService _uiInputService;

        private InventoryView _inventoryView;
        private InventoryContextMenu _inventoryContextMenu;
        
        public InventoryController(IWindowsFactory windowsFactory,IStaticDataService staticDataService, IUIInputService uiInputService) 
        {
            _inventoryModel = new InventoryModel(_countOfItemsInInventory);
            _windowsFactory = windowsFactory;
            _staticDataService = staticDataService;
            _uiInputService = uiInputService;

            _uiInputService.InventoryButtonPressed += OnInventoryButtonPressed;

            _inventoryModel.CountChanged += OnCountChanged;
            _inventoryModel.ItemAdded += OnItemAdded;
            _inventoryModel.ItemRemoved += OnItemRemoved;            
        }       

        public void Open()
        {
            _inventoryView = _windowsFactory.CreateWindow<InventoryView>("Inventory");
            _inventoryView.ClickOnSlotWithItemId += OnClickOnSlot;
            var slots = CreateControllerSlots();
            _inventoryView.Constructor(slots, Close);
        }

        private void OnClickOnSlot(int id, Vector2 clickPosition)
        {
            if(_inventoryContextMenu == null)            
                _inventoryContextMenu = _windowsFactory.CreateWindow<InventoryContextMenu>("InventoryContextMenu");
            _inventoryContextMenu.SetContextMenuToPosition(clickPosition);
            _inventoryContextMenu.Contructor(this, id);
        }

        public void Close()
        {
            _inventoryView.ClickOnSlotWithItemId -= OnClickOnSlot;
            if (_inventoryContextMenu != null)
                GameObject.Destroy(_inventoryContextMenu.gameObject);
            GameObject.Destroy(_inventoryView.gameObject); 
        }

        public void AddItem(int id, int count)
        {
            _inventoryModel.AddItem(id, count);
        }

        public void RemoveItem(int id)
        {
            _inventoryModel.RemoveItem(id);
        }

        public bool CanSpendBullet()
        {
            var _bulletId = _staticDataService.ItemsWithKeyNames["Bullet"].Id;
            return _inventoryModel.CanTakeOne(_bulletId);
        }

        public void SpendBullet()
        {
            var _bulletId = _staticDataService.ItemsWithKeyNames["Bullet"].Id;
            _inventoryModel.TakeOneItem(_bulletId);
        }

        private void OnInventoryButtonPressed()
        {
            if (_inventoryView != null)
            {
                Close();
            }
            else
                Open();
        }

        private List<ControllerSlot> CreateControllerSlots()
        {
            var slots = new List<ControllerSlot>();
            foreach(var modelSlot in _inventoryModel.Slots)
            {
                slots.Add(CreateControllerSlot(modelSlot));
            }
            return slots;
        }

        private ControllerSlot CreateControllerSlot(ModelSlot modelSlot)
        {
            var slot = new ControllerSlot();
            if(modelSlot.SlotType == SlotType.Filled)
            {
                slot.Id = modelSlot.ItemId;
                slot.Count = modelSlot.ItemCount;
                slot.Sprite = _staticDataService.Items[slot.Id].Sprite;
                slot.Name = _staticDataService.Items[slot.Id].Name;
            }            
            return slot;
        }

        private void OnItemAdded(ModelSlot modelSlot)
        {
            if(_inventoryView != null)
            {
                var slot = CreateControllerSlot(modelSlot);
                _inventoryView.AddItem(modelSlot.SlotId, slot);
            }
        }

        private void OnCountChanged(ModelSlot modelSlot, int count)
        {
            if (_inventoryView != null)
            {
                _inventoryView.ChangeCount(modelSlot.SlotId, count);
            }
        }

        private void OnItemRemoved(ModelSlot modelSlot)
        {
            if (_inventoryView != null)
            {
                _inventoryView.RemoveItem(modelSlot.SlotId);
            }
        }

    }
}
