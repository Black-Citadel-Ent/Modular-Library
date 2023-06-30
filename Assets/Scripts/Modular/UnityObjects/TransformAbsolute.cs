using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Transform")]
    public class TransformAbsolute : Attachment
    {
        public override string[] LinkedVector3Names => new[]
        {
            "position", "rotation", "scale"
        };

        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals("position"))
                return transform.position;
            if (valueName.Equals("rotation"))
                return transform.rotation.eulerAngles;
            if (valueName.Equals("scale"))
                return transform.lossyScale;
            return base.LoadLinkedVector3(valueName);
        }
    }
}
