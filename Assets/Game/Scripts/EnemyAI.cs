using System;
using Game.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyAI : MonoBehaviour
{
    //Speed
    [SerializeField] private float _speed = 5.0f;

    [SerializeField] private GameObject _explodeAnimation;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //Move Down
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));

        // When off the screen on the bottom
        if (transform.position.y < -7.0f)
        {
            // respawn back on top with a nex x positions between bounds of the screen.
            var randomX = Random.Range(-9.0f, 9.0f);
            transform.position = new Vector3(randomX, 7.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Coalition vs `Player`
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();

            if (player != null)
                player.OnDamageReceived();
            OnDestroy();
        }
        // Coalition vs `Laser` 
        else if (other.CompareTag("Laser"))
        {
            var laser = other.GetComponent<Laser>();
            if (laser != null)
                laser.OnDestroy();
            OnDestroy();
        }
    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
        Instantiate(_explodeAnimation, transform.position, Quaternion.identity);
    }
}