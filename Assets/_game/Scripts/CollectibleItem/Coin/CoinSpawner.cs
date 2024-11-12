using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _respawnDelay = 5f;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _coinTransforms;

    private ObjectPool<Coin> _coinPool;
    private List<Vector2> _coinPositions = new List<Vector2>();
    private WaitForSeconds _wait;

    private void Awake()
    {
        _coinPool = new ObjectPool<Coin>(Create, OnGetFromPool, OnReleaseToPool, OnDestroyPoolObject, true);

        Init();

        _wait = new WaitForSeconds(_respawnDelay);
    }

    private void OnDisable()
    {
        _coinPool.Clear();
    }

    private void Init()
    {
        foreach (var transform in _coinTransforms)
        {
            _coinPositions.Add(transform.position);
        }

        foreach (var position in _coinPositions)
        {
            Spawn(position);
        }
    }

    private Coin Create()
    {
        Coin coin = Instantiate(_coinPrefab);
        return coin;
    }

    private void OnGetFromPool(Coin coin)
    {
        coin.gameObject.SetActive(true);
        coin.CoinCollected += OnCoinCollected;
    }

    private void OnReleaseToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
        coin.CoinCollected -= OnCoinCollected;
    }

    private void OnDestroyPoolObject(Coin coin)
    {
        if (coin != null)
        {
            Destroy(coin.gameObject);
        }
    }

    private void OnCoinCollected(Coin coin)
    {
        _coinPool.Release(coin);

        StartCoroutine(RespawnCoinAfterDelay(coin));
    }

    private IEnumerator RespawnCoinAfterDelay(Coin coin)
    {
        yield return _wait;

        Vector2 position = coin.transform.position;

        Spawn(position);
    }

    private void Spawn(Vector2 position)
    {
        Coin coin = _coinPool.Get();
        coin.transform.position = position;
    }
}