using UnityEngine;

public class CameraZoomOnly : MonoBehaviour
{
    public float zoomSpeed = 0.05f;
    public float minZoom = 3f;
    public float maxZoom = 10f;

    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);

            Vector2 t1Prev = t1.position - t1.deltaPosition;
            Vector2 t2Prev = t2.position - t2.deltaPosition;

            float prevMagnitude = (t1Prev - t2Prev).magnitude;
            float currentMagnitude = (t1.position - t2.position).magnitude;

            float difference = currentMagnitude - prevMagnitude;

            cam.orthographicSize -= difference * zoomSpeed;
            cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, minZoom, maxZoom);
        }
    }
}
