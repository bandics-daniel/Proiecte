using UnityEngine;

public class HoverHighlight : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    public Color highlightColor = Color.yellow;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
    }

    void OnMouseEnter()
    {
        spriteRenderer.color = highlightColor;
    }

    void OnMouseExit()
    {
        spriteRenderer.color = originalColor;
    }
}
