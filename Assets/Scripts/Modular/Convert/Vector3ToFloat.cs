using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Vector3 -> Float")]
    public class Vector3ToFloat : Attachment
    {
        [SerializeField] private Vector3Link input;
        
        public override string[] LinkedFloatNames => new[]
        {
            "x", "y", "z"
        };
        
        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return input.Vector3Value.x;
            if (valueName.Equals(LinkedFloatNames[1]))
                return input.Vector3Value.y;
            if (valueName.Equals(LinkedFloatNames[2]))
                return input.Vector3Value.z;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
