using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearStorage : MonoBehaviour
{
    [Tooltip("True is Swap yapýlamaz.")]
    [SerializeField] public bool staticStorage;

    [SerializeField] protected List<UISlot> slots = new List<UISlot>();
    [SerializeField] protected List<Item> items = new List<Item>();

    UISlot swapUISlot;

    private void Start()
    {
        for (int i = 0; i < slots.Count; i++)
        {
            slots[i].UpdateUI(items[i]);
            slots[i].SetupStorage(this);
            slots[i].SetupMouseDrag(this);
        }
    }

    public void ClearSwap()
    {
        swapUISlot = null;
    }

    public void SwapItem(UISlot slot)
    {
        if(swapUISlot == null)//Henüz bir þeyi yeni sürüklemeye baþlamýþýz.
        {
            swapUISlot = slot;
        }
        else if (swapUISlot == slot)//Ayný slot'a býrakmýþ olabiliriz.
        {
            swapUISlot = null;
        }      
        else//Swap iþlemini burada yapýyoruz.
        {
            GearStorage storage1 = swapUISlot.GetStorage();
            int index1 = storage1.GetItemIndex(swapUISlot);
            Item item1 = storage1.GetItem(index1);

            GearStorage storage2 = slot.GetStorage();
            int index2 = storage2.GetItemIndex(slot);
            Item item2 = storage2.GetItem(index2);

            if(item1.type == item2.type)
            {
                if (!storage1.staticStorage)
                {
                    //1. elemanýn olduðu index'e 2. elemaný yazýyoruz.
                    storage1.SetItemSlot(index1, item2);
                    swapUISlot.UpdateUI(item2);
                }
                if (!storage2.staticStorage)
                {
                    //2. elemanýn olduðu index'e 1. elemaný yazýyoruz.
                    storage2.SetItemSlot(index2, item1);
                    slot.UpdateUI(item1);
                }

                swapUISlot = null;
            }
            else
            {
                //Kendi tipinde bir slot'a býrakýlmamýþ.
                swapUISlot = null;
            }

        }
    }

    int GetItemIndex(UISlot slot) => slots.IndexOf(slot);
    Item GetItem(int index) => items[index];
    void SetItemSlot(int index, Item item) => items[index] = item;
}
