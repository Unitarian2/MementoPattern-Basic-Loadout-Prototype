using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearStorage : MonoBehaviour
{
    [Tooltip("True is Swap yap�lamaz.")]
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
        if(swapUISlot == null)//Hen�z bir �eyi yeni s�r�klemeye ba�lam���z.
        {
            swapUISlot = slot;
        }
        else if (swapUISlot == slot)//Ayn� slot'a b�rakm�� olabiliriz.
        {
            swapUISlot = null;
        }      
        else//Swap i�lemini burada yap�yoruz.
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
                    //1. eleman�n oldu�u index'e 2. eleman� yaz�yoruz.
                    storage1.SetItemSlot(index1, item2);
                    swapUISlot.UpdateUI(item2);
                }
                if (!storage2.staticStorage)
                {
                    //2. eleman�n oldu�u index'e 1. eleman� yaz�yoruz.
                    storage2.SetItemSlot(index2, item1);
                    slot.UpdateUI(item1);
                }

                swapUISlot = null;
            }
            else
            {
                //Kendi tipinde bir slot'a b�rak�lmam��.
                swapUISlot = null;
            }

        }
    }

    int GetItemIndex(UISlot slot) => slots.IndexOf(slot);
    Item GetItem(int index) => items[index];
    void SetItemSlot(int index, Item item) => items[index] = item;
}
