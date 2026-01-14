using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private PathController currentPath;

    private Vector3 _targetPosition;
    private int _currentWaypoint;

    private void Awake()
    {
        currentPath = GameObject.Find("Path1").GetComponent<PathController>();
    }

    private void OnEnable()
    {
        _targetPosition = currentPath.GetPosition(0);
        _currentWaypoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);

        float relativeDistance = (transform.position - _targetPosition).magnitude;
        if (relativeDistance <= 0.1f)
        {
            if (_currentWaypoint < currentPath.WayPoint.Length - 1)
            {
                _currentWaypoint++;
                _targetPosition = currentPath.GetPosition(_currentWaypoint);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }
    }
}
