using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    [SerializeField] private float hoverMultiplier = 1.1f; // 10% increase

    void Awake() 
    {
        // Awake runs before Start, making sure we grab the scale 
        // before any other logic touches it.
        originalScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // This keeps the X, Y, and Z proportions perfectly consistent
        transform.localScale = originalScale * hoverMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Snaps back to exactly how it looks in your Scene view
        transform.localScale = originalScale;
    }
}