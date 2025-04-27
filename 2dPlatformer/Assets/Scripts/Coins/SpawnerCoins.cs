using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private int _maxCountCoin;
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _intervalOfSpawn;
    [SerializeField] private Transform[] _spawnAreas;    

    private List<Coin> _coinsPool = new List<Coin>();
    private float _spawntimeNewCoin;

    private void OnEnable()
    {
        for (int i = 0; i < _maxCountCoin; i++)
        {
            Coin coin = Instantiate(_prefab);
            coin.CoinMatched += PlaceCoinInPool;
            coin.gameObject.SetActive(false);
            _coinsPool.Add(coin);
        }

        _spawntimeNewCoin = Time.time + _intervalOfSpawn;
    }

    private void Update()
    {
        if (Time.time >= _spawntimeNewCoin && _coinsPool.Count > 0) 
        {
            _spawntimeNewCoin = Time.time + _intervalOfSpawn;

            RemoveCoinOfPool(_coinsPool[Random.Range(0, _coinsPool.Count)], _spawnAreas[Random.Range(0, _spawnAreas.Length)].transform);
        }
    }

    public void PlaceCoinInPool(Coin coin) 
    {
        _coinsPool.Add(coin);
        coin.CoinMatched += PlaceCoinInPool;
        coin.gameObject.SetActive(false);
    }

    private void RemoveCoinOfPool(Coin removedCoin, Transform spawnArea) 
    {
        removedCoin.CoinMatched += PlaceCoinInPool;
        removedCoin.transform.position = new Vector3(Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2), spawnArea.position.y);
        removedCoin.gameObject.SetActive(true);
        _coinsPool.Remove(removedCoin);
    }
}
