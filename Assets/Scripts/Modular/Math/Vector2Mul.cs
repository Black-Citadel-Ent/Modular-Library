using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Multiply Vector2")]
    public class Vector2Mul : Attachment
    {
        [SerializeField] private Vector2Link vector;
        [SerializeField] private FloatLink multiplier;

        public override string[] LinkedVector2Names => new[] { "Result" };

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return vector.Vector2Value * multiplier.FloatValue;
            return base.LoadLinkedVector2(valueName);
        }
    }
}
