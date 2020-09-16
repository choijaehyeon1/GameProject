using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class Inventory : IEnumerable<InventorySlot>
{

    public const int MaxSlotNum = 28;
    public const int MaxItemNum = 99;

    public delegate void SlotChanagedHandler(int index, int itemId, int num);
    public SlotChanagedHandler slotChanaged;

    List<InventorySlot> slots = new List<InventorySlot>();

    public bool AddItem(int id, int num)
    {
        int index = FindElementIndex(id);
        if (index == -1 && slots.Count < MaxSlotNum)
        {
            slots.Add(new InventorySlot(id, num));
            slotChanaged?.Invoke(slots.Count - 1, id, num);
            return true;
        }
        else if (index > -1 && slots[index].num + num <= MaxSlotNum)
        {
            slots[index].AddNum(num);
            slotChanaged?.Invoke(index, id, num);
            return true;
        }

        return false;
    }    

    public void RemoveItem(int id)
    {
        int index = FindElementIndex(id);
        if (index == -1)
            return;        

        slots.RemoveAt(index);
        slotChanaged?.Invoke(index, -1, 0);
    }

    public void SwapSlot(int indexA, int indexB)
    {
        var temp = slots[indexA];
        
        slots[indexA] = slots[indexB];
        slotChanaged?.Invoke(indexA, slots[indexB].id, slots[indexB].num);

        slots[indexB] = temp;
        slotChanaged?.Invoke(indexB, temp.id, temp.num);

    }    
    

    private int FindElementIndex(int itemId)
    {
        return slots.FindIndex(elements => elements.id == itemId);
    }

    public IEnumerator<InventorySlot> GetEnumerator()
    {
        return slots.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return slots.GetEnumerator();
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        // 1:80,5:5,2:4 ...
        for (int i = 0; i < slots.Count; i++)
        {
            stringBuilder.Append(slots[i].ToString());
            if (i < slots.Count - 1)
                stringBuilder.Append(',');
        }
        return stringBuilder.ToString();
    }

    public void Parse(string dataString)
    {
        slots.Clear();

        string[] slotStrings = dataString.Split(',');
        foreach (var item in slotStrings)
        {
            if (!InventorySlot.TryParse(item, out InventorySlot slot))
            {
                Debug.LogError("inventorySlot 파싱 실패\n" + item);
                continue;
            }
            slots.Add(slot);
        }
    }
}
