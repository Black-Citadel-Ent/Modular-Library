using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Float")]
    public class FloatStorage : Attachment
    {
        [SerializeField] private float value;

        public override string[] LinkedFloatNames => new[] { "Value" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return value;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
