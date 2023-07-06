using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Transform Local")]
    public class TransformLocal : Attachment
    {
        [SerializeField] private Transform target;
        
        public override string[] LinkedVector3Names => new[]
        {
            "position", "rotation", "scale"
        };
        
        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals(LinkedVector3Names[0]))
                return target.localPosition;
            if (valueName.Equals(LinkedVector3Names[1]))
                return target.localRotation.eulerAngles;
            if (valueName.Equals(LinkedVector3Names[2]))
                return target.localScale;
            return base.LoadLinkedVector3(valueName);
        }
    }
}
