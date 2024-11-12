using UnityEngine;

[RequireComponent(typeof(MoveBetweenPoints))]
[RequireComponent(typeof(DetectCircle))]
[RequireComponent(typeof(HuntCircle))]
public class EnemyAI : MonoBehaviour
{
    [SerializeField] private float _chaseSpeed = 4f;
    [SerializeField] private float _offsetToPlayer = 2f;
    [SerializeField] private DetectCircle _detectCircle;
    [SerializeField] private HuntCircle _huntCircle;

    private MoveBetweenPoints _patrolMovement;
    private Transform _player;
    private bool _isChasing = false;

    private void Awake()
    {
        _patrolMovement = GetComponent<MoveBetweenPoints>();
    }

    private void Update()
    {
        if (_isChasing && _player != null)
        {
            ChasePlayer();
        }
    }

    private void OnEnable()
    {
        _detectCircle.TriggerEnterEvent += SetPlayer;
        _huntCircle.TriggerExitEvent += ClearPlayer;
    }

    private void OnDisable()
    {
        _detectCircle.TriggerEnterEvent -= SetPlayer;
        _huntCircle.TriggerExitEvent -= ClearPlayer;
    }

    public void SetPlayer(Transform player)
    {
        if (!_isChasing)
        {
            _player = player;
            _isChasing = true;
            _patrolMovement.enabled = false;
        }
    }

    public void ClearPlayer()
    {
        _player = null;
        _isChasing = false;
        _patrolMovement.enabled = true;
    }

    private void ChasePlayer()
    {
        Vector2 targetPosition = _player.position - (_player.position - transform.position).normalized * _offsetToPlayer;

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, _chaseSpeed * Time.deltaTime);
    }
}