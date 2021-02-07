using UnityEngine;

namespace Game.Scripts
{
    public class Laser : MonoBehaviour
    {
        // Start is called before the first frame update

        [SerializeField] private float _speed = 10.0f;

        // Update is called once per frame
        void Update()
        {
            // Move up at 10 speed.
            transform.Translate(Vector3.up * _speed * Time.deltaTime);

            // if position.y > 6 => Destroy the laser
            if (transform.position.y > 6)
            {
                Destroy(gameObject);
            }
        }
    }
}