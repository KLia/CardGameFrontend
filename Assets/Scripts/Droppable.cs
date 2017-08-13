using Cards;
using UnityEngine;
using UnityEngine.EventSystems;

public class Droppable : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    private static Draggable GetDraggable(PointerEventData eventData)
    {
        return eventData.pointerDrag.GetComponent<Draggable>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        var d = GetDraggable(eventData);

        if (d != null)
        {
            d.PlaceholderParent = transform;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null)
        {
            return;
        }

        var d = GetDraggable(eventData);

        if (d != null && d.PlaceholderParent == transform)
        {
            d.PlaceholderParent = d.Parent;
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        var d = GetDraggable(eventData);

        if (d != null)
        {
            d.Parent = transform;
            d.GetComponent<CardInfo>().OnPlay();
        }
    }
}