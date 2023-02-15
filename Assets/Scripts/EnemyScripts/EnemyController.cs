using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [SerializeField] private float _velocity;
    private Rigidbody2D _rb2d;

    private void Start()
    {
        _rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rb2d.velocity = Vector2.left * _velocity;
    }
}
