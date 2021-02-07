using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * (_speed * Time.deltaTime));
    }

    /*
     * Triggers Triple shoot on `other` object.
     */
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Access the player
            Player player = other.GetComponent<Player>();

            //Verify if `player` isn't a null object.
            if (player != null)
            {
                // Turn the triple shoot to true
                player.TripleShootPowerUpOn();
            }

            // Destroy ourselves.
            Destroy(gameObject);
        }
    }
}