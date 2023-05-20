using System.Collections.Generic;
using System;
using System.Linq;
using Codice.Client.BaseCommands.Import;

namespace Assets.CodeBase.Inventory
{
    public class InventoryModel
    {
        public event Action<ModelSlot> ItemAdded;
        public event Action<ModelSlot, int> CountChanged;
        public event Action<ModelSlot> ItemRemoved;

        private List<ModelSlot> _slots = new List<ModelSlot>();
        public List<ModelSlot> Slots  => _slots; 


        public InventoryModel(int slotsNumber)
        {
            for(int i = 0; i < slotsNumber; i++)
            {
                var modelSlot = new ModelSlot(i);
                modelSlot.SlotType = SlotType.Empty;
                _slots.Add(modelSlot);
            }
        }

        public void AddItem(int id, int count)
        {
            if(ContainsSlotWithId(id))
            {
                var modelSlot = GetSlotById(id); 
                ChangeCount(modelSlot, count);
            }    
            else if (CanAddItem())
            {
                var modelSlot = GetEmptySlot();
                modelSlot.SlotType = SlotType.Filled;
                modelSlot.ItemId = id;
                ItemAdded?.Invoke(modelSlot);
                ChangeCount(modelSlot, count);
            }
            else
                throw new ArgumentOutOfRangeException("There are no more empty slots");
        }

        public void AddOneItem(int id)
        {
            AddItem(id, 1);
        }

        public void TakeItem(int id, int count)
        {
            if (ContainsSlotWithId(id))
            {
                var modelSlot = GetSlotById(id);
                ChangeCount(modelSlot, -count);
                if (modelSlot.ItemCount == 0)
                {
                    RemoveItem(id);                    
                }
                else if (modelSlot.ItemCount < 0)
                    throw new ArgumentOutOfRangeException("You trying to take more items than it be");
            }
            else throw new ArgumentException("There is no slot with this id");
        }

        public void TakeOneItem(int id)
        {
            TakeItem(id, 1);
        }

        public bool CanTake(int id, int count)
        {
            if (ContainsSlotWithId(id))
            {
                var modelSlot = GetSlotById(id);
                if(modelSlot.ItemCount - count >= 0)
                    return true;
                else return false;
            }
            return false;
        }

        public bool CanTakeOne(int id)
        {
            return CanTake(id, 1);
        }

        public bool CanAddItem()
        {
            if(GetEmptySlotsCount() > 0)
                return true;
            else return false;
        }

        public void RemoveItem(int id)
        {
            var slot = GetSlotById(id);
            slot.SlotType = SlotType.Empty;
            slot.ItemCount = -1;
            slot.ItemId = -1;
            ItemRemoved?.Invoke(slot);
        }

        private void ChangeCount(ModelSlot slot, int count)
        {
            slot.ItemCount += count;
            CountChanged?.Invoke(slot, count);
        }

        private ModelSlot GetEmptySlot()
            => _slots.Where(x => x.SlotType == SlotType.Empty).FirstOrDefault();
        private int GetEmptySlotsCount()
            => _slots.Where(x => x.SlotType == SlotType.Empty).Count();
        private int GetFilledSlotsCount()
            => _slots.Where(x => x.SlotType == SlotType.Filled).Count();
        private ModelSlot GetSlotById(int itemId)
            => _slots.Find(x => x.ItemId == itemId && x.SlotType == SlotType.Filled);
        private bool ContainsSlotWithId(int itemId)
            => _slots.Find(x => x.ItemId == itemId && x.SlotType == SlotType.Filled) != null ? true : false;

    }
}
