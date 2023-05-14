using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    Inventory inven;

    public Slot[] slots;
    public Transform slotHolder;

    void Start()
    {
        inven = Inventory.instance;
        slots = slotHolder.GetComponentsInChildren<Slot>();

        inven.onSlotCountChange += SlotChange;
        
    }

    private void SlotChange(int val)
    {
        for(int i=0; i<slots.Length; ++i)
        {
            if (i < inven.SlotCnt)
                slots[i].GetComponent<Button>().interactable = true;
            else
                slots[i].GetComponent<Button>().interactable = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSlot()
    {
        inven.SlotCnt++;
    }
}
