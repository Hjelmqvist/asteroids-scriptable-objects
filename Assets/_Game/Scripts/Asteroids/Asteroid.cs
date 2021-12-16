using UnityEngine;
using Random = UnityEngine.Random;

namespace Asteroids
{
    [RequireComponent( typeof( Rigidbody2D ) )]
    public class Asteroid : MonoBehaviour
    {
        [Header( "Config:" )]
        [SerializeField] private float _minForce;
        [SerializeField] private float _maxForce;
        [SerializeField] private float _minSize;
        [SerializeField] private float _maxSize;
        [SerializeField] private float _minTorque;
        [SerializeField] private float _maxTorque;

        [Header( "References:" )]
        [SerializeField] private Transform _shape;
        [SerializeField] private ScriptableIntEvent _onAsteroidHit;
        [SerializeField] private AsteroidSet _asteroidSet;

        private Rigidbody2D _rigidbody;
        private Vector3 _direction;
        private int _instanceID;

        public float Size => _shape.localScale.magnitude;

        private void Awake()
        {
            _instanceID = GetInstanceID();
            _rigidbody = GetComponent<Rigidbody2D>();

            SetDirection();
            AddForce();
            AddTorque();
            SetSize();
        }

        private void HitByLaser()
        {
            _onAsteroidHit.Invoke( _instanceID );
            Destroy( gameObject );
        }

        private void SetDirection()
        {
            var size = new Vector2( 3f, 3f );
            var target = new Vector3
            (
                Random.Range( -size.x, size.x ),
                Random.Range( -size.y, size.y )
            );

            _direction = (target - transform.position).normalized;
        }

        private void AddForce()
        {
            var force = Random.Range( _minForce, _maxForce );
            _rigidbody.AddForce( _direction * force, ForceMode2D.Impulse );
        }

        private void AddTorque()
        {
            var torque = Random.Range( _minTorque, _maxTorque );
            var roll = Random.Range( 0, 2 );

            if (roll == 0)
                torque = -torque;

            _rigidbody.AddTorque( torque, ForceMode2D.Impulse );
        }

        private void SetSize()
        {
            var size = Random.Range( _minSize, _maxSize );
            _shape.localScale = new Vector3( size, size, 0f );
        }

        public Asteroid SetSize(float size)
        {
            _shape.localScale = new Vector3( size, size, 0f );
            return this;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag( "Laser" ))
            {
                HitByLaser();
            }
        }

        private void OnEnable()
        {
            _asteroidSet.Add( _instanceID, this );
        }

        private void OnDisable()
        {
            _asteroidSet.Remove( _instanceID );
        }
    }
}
