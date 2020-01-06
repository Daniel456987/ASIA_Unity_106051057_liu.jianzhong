using UnityEngine;

public class camera_ctr : MonoBehaviour
{
    public Transform cam, target;

    public float speed = 3;
    public float r_speed = 100;

    private void Update()
    {
        Vector3 pos = Vector3.Lerp(cam.position, target.position, 0.5f * Time.deltaTime * speed);

        cam.position = pos;
        float h = Input.GetAxis("Horizontal");
        cam.Rotate(0, h * r_speed * Time.deltaTime, 0);
    }
}
