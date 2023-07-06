using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Vector2")]
    public class Vector2Storage : Attachment
    {
        [SerializeField] private Vector2 value;

        public override string[] LinkedVector2Names => new[] { "Value" };

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return value;
            return base.LoadLinkedVector2(valueName);
        }
    }
}