using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Bool")]
    public class BoolStorage : Attachment
    {
        [SerializeField] private bool value;

        public override string[] LinkedBoolNames => new[] { "Value" };

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return value;
            return base.LoadLinkedBool(valueName);
        }
    }
}
