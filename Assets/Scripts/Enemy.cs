using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private PathController currentPath;

    [SerializeField] private Vector3 _targetPosition;
    [SerializeField] private int _currentWaypoint;
    [SerializeField] private Animator _animator;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Rigidbody2D rb;
    private Vector2 currentMovementInput;
    private void Start()
    {
    }

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        currentPath = GameObject.Find("Path1").GetComponent<PathController>();
    }

    private void OnEnable()
    {
        _targetPosition = currentPath.GetPosition(0);
        _currentWaypoint = 0;
    }

    private void FixedUpdate()
    {
        // Tính toán hướng từ vị trí HIỆN TẠI tới ĐIỂM ĐẾN
        Vector2 direction = ((Vector2)_targetPosition - (Vector2)transform.position).normalized;

        // Áp dụng vận tốc
        rb.linearVelocity = direction * moveSpeed;
    }

    void Update()
    {
        float moveX = rb.linearVelocityX;
        float moveY = rb.linearVelocityY;

        // cap nhat tham so cho cay
        _animator.SetFloat("MoveX", moveX);
        _animator.SetFloat("MoveY", moveY);

        if(moveX != 0)
        {
            _spriteRenderer.flipX = (moveX > 0);
        }

        //transform.position = Vector3.MoveTowards(transform.position, _targetPosition, moveSpeed * Time.deltaTime);

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
                _currentWaypoint = 0;
                _targetPosition = currentPath.GetPosition(_currentWaypoint);
            }
        }
    }
}
