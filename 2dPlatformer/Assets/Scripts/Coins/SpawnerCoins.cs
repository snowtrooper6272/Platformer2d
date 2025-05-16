using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerCoins : MonoBehaviour
{
    [SerializeField] private int _maxCountCoin;
    [SerializeField] private Coin _prefab;
    [SerializeField] private float _spawnDelay;
    [SerializeField] private Transform[] _spawnAreas;    

    private List<Coin> _coinsPool = new List<Coin>();

    private void OnEnable()
    {
        for (int i = 0; i < _maxCountCoin; i++)
        {
            Coin coin = Instantiate(_prefab);
            coin.gameObject.SetActive(false);
            _coinsPool.Add(coin);
        }

        StartCoroutine(CoinSpawn());
    }

    private void OnDisable()
    {
        StopCoroutine(CoinSpawn());
    }

    private IEnumerator CoinSpawn() 
    {
        bool isNeedGenerate = true;
        WaitForSeconds delay = new WaitForSeconds(_spawnDelay);

        while (isNeedGenerate) 
        {
            if(_coinsPool.Count > 0)
                RemoveCoinOfPool(_coinsPool[Random.Range(0, _coinsPool.Count)], _spawnAreas[Random.Range(0, _spawnAreas.Length)].transform);

            yield return delay;
        }
    }

    public void PlaceCoinInPool(Coin coin) 
    {
        _coinsPool.Add(coin);
        coin.Matched -= PlaceCoinInPool;
        coin.gameObject.SetActive(false);
    }

    private void RemoveCoinOfPool(Coin removedCoin, Transform spawnArea) 
    {
        removedCoin.Matched += PlaceCoinInPool;
        removedCoin.transform.position = new Vector3(Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2, spawnArea.position.x + spawnArea.localScale.x / 2), spawnArea.position.y);
        removedCoin.gameObject.SetActive(true);
        _coinsPool.Remove(removedCoin);
    }
}
