using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Vector3 originalScale;
    private float targetZScale;

    [Header("Forward Pop Settings")]
    [Tooltip("How much the button thickens/moves forward on the Z axis")]
    [SerializeField] private float zMultiplier = 1.5f; 
    [SerializeField] private float animationSpeed = 12f;

    void Awake() 
    {
        originalScale = transform.localScale;
        targetZScale = originalScale.z;
    }

    void Update()
    {
        // Calculate the new Z scale based on the target
        float newZ = Mathf.Lerp(transform.localScale.z, targetZScale, Time.deltaTime * animationSpeed);
        
        // Apply only the Z change, keeping X and Y identical to originalScale
        transform.localScale = new Vector3(originalScale.x, originalScale.y, newZ);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Increase only the depth/forward thickness
        targetZScale = originalScale.z * zMultiplier;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Return to original depth
        targetZScale = originalScale.z;
    }

    void OnDisable()
    {
        transform.localScale = originalScale;
        targetZScale = originalScale.z;
    }
}