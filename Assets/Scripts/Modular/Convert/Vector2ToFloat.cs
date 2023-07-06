using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Vector2 -> Float")]
    public class Vector2ToFloat : Attachment
    {
        [SerializeField] private Vector2Link input;
        
        public override string[] LinkedFloatNames => new[]
        {
            "x", "y", "distance", "negative x", "negative y"
        };
        
        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return input.Vector2Value.x;
            if (valueName.Equals(LinkedFloatNames[1]))
                return input.Vector2Value.y;
            if (valueName.Equals(LinkedFloatNames[2]))
                return input.Vector2Value.magnitude;
            if (valueName.Equals(LinkedFloatNames[3]))
                return -1 * input.Vector2Value.x;
            if (valueName.Equals(LinkedFloatNames[4]))
                return -1 * input.Vector2Value.y;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
