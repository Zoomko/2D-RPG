using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.CodeBase.Inventory
{
    public class InventoryView:MonoBehaviour
    {
        public event Action Closed;

        [SerializeField]
        private ViewSlot _slot;
        [SerializeField]
        private Transform _parentOfSlots;
        [SerializeField]
        private Button _closeButton;
        private List<ViewSlot> _slots;

        public void Constructor(List<ControllerSlot> slots, UnityAction Close)
        {
            _closeButton.onClick.AddListener(Close);
            CreateViewSlots(slots);
        }

        private void CreateViewSlots(List<ControllerSlot> slots)
        {
            _slots = new List<ViewSlot>();
            for (int i = 0; i < slots.Count; i++)
            {
                var controllerSlot = slots[i];
                var viewSlot = GameObject.Instantiate(_slot, _parentOfSlots);               
                _slots.Add(viewSlot);
                AddItem(i, controllerSlot);
            }
        }       
        public void AddItem(int slotId, ControllerSlot controllerSlot)
        {
            _slots[slotId].SetSlot(controllerSlot.Id, controllerSlot.Count, controllerSlot.Sprite);
        }

        public void RemoveItem(int slotId)
        {
            _slots[slotId].RemoveSlot();
        }

        public void ChangeCount(int slotId, int count)
        {
            _slots[slotId].ChangeCount(count);
        }
    }
}
