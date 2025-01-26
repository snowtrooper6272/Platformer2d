using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public event UnityAction<Coin> CoinMatched;
    [SerializeField] private int _price;

    public int Price => _price;

    public void PickUp() 
    {
        CoinMatched.Invoke(this);
    }
}
