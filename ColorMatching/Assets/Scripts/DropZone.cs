using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropZone : MonoBehaviour, IDropHandler
{
    public Color slotColor; 

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedObject = eventData.pointerDrag;
        if (droppedObject != null)
        {
            Image droppedImage = droppedObject.GetComponent<Image>();

            if (droppedImage != null)
            {

                string droppedColorHex = ColorUtility.ToHtmlStringRGB(droppedImage.color);
                string slotColorHex = ColorUtility.ToHtmlStringRGB(slotColor);

                if (droppedColorHex == slotColorHex)
                {

                    droppedObject.transform.SetParent(transform);
                    droppedObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
                    Debug.Log("Correct Match!");
                }
                else
                {

                    Debug.Log("Wrong Slot!");
                    droppedObject.GetComponent<Draggable>().ResetPosition();
                }
            }
        }
    }
}
