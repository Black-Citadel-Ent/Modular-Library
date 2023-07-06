using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Transform")]
    public class TransformAbsolute : Attachment
    {
        [SerializeField] private Transform target;
        
        public override string[] LinkedVector3Names => new[]
        {
            "position", "rotation", "scale"
        };

        public override Vector3 LoadLinkedVector3(string valueName)
        {
            if (valueName.Equals(LinkedVector3Names[0]))
                return target.position;
            if (valueName.Equals(LinkedVector3Names[1]))
                return target.rotation.eulerAngles;
            if (valueName.Equals(LinkedVector3Names[2]))
                return target.lossyScale;
            return base.LoadLinkedVector3(valueName);
        }
    }
}
