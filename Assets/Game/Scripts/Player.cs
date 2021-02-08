using System.Collections;
using UnityEngine;

namespace Game.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private GameObject laserPrefab;

        [SerializeField] private GameObject tripleShoot;

        [SerializeField] private GameObject explosionAnimation;

        [SerializeField] private GameObject shieldGameObject;

        [SerializeField] private bool tripleShootPoweredUp;

        [SerializeField] private bool speedBoostPoweredUp;

        [SerializeField] private bool shieldPoweredUp;
        
        [SerializeField] private float speed = 5.0f;

        // FireRate is 0.25f
        [SerializeField] private float fireRate = 0.25f;

        private float _nextFire = 0.0f;
        [SerializeField] private int _lifes;

        // canFire -- has the amount of time between firing passed?
        // Time.time


        // Start is called before the first frame update
        void Start()
        {
            _lifes = 3;
            //Take current position = new position
            transform.position = new Vector3(0, 0, 0)
        }

        // Update is called once per frame
        void Update()
        {
            Movement();

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                Shoot();
            }
        }

        private void Shoot()
        {
            if (Time.time > _nextFire)
            {
                if (tripleShootPoweredUp)
                {
                    Instantiate(tripleShoot, transform.position, Quaternion.identity);
                }
                else
                {
                    // Spawn Laser
                    Instantiate(laserPrefab, transform.position + new Vector3(0, 0.88f, 0), Quaternion.identity);
                }

                _nextFire = Time.time + fireRate;
            }
        }

        private void Movement()
        {
            var horizontalInput = Input.GetAxis("Horizontal");
            var verticalInput = Input.GetAxis("Vertical");
            var speedMultiplier = speedBoostPoweredUp ? 5 : 1;

            transform.Translate(Vector3.right * (speed * speedMultiplier * horizontalInput * Time.deltaTime));
            transform.Translate(Vector3.up * (speed * speedMultiplier * verticalInput * Time.deltaTime));


            if (transform.position.x > 8.3f)
            {
                transform.position = new Vector3(8.3f, transform.position.y, 0);
            }

            if (transform.position.x < -8.3f)
            {
                transform.position = new Vector3(-8.3f, transform.position.y, 0);
            }

            if (transform.position.y > 4.25f)
            {
                transform.position = new Vector3(transform.position.x, 4.25f, 0);
            }

            if (transform.position.y < -4.25f)
            {
                transform.position = new Vector3(transform.position.x, -4.25f, 0);
            }
        }


        /*
         * Power up On and starts Down coroutine.
         */
        public void TripleShootPowerUpOn()
        {
            tripleShootPoweredUp = true;
            StartCoroutine(TripleShootPowerDownRoutine());
        }


        /**
         * PowerDown routine after five seconds.
         */
        private IEnumerator TripleShootPowerDownRoutine()
        {
            yield return new WaitForSeconds(5.0f);
            tripleShootPoweredUp = false;
        }
        
        /*
         * Shiled powerup
         */
        public void ShieldPowerUpOn()
        {
            shieldPoweredUp = true;
            shieldGameObject.SetActive(true);
            StartCoroutine(ShieldPowerDownRoutine());
        }

        private IEnumerator ShieldPowerDownRoutine()
        {
            yield return new WaitForSeconds(10.0f);
            shieldPoweredUp = false;
            shieldGameObject.SetActive(false);
        }

        public void SpeedBoostPowerUpOn()
        {
            speedBoostPoweredUp = true;
            StartCoroutine(SpeedBoostPowerDownRoutine());
        }

        private IEnumerator SpeedBoostPowerDownRoutine()
        {
            yield return new WaitForSeconds(5.0f);
            speedBoostPoweredUp = false;
        }

        public void OnDamageReceived()
        {
            if (shieldPoweredUp)
            {
                shieldPoweredUp = false;
                shieldGameObject.SetActive(false);
            }
            else
            {
                _lifes--;
            }
            
            if (_lifes < 1)
            {
                Destroy(this.gameObject);
                Instantiate(explosionAnimation, transform.position, Quaternion.identity);
            }
        }
    }
}