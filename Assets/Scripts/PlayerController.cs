using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float rotationSpeed = 1.0f;

    void Update()
    {
        float hValue = Input.GetAxis("Horizontal");
        float vValue = Input.GetAxis("Vertical");

        Vector2 pos = new(0, vValue);
        Vector3 rot = new(0, 0, -hValue);

        transform.Rotate(rotationSpeed * Time.deltaTime * rot);
        transform.Translate(moveSpeed * Time.deltaTime * pos);
    }
}
