using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    public float minX; // کمترین مقدار X دوربین
    public float maxX; // بیشترین مقدار X دوربین

    void LateUpdate()
    {
        float targetX = Mathf.Clamp(player.position.x + offset.x, minX, maxX);
        Vector3 desiredPosition = new Vector3(targetX, transform.position.y, transform.position.z);
        Vector3 smoothed = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothed;
    }
}
