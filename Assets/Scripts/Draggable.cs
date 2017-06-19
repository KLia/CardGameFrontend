using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public Transform Parent;
    public Transform PlaceholderParent;

    private GameObject _placeholder;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!CanBeDragged())
        {
            return;
        }

        Parent = transform.parent;
        PlaceholderParent = transform.parent;

        _placeholder = new GameObject();
        _placeholder.transform.SetParent(PlaceholderParent);
        var le = _placeholder.AddComponent<LayoutElement>();
        le.preferredWidth = transform.GetComponent<LayoutElement>().preferredWidth;
        le.preferredHeight = transform.GetComponent<LayoutElement>().preferredHeight;
        le.flexibleWidth = 0;
        le.flexibleWidth = 0;

        le.transform.SetSiblingIndex(transform.GetSiblingIndex());

        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!CanBeDragged())
        {
            return;
        }

        transform.position = eventData.position;


        if (_placeholder.transform.parent != PlaceholderParent)
        {
            _placeholder.transform.SetParent(PlaceholderParent);
        }

        var siblingIndex = PlaceholderParent.transform.childCount;

        for (var i = 0; i < PlaceholderParent.childCount; ++i)
        {
            if (transform.position.x < PlaceholderParent.GetChild(i).position.x)
            {
                siblingIndex = i;

                if (_placeholder.transform.GetSiblingIndex() < siblingIndex)
                {
                    siblingIndex--;
                }

                break;
            }
        }

        _placeholder.transform.SetSiblingIndex(siblingIndex);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!CanBeDragged())
        {
            return;
        }

        transform.SetParent(Parent);
        transform.SetSiblingIndex(_placeholder.transform.GetSiblingIndex());

        Destroy(_placeholder);

        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }

    private bool CanBeDragged()
    {
        if (transform.parent.tag == "Unmoveable")
        {
            return false;
        }
        return true;
    }
}
