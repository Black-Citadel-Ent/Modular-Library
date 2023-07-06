using UnityEngine;

namespace Modular.Logic
{
    [AddComponentMenu("Modular/Logic/Invert Boolean")]
    public class NotBoolean : Attachment
    {
        [SerializeField] private BoolLink value;

        public override string[] LinkedBoolNames => new[] { "Value" };
        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return !value.BoolValue;
            return base.LoadLinkedBool(valueName);
        }
    }
}
