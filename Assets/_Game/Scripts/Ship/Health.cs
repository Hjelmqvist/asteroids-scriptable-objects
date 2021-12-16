using UnityEngine;

namespace Ship
{
    public class Health : MonoBehaviour
    {
        [SerializeField] IntVariable _health;

        private const int MIN_HEALTH = 0;

        public void TakeDamage(int damage)
        {
            Debug.Log( "Took some damage" );
            _health.ApplyChange( Mathf.Max( MIN_HEALTH, _health.Value - damage ) );
        }
    }
}
