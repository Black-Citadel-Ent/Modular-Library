using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Transform Local")]
    public class TransformLocal : Attachment
    {
        public override string[] LinkedVector3Names => new[]
        {
            "position", "rotation", "scale"
        };
        
        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals("position"))
                return transform.localPosition;
            if (valueName.Equals("rotation"))
                return transform.localRotation.eulerAngles;
            if (valueName.Equals("scale"))
                return transform.localScale;
            return base.LoadLinkedVector3(valueName);
        }
    }
}
