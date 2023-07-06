using UnityEngine;

namespace Modular.Physics2D
{
    [AddComponentMenu("Modular/2D Physics/Raycast")]
    public class Raycast : Attachment
    {
        [SerializeField] private Vector2Link origin;
        [SerializeField] private Vector2Link direction;
        [SerializeField] private LayerMask layers;
        [SerializeField] private FloatLink distance;

        private RaycastHit2D _lasthit;

        public override string[] LinkedFloatNames => new[] { "Distance" };
        public override string[] LinkedBoolNames => new[] { "Hit" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
            {
                if (!_lasthit || !_lasthit.collider)
                    return float.PositiveInfinity;
                return _lasthit.distance;
            }

            return base.LoadLinkedFloat(valueName);
        }

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _lasthit && _lasthit.collider;
            return base.LoadLinkedBool(valueName);
        }


        private void FixedUpdate()
        {
            _lasthit = UnityEngine.Physics2D.Raycast(origin.Vector2Value, direction.Vector2Value, distance.FloatValue, layers);
        }
    }
}
