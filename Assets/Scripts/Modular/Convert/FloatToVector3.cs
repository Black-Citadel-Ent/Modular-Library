using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Float -> Vector3")]
    public class FloatToVector3 : Attachment
    {
        [SerializeField] private FloatLink x;
        [SerializeField] private FloatLink y;
        [SerializeField] private FloatLink z;

        public override string[] LinkedVector3Names => new string[] { "Vector3" };

        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals("Vector3"))
                return new Vector3(x.FloatValue, y.FloatValue, z.FloatValue);
            return base.LoadLinkedVector3(valueName);
        }
    }
}
