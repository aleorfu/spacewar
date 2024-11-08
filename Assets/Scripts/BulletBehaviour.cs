using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    public float bulletSpeed;

    private void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector3.up);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
