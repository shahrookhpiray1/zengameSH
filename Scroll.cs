using UnityEngine;

public class Scroll : MonoBehaviour
{
    public Transform player;
    public float parallaxSpeed = 0.5f;
    private Transform[] backgrounds;
    private float backgroundWidth;
    private Vector3 lastPlayerPos;

    void Start()
    {
        backgrounds = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        backgroundWidth = backgrounds[0].GetComponent<SpriteRenderer>().bounds.size.x;
        lastPlayerPos = player.position;
    }

    void LateUpdate()
    {
        float deltaX = player.position.x - lastPlayerPos.x;
        transform.position += Vector3.right * deltaX * parallaxSpeed;
        lastPlayerPos = player.position;

        foreach (Transform bg in backgrounds)
        {
            // اگه از سمت راست خارج شد، بنداز سمت راست‌ترین تصویر
            if (bg.position.x <= player.position.x - backgroundWidth)
            {
                float rightMostX = GetRightMostX();
                bg.position = new Vector3(rightMostX + backgroundWidth, bg.position.y, bg.position.z);
            }

            // اگه از سمت چپ خارج شد، بنداز سمت چپ‌ترین تصویر
            else if (bg.position.x >= player.position.x + backgroundWidth)
            {
                float leftMostX = GetLeftMostX();
                bg.position = new Vector3(leftMostX - backgroundWidth, bg.position.y, bg.position.z);
            }
        }
        Vector3 pos = transform.position;
        pos.x = Mathf.Round(pos.x * 100f) / 100f;
        transform.position = pos;

    }

    float GetRightMostX()
    {
        float maxX = backgrounds[0].position.x;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > maxX)
                maxX = bg.position.x;
        }
        return maxX;
    }

    float GetLeftMostX()
    {
        float minX = backgrounds[0].position.x;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x < minX)
                minX = bg.position.x;
        }
        return minX;
    }
}
