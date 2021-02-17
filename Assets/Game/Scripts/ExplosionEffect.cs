using UnityEngine;

namespace Game.Scripts
{
    public class ExplosionEffect : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
        Destroy(this.gameObject, 4f);
        }

        // Update is called once per frame
  
    }
}
