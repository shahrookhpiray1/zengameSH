using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public Sprite leftSprite;  // اسپرایت برای سمت چپ
    public Sprite rightSprite; // اسپرایت برای سمت راست

    private SpriteRenderer spriteRenderer;  // دسترسی به Sprite Renderer

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // گرفتن Sprite Renderer
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal");  // گرفتن ورودی حرکت به چپ و راست

        if (horizontal < 0)  // حرکت به سمت راست
        {
            spriteRenderer.sprite = rightSprite;  // تغییر اسپرایت به سمت راست
        }
        else if (horizontal > 0)  // حرکت به سمت چپ
        {
            spriteRenderer.sprite = leftSprite;  // تغییر اسپرایت به سمت چپ
        }
    }
}
