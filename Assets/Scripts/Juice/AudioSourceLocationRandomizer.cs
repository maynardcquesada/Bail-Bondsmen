using UnityEngine;

namespace Juice
{
    public class AudioSourceLocationRandomizer : MonoBehaviour
    {
        // Start is called before the first frame update
        private void Start()
        {
            RandomizePosition();
        }

        private void RandomizePosition()
        {
            transform.position = new Vector3(Random.Range(-12, 12), 0, Random.Range(-12, 12));
            InvokeRepeating(nameof(RandomizePosition), 66.6f, 66.6f);
        }
    }
}