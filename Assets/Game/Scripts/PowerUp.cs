using System;
using System.Collections;
using System.Collections.Generic;
using Game.Scripts;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private float _speed = 3.0f;

    [SerializeField] private int _powerUpId; // 0 => Triple_shoot; 1 => Speed_boost; 2 => Shield. 

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
                if (_powerUpId == 0)
                {
                    // Turn the triple shoot to true
                    player.TripleShootPowerUpOn();
                }
                else if (_powerUpId == 1)
                {
                    player.SpeedBoostPowerUpOn();
                }
                else
                {
                    // player.ShieldPowerUpOn();
                }
            }

            // Destroy ourselves.
            Destroy(gameObject);
        }
    }
}