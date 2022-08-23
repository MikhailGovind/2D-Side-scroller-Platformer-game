using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{

    #region PUBLIC FIELDS:
    [Header("INITIALIZATIONS:")]
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    [Header("PROJECTILE:")]
    public float range = 5f;
    public LayerMask playerMask;
    public float projectileFireRate = 0.5f;
    #endregion

    #region PRIVATE:
    private GameObject _player;
    public SpriteRenderer _renderer;
    private float _projectileSpeed = 1;
    private bool _canShoot = true;
    private bool _playerInRange;

    #endregion

    void Awake()
    {
        _player = GameObject.Find("Player");
        _renderer = GetComponentInChildren<SpriteRenderer>();
        _playerInRange = false;

        // Just some reminders for us in case we forget to assign a projectile or spawn point.
        if (projectileSpawnPoint == null)
            Debug.Log("ERROR: You need to assign a transform for your projectiles to spawn at!");

        if (projectilePrefab == null)
            Debug.Log("ERROR: You need to assign a projectile prefab!");
        else
            _projectileSpeed = projectilePrefab.GetComponent<EnemyProjectile>().projectileSpeed;
    }

    void Start()
    {
            StartCoroutine(ProjectileDelay());
    }

    void Update()
    {
        if (_renderer.isVisible)
        {
            _playerInRange = Physics2D.Raycast(transform.position,
                                                _player.transform.position - transform.position,
                                                range,
                                                playerMask);
            
            
            if (_playerInRange && _canShoot)
            {
                Debug.DrawRay(transform.position, _player.transform.position - transform.position, Color.red);
                Shoot();
                StartCoroutine(ProjectileDelay());
            }
                
        }
    }

    void Shoot()
    {
         // If we're facing right:
        if (transform.position.x < projectileSpawnPoint.position.x && transform.position.x < _player.transform.position.x)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = transform.TransformDirection(Vector3.right * _projectileSpeed);
        }
        //if we're facing left:
        else if (transform.position.x > projectileSpawnPoint.position.x && transform.position.x > _player.transform.position.x)
        {
            GameObject projectile = Instantiate(projectilePrefab, projectileSpawnPoint.position, Quaternion.identity);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
            rb.velocity = transform.TransformDirection(Vector3.left * _projectileSpeed);
        }
    }

    // This co-routine determines how often the player is able to shoot a projectile.
    IEnumerator ProjectileDelay()
    {
        _canShoot = false;
        yield return new WaitForSeconds(projectileFireRate);
        _canShoot = true;
    }
}


