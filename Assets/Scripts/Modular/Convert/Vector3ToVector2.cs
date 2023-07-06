using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Vector3 -> Vector2")]
    public class Vector3ToVector2 : Attachment
    {
        public override string[] LinkedVector2Names => new[] { "2D Vector" };

        [SerializeField] private Vector3Link original;

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return new Vector2(original.Vector3Value.x, original.Vector3Value.y);
            return base.LoadLinkedVector2(valueName);
        }
    }
}
