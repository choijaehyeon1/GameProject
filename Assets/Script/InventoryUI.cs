using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.IO.Pipes;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Transform parent;
    public Image image;
    public delegate void SlotSwappedHandler(int indexA, int indexB);
    public SlotSwappedHandler slotSwapped;

    private void Start()
    {
        var inventory = GameManager.Instance.Data.Inventory;
        inventory.slotChanaged += UpdateSlot;
        slotSwapped += inventory.SwapSlot;

        UpdateInventory();
    }

    private void OnDestroy()
    {
        var inventory = GameManager.Instance?.Data.Inventory;
        if (inventory != null)
            inventory.slotChanaged -= UpdateSlot;
    }

    void UpdateInventory()
    {
        var inventory = GameManager.Instance.Data.Inventory;

        foreach (var slot in inventory)
        {

        }
    }

    void UpdateSlot(int index, int itemId, int num)
    {

    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.SetParent(transform.parent.parent.parent);
        image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = parent.position;
        transform.SetParent(parent);
        image.raycastTarget = true;
    }
}

