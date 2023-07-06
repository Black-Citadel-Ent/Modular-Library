using UnityEngine;

namespace Modular.Logic
{
    [AddComponentMenu("Modular/Logic/Boolean Comparison")]
    public class BooleanTest : Attachment
    {
        private enum Operation {And, Or, Xor}
        
        [SerializeField] private BoolLink value1;
        [SerializeField] private Operation operation;
        [SerializeField] private BoolLink value2;

        public override string[] LinkedBoolNames => new[] { "Result" };

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
            {
                if (operation == Operation.And)
                    return value1.BoolValue && value2.BoolValue;
                if (operation == Operation.Or)
                    return value1.BoolValue || value2.BoolValue;
                return value1.BoolValue ^ value2.BoolValue;
            }
            return base.LoadLinkedBool(valueName);
        }
    }
}
