using System;
using UnityEngine;

namespace Modular
{
    public class Attachment : MonoBehaviour
    {
        [SerializeField] private string attachmentName;

        public virtual string AttachmentName => attachmentName;

        public virtual string[] LinkedBoolNames => new string[] { };
        public virtual string[] LinkedIntNames => new string[] { };
        public virtual string[] LinkedFloatNames => new string[] { };
        public virtual string[] LinkedVector2Names => new string[] { };
        public virtual string[] LinkedVector3Names => new string[] { };

        public virtual bool LoadLinkedBool(string valueName) { throw new Exception($"bool {valueName} not found in object {name}"); }
        public virtual int LoadLinkedInt(string valueName) { throw new Exception($"int {valueName} not found in object {name}"); }
        public virtual float LoadLinkedFloat(string valueName) { throw new Exception($"string {valueName} not found in object {name}"); }
        public virtual Vector2 LoadLinkedVector2(string valueName) { throw new Exception($"Vector2 {valueName} not found in object {name}"); }
        public virtual Vector3 LoadLinkedVector3(string valueName) { throw new Exception($"Vector3 {valueName} not found in object {name}"); }
    }
}
