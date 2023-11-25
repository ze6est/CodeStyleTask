using UnityEngine;

public class WaipointMovement : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private float _speed;

    private Transform[] _points;
    private int _currentPoint;
    private Transform _target;

    private void Awake()
    {
        int pointsCount = _path.childCount;

        _points = new Transform[pointsCount];

        for (int i = 0; i < pointsCount; i++)
            _points[i] = _path.GetChild(i);
    }

    private void Start()
    {
        SetTarget();
        SetDirectionMovement();
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);

        if (transform.position == _target.position)
            MoveToNextTarget();        
    }
    private void MoveToNextTarget()
    {
        _currentPoint++;        

        if (_currentPoint == _points.Length)
            _currentPoint = 0;

        SetTarget();
        SetDirectionMovement();
    }

    private void SetDirectionMovement() => 
        transform.forward = (_target.position - transform.position).normalized;

    private void SetTarget() => 
        _target = _points[_currentPoint];
}