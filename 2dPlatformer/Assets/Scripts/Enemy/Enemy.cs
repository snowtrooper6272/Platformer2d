using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Player target))
            target.TakeDamage(_damage);
    }
}
