using System;
using UnityEngine;

namespace Modular
{
    public interface ILinkedBool
    {
        public bool BoolValue { get; }
    }

    public interface ILinkedInt
    {
        public int IntValue { get; }
    }

    public interface ILinkedFloat
    {
        public float FloatValue { get; }
    }
    
    public interface ILinkedVector2
    {
        public Vector2 Vector2Value { get; }
    }

    public interface ILinkedVector3
    {
        public Vector3 Vector3Value { get; }
    }

    [Serializable]
    public class LinkBase
    {
        [SerializeField] protected bool useHardValue;
        [SerializeField] protected GameObject linkedObject;
        [SerializeField] protected string attachmentName;
        [SerializeField] protected string valueName;

        protected Attachment LinkedAttachment;
        
        protected void FindAttachment()
        {
            var attachments = linkedObject.GetComponents<Attachment>();
            foreach (var a in attachments)
                if (a.AttachmentName.Equals(attachmentName))
                    LinkedAttachment = a;
            if (!LinkedAttachment)
                throw new Exception($"Attachment {attachmentName} not found in object {linkedObject.name}");

        }
    }

    [Serializable]
    public class BoolLink : LinkBase, ILinkedBool
    {
        [SerializeField] private bool constantValue;

        public bool BoolValue
        {
            get
            {
                if (useHardValue) return constantValue;
                if (!LinkedAttachment) FindAttachment();
                return LinkedAttachment.LoadLinkedBool(valueName);
            }
        }
    }

    [Serializable]
    public class IntLink : LinkBase, ILinkedInt
    {
        [SerializeField] private int constantValue;

        public int IntValue
        {
            get
            {
                if (useHardValue) return constantValue;
                if (!LinkedAttachment) FindAttachment();
                return LinkedAttachment.LoadLinkedInt(valueName);
            }
        }
    }
    
    [Serializable]
    public class FloatLink : LinkBase, ILinkedFloat
    {
        [SerializeField] private float constantValue;

        public float FloatValue
        {
            get
            {
                if (useHardValue) return constantValue;
                if (!LinkedAttachment) FindAttachment();
                return LinkedAttachment.LoadLinkedFloat(valueName);
            }
        }
    }

    [Serializable]
    public class Vector2Link : LinkBase, ILinkedVector2
    {
        [SerializeField] private Vector2 constantValue;

        public Vector2 Vector2Value
        {
            get
            {
                if (useHardValue) return constantValue;
                if (!LinkedAttachment) FindAttachment();
                return LinkedAttachment.LoadLinkedVector2(valueName);
            }
        }
    }
    
    [Serializable]
    public class Vector3Link : LinkBase, ILinkedVector3
    {
        [SerializeField] private Vector3 constantValue;

        public Vector3 Vector3Value
        {
            get
            {
                if (useHardValue) return constantValue;
                if (!LinkedAttachment) FindAttachment();
                return LinkedAttachment.LoadLinkedVector3(valueName);
            }
        }
    }
}
