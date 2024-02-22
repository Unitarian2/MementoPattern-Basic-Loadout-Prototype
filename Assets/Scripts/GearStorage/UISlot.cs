
using System;
using UnityEngine;
using UnityEngine.UI;

public class UISlot : MonoBehaviour
{
    public Image itemImage;
    GearStorage storage;
    MouseDrag mouseDrag;

    public void SetupStorage(GearStorage storage)
    {
        this.storage = storage;
    }

    public GearStorage GetStorage()
    {
        return storage;
    }

    public void UpdateUI(Item item)
    {
        if(item == null)
        {
            itemImage.sprite = null;
            return;
        }
        itemImage.sprite = item.sprite;
    }

    internal void SetupMouseDrag(GearStorage gearStorage)
    {
        mouseDrag = gameObject.GetOrAdd<MouseDrag>();
        mouseDrag.SetupStorage(storage, this);
    }
}
