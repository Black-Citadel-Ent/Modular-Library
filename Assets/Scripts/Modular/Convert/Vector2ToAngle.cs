using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Vector2 -> Angle")]
    public class Vector2ToAngle : Attachment
    {
        [SerializeField] private Vector2Link vector;

        public override string[] LinkedFloatNames => new[] { "Angle" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Angle"))
                return Translate(vector.Vector2Value);
            return base.LoadLinkedFloat(valueName);
        }

        private float Translate(Vector2 value)
        {
            if (value.magnitude.NearZero())
                return -500;
            var norm = value.normalized;
            return Mathf.Atan2(norm.y, norm.x) * Mathf.Rad2Deg;
        }
    }
}
