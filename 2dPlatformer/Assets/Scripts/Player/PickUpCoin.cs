using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCoin : MonoBehaviour
{
    [SerializeField] private int _money;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Coin coin))
        {
            coin.PickUp();
            _money += coin.Price;
        }
    }
}
