using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PowerUpSurprise : MonoBehaviour
{
    [SerializeField]
    private Vector2 _intitialVelocity;
    [SerializeField]
    private float _reenableColliderAfter;

    private Rigidbody2D _rigidbody;
    private Collider2D _collider;
   
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _collider = GetComponent<Collider2D>();
        _collider.enabled = false;
        _rigidbody.velocity = _intitialVelocity;
        StartCoroutine(ReenableCollider());
    }
    private IEnumerator ReenableCollider()
    {
        yield return new WaitForSeconds(_reenableColliderAfter);
        _collider.enabled = true;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        var player = other.collider.GetComponent<PlayerMovements>();
        if (player != null)
        {
            Destroy(gameObject);
            //player.DoSomeSpecialAction e.g player.EnableShooting
        }
    }
}
