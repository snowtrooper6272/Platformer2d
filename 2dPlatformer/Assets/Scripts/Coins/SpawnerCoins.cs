using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private int _maxCountCoin;
    [SerializeField] private Coin _prefab;
    [SerializeField] private Player _player;
    [SerializeField] private float _intervalOfSpawn;
    [SerializeField] private GameObject[] _spawnAreas;    

    private List<Coin> _coinsPool = new List<Coin>();
    private float _currentTimeSpawn;

    private void OnEnable()
    {
        for (int i = 0; i < _maxCountCoin; i++)
        {
            Coin coin = Instantiate(_prefab);
            coin.CoinMatched += PlaceCoinInPool;
            coin.gameObject.SetActive(false);

            _coinsPool.Add(coin);
        }
    }

    private void OnDisable()
    {
        for (int i = 0; i < _coinsPool.Count; i++)
        {
            _coinsPool[i].CoinMatched -= PlaceCoinInPool;
        }
    }

    private void Update()
    {
        if (_currentTimeSpawn >= _intervalOfSpawn && _coinsPool.Count > 0) 
        {
            _currentTimeSpawn = 0;

            RemoveCoinOfPool(_coinsPool[Random.Range(0, _coinsPool.Count)], _spawnAreas[Random.Range(0, _spawnAreas.Length)].transform);
        }

        _currentTimeSpawn += Time.deltaTime;
    }

    public void PlaceCoinInPool(Coin coin) 
    {
        _coinsPool.Add(coin);
        coin.gameObject.SetActive(false);
    }

    public void RemoveCoinOfPool(Coin removeCoin, Transform spawnArea) 
    {
        removeCoin.transform.position = new Vector3(Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2), spawnArea.position.y);
        removeCoin.gameObject.SetActive(true);
        _coinsPool.Remove(removeCoin);
    }
}
