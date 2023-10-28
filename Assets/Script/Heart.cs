using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private float _healValue;    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Health health))
        {
            health.Restore(_healValue);
        }

        Destroy(gameObject);
    }
}
