using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class KickBall : MonoBehaviour
{
    [SerializeField]
    private List<Transform> _ballTransforms;

    [SerializeField]
    private CircleCollider2D _kickRadiusCircleCollider;

    [SerializeField]
    private float _kickPower;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            foreach(var ballTransform in _ballTransforms)
            {
                Vector2 direction = ballTransform.position - transform.position;
                if (direction.magnitude / _kickRadiusCircleCollider.radius <= 1)
                {
                    ballTransform.GetComponent<Rigidbody2D>().AddForce(direction.normalized * _kickPower, ForceMode2D.Impulse);
                }
            }
        }
    }
}
