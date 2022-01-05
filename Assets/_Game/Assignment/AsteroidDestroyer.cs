using UnityEngine;

namespace Asteroids
{

    public class AsteroidDestroyer : MonoBehaviour
    {
        [SerializeField] AsteroidSet _asteroidSet;
        [SerializeField] Asteroid _asteroidPrefab;

        [Header("Splitting")]
        [SerializeField, Tooltip( "The minimum size an asteroid has to be to split" )] float _splitMinSize = 1f;
        [SerializeField, Tooltip( "How many parts to split into" )] int _splitNumber = 4;
        [SerializeField, Range(0, 1)] float _splitSizeMultiplier = 0.25f;

        public void OnAsteroidHit(int key)
        {
            if (_asteroidSet.TryFind( key, out Asteroid asteroid ))
            {
                SplitAsteroid( asteroid );
                Destroy( asteroid.gameObject );
            }
        }

        private void SplitAsteroid(Asteroid asteroid)
        {
            float size = asteroid.Size;
            if (size >= _splitMinSize)
            {
                for (int i = 0; i < _splitNumber; i++)
                {
                    var newAsteroid = Instantiate( _asteroidPrefab, asteroid.transform.position, Quaternion.identity );
                    newAsteroid.SetSize( size * _splitSizeMultiplier );
                }
            }
        }
    }
}