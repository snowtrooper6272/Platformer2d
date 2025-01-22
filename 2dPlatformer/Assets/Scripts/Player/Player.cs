using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private int _money;
    [SerializeField] private int _health;
    public UnityAction<Coin> CoinMatched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin)) 
        {
            CoinMatched.Invoke(coin);
            _money++;
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