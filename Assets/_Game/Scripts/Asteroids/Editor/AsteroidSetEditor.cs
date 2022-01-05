using UnityEditor;

namespace Asteroids
{
    [CustomEditor( typeof( AsteroidSet ) )]
    public class AsteroidSetEditor : Editor
    {
        AsteroidSet set;
        int _cachedNumber;

        private void OnEnable()
        {
            set = (AsteroidSet)target;
        }

        public override bool RequiresConstantRepaint()
        {
            int number = set.Number;
            bool needsRepaint = _cachedNumber != number;
            _cachedNumber = number;
            return needsRepaint;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField( $"Number of asteroids: {set.Number}" );
        }
    }
}