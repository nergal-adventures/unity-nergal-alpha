using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Speed
    [SerializeField] private float _speed = 5.0f;

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
}