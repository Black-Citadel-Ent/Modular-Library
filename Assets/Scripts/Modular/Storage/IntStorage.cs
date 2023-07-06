using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Int")]
    public class IntStorage : Attachment
    {
        [SerializeField] private int value;

        public override string[] LinkedIntNames => new[] { "Value" };

        public override int LoadLinkedInt(string valueName)
        {
            if (valueName.Equals(LinkedIntNames[0]))
                return value;
            return base.LoadLinkedInt(valueName);
        }
    }
}
