using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition; // Store original position

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition; // Save the initial position
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Make it slightly transparent when dragging
        canvasGroup.blocksRaycasts = false; // Allow raycasts to pass through
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta; // Move object with mouse/touch
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f; // Restore transparency
        canvasGroup.blocksRaycasts = true; // Block raycasts again

        // If not placed in a correct slot, return to original position
        if (transform.parent == null || transform.parent.GetComponent<DropZone>() == null)
        {
            rectTransform.anchoredPosition = originalPosition;
        }
    }

    public void ResetPosition() // Call this when match is incorrect
    {
        rectTransform.anchoredPosition = originalPosition;
    }
}
