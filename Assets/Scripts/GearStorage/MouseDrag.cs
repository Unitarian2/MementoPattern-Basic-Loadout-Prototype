using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MouseDrag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    GearStorage storage;
    UISlot slot;
    GameObject dragInstance;

    public void SetupStorage(GearStorage storage,UISlot slot)
    {
        this.storage = storage;
        this.slot = slot;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        storage.SwapItem(slot);

        dragInstance = new GameObject("Drag "+ slot.name);
        var image = dragInstance.AddComponent<Image>();

        image.sprite = slot.itemImage.sprite;
        image.raycastTarget = false;

        dragInstance.transform.SetParent(storage.transform.parent.transform);
        dragInstance.transform.localScale = Vector3.one;

    }

    public void OnDrag(PointerEventData eventData)
    {
        if(dragInstance != null)
        {
            dragInstance.transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if(eventData.pointerCurrentRaycast.gameObject is GameObject targetObj)
        {
            var targetSlot = targetObj.GetComponentInParent<UISlot>();
            if (targetSlot != null)
            {
                storage.SwapItem(targetSlot);
                EventSystem.current.SetSelectedGameObject(targetObj);
            }
        }

        storage.ClearSwap();

        if (dragInstance != null)
        {
            Destroy(dragInstance);
        }
        
    }

    
}
