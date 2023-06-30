using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Vector2 -> Float")]
    public class Vector2ToFloat : Attachment
    {
        [SerializeField] private Vector2 input;
        
        public override string[] LinkedFloatNames => new[]
        {
            "x", "y"
        };
        
        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("x"))
                return input.x;
            if (valueName.Equals("y"))
                return input.y;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
