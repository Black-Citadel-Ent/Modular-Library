using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Vector3")]
    public class Vector3Storage : Attachment
    {
        [SerializeField] private Vector3 value;

        public override string[] LinkedVector3Names => new[] { "Value" };

        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals(LinkedVector3Names[0]))
                return value;
            return base.LoadLinkedVector3(valueName);
        }
    }
}