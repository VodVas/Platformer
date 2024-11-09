using System.Collections.Generic;
using UnityEngine;

public class MoveBetweenPoints : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private float _speed = 5f;

    private int _currentPointIndex = 0;

    private void Start()
    {
        if (_points.Count > 0)
        {
            transform.position = _points[_currentPointIndex].position;
        }
    }

    private void Update()
    {
        if (_points.Count > 0)
        {
            MoveTarget();
            CheckArrival();
        }
    }

    private void MoveTarget()
    {
        Vector2 targetPoint = _points[_currentPointIndex].position;

        transform.position = Vector2.MoveTowards(transform.position, targetPoint, _speed * Time.deltaTime);
    }

    private void CheckArrival()
    {
        Vector2 targetPoint = _points[_currentPointIndex].position;

        if (Vector2.Distance(transform.position, targetPoint) < 0.1f)
        {
            ChangeScale();

            _currentPointIndex++;

            if (_currentPointIndex >= _points.Count)
            {
                _currentPointIndex = 0;
            }
        }
    }

    private void ChangeScale()
    {
        Vector3 currentScale = transform.localScale;

        transform.localScale = new Vector3(-currentScale.x, currentScale.y, currentScale.z);
    }
}