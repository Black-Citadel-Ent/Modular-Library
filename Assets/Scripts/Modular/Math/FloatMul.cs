using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Multiply Float")]
    public class FloatMul : Attachment
    {
        [SerializeField] private FloatLink value1;
        [SerializeField] private FloatLink value2;

        public override string[] LinkedFloatNames => new[] { "Result" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Result"))
                return value1.FloatValue * value2.FloatValue;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
