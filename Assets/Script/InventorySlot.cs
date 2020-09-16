using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct InventorySlot
{
    public int id;
    public int num;

    public InventorySlot(int id, int num)
    {
        this.id = id;
        this.num = num;
    }

    public void AddNum(int add)
    {
        num += add;
    }

    public override string ToString()
    {        
        // id = 1, num = 80 -> 1:80
        return string.Format("{0}:{1}", id, num);
    }

    public static bool TryParse(string str, out InventorySlot slot)
    {
        slot = new InventorySlot();
        string[] strings = str.Split(':');
        if (!int.TryParse(strings[0], out slot.id))
            return false;
        if (!int.TryParse(strings[1], out slot.num))
            return false;
        return true;
    }
}
