using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Float Comparison")]
    public class FloatCompare : Attachment
    {
        private enum Compare {Minimum, Maximum}
        
        [SerializeField] private Compare comparison;
        [SerializeField] private FloatLink value1;
        [SerializeField] private FloatLink value2;

        public override string[] LinkedFloatNames => new[] { "Value" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return comparison == Compare.Minimum
                    ? Mathf.Min(value1.FloatValue, value2.FloatValue)
                    : Mathf.Max(value1.FloatValue, value2.FloatValue);
            return base.LoadLinkedFloat(valueName);
        }
    }
}
