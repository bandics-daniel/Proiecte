using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minX = -5f;
    public float maxX = 5f;

    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        float move = moveInput * moveSpeed * Time.deltaTime;

        // deplasare și limitare pe X
        Vector3 newPos = transform.position;
        newPos.x = Mathf.Clamp(newPos.x + move, minX, maxX);
        transform.position = newPos;

        // întoarcere stânga/dreapta
        if (moveInput > 0)
            spriteRenderer.flipX = false;
        else if (moveInput < 0)
            spriteRenderer.flipX = true;

        // actualizează animația
        if (animator != null)
            animator.SetFloat("Speed", Mathf.Abs(moveInput));
    }
}
