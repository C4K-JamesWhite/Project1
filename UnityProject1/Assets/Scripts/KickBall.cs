using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KickBall : MonoBehaviour
{
    [SerializeField]
    private Transform _ballTransform;

    [SerializeField]
    private CircleCollider2D _kickRadiusCircleCollider;

    [SerializeField]
    private float _kickPower;

    private Rigidbody2D _rigidBody;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Vector2 direction = _ballTransform.position - transform.position;
            if (direction.magnitude / _kickRadiusCircleCollider.radius <= 1) {
                _ballTransform.GetComponent<Rigidbody2D>().AddForce(direction.normalized * _kickPower, ForceMode2D.Impulse);
            }
        }
    }
}
