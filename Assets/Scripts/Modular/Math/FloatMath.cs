using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Float Arithmetic")]
    public class FloatMath : Attachment
    {
        private enum Operation {Add, Subtract, Multiply, Divide}
        
        [SerializeField] private FloatLink value1;
        [SerializeField] private Operation operation;
        [SerializeField] private FloatLink value2;

        public override string[] LinkedFloatNames => new[] { "Result" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
            {
                if (operation == Operation.Add)
                    return value1.FloatValue + value2.FloatValue;
                if (operation == Operation.Subtract)
                    return value1.FloatValue - value2.FloatValue;
                if (operation == Operation.Multiply)
                    return value1.FloatValue * value2.FloatValue;
                return value1.FloatValue / value2.FloatValue;
            }
            return base.LoadLinkedFloat(valueName);
        }
    }
}
