using UnityEngine;

namespace Modular.Logic
{
    [AddComponentMenu("Modular/Logic/Float If")]
    public class SelectFloat : Attachment
    {
        [SerializeField] private BoolLink condition;
        [SerializeField] private FloatLink trueValue;
        [SerializeField] private FloatLink falseValue;

        public override string[] LinkedFloatNames => new[] { "Result" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return condition.BoolValue ? trueValue.FloatValue : falseValue.FloatValue;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
