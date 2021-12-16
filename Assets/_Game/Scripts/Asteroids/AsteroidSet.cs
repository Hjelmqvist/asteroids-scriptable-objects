using System.Collections.Generic;
using UnityEngine;

namespace Asteroids
{
    [CreateAssetMenu( fileName = "New AsteroidSet", menuName = "ScriptableObjects/AsteroidSet" )]
    public class AsteroidSet : ScriptableObject
    {
        Dictionary<int, Asteroid> _asteroids = new Dictionary<int, Asteroid>();

        public void Add(int key, Asteroid asteroid)
        {
            _asteroids.Add( key, asteroid );
        }

        public bool TryFind(int key, out Asteroid asteroid)
        {
            if (_asteroids.ContainsKey( key ))
            {
                asteroid = _asteroids[key];
                return true;
            }
            asteroid = null;
            return false;
        }

        public void Remove(int key)
        {
            if (_asteroids.ContainsKey( key ))
                _asteroids.Remove( key );
        }
    }
}