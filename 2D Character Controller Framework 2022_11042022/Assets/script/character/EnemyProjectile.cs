using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [Header("PROJECTILE:")]
    public int damage = 1;
    public float projectileSpeed = 2f;
    public bool flipSprite = true;
    public float cleanupDelay = 8f;
    public LayerMask _collisionLayers;
    [Header("EFFECTS:")]
    public GameObject vfx;
    public AudioSource sfx;

    private Rigidbody2D _rb;
    private SpriteRenderer _sprite;
    private CircleCollider2D circCol;
    private PlayerHealth _playerHealth;
    private PlayerMovement _playerMovement;

    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        circCol = GetComponent<CircleCollider2D>();
        _playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        _playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Start()
    {
        // Makes sure that the sprite is facing the correct way, by checking the velocity of its RigidBody2D component.
        if (_rb.velocity.x < 0f && flipSprite)
            _sprite.flipX = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        // Check to make sure that the projectile isn't hitting the player, 
        // and if not, call the DestroyProjectile function below.
        if (col.CompareTag("Player") && circCol.IsTouchingLayers(_collisionLayers))
        {
            _playerMovement.KnockBack(transform);
            _playerHealth.LooseHealth(damage);
            DestroyProjectile();
        }
    }

    public void DestroyProjectile()
    {
        if (vfx != null)
            Instantiate(vfx, transform.position, Quaternion.identity);
        if (sfx != null)
            Instantiate(sfx, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }

    IEnumerator DestroyDelay()
    {
        // This co-routine waits for a set amount of time before destroying the projectile
        // so that we don't end up with millions of projectiles in the scene.
        yield return new WaitForSeconds(cleanupDelay);
        Destroy(gameObject);
    }
}