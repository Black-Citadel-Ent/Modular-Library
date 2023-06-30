using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Float -> Vector2")]
    public class FloatToVector2 : Attachment
    {
        [SerializeField] private FloatLink x;
        [SerializeField] private FloatLink y;

        public override string[] LinkedVector2Names => new string[] { "Vector2" };

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals("Vector2"))
                return new Vector2(x.FloatValue, y.FloatValue);
            return base.LoadLinkedVector2(valueName);
        }
    }
}
