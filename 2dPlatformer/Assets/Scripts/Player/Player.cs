using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin)) 
        {
            coin.PickUp();
            _money += coin.Price;
        }
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;

        if (_health <= 0) 
        {
            gameObject.SetActive(false);
        }
    }
}