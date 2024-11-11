using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private float _respawnDelay = 5f;
    [SerializeField] private Coin _coinPrefab;
    [SerializeField] private List<Transform> _coinTransforms;
    [SerializeField] private ItemCollector _itemCollector;

    private ObjectPool<Coin> _coinPool;
    private List<Vector2> _coinPositions = new List<Vector2>();
    private WaitForSeconds _wait;

    private void Awake()
    {
        _coinPool = new ObjectPool<Coin>(Create, OnGetFromPool, OnReleaseToPool, OnDestroyPoolObject, true);

        Init();

        _wait = new WaitForSeconds(_respawnDelay);

        if (_itemCollector != null)
        {
            _itemCollector.CoinCollect += OnCoinCollected;
        }
    }

    private void OnDisable()
    {
        _coinPool.Clear();

        if (_itemCollector != null)
        {
            _itemCollector.CoinCollect -= OnCoinCollected;
        }
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
        return Instantiate(_coinPrefab);
    }

    private void OnGetFromPool(Coin coin)
    {
        coin.gameObject.SetActive(true);
    }

    private void OnReleaseToPool(Coin coin)
    {
        coin.gameObject.SetActive(false);
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

        int index = _coinPositions.IndexOf(coin.transform.position);

        if (index != -1)
        {
            StartCoroutine(RespawnCoinAfterDelay(index));
        }
    }

    private IEnumerator RespawnCoinAfterDelay(int index)
    {
        yield return _wait;

        Spawn(_coinPositions[index]);
    }

    private void Spawn(Vector2 position)
    {
        Coin coin = _coinPool.Get();
        coin.transform.position = position;
    }
}