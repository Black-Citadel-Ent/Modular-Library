using System;
using UnityEngine;

namespace Modular.UnityObjects
{
    public class FixedTime : Attachment
    {
        public override string[] LinkedFloatNames => new[] { "Time" };

        private float _fixedTime;

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return _fixedTime;
            return base.LoadLinkedFloat(valueName);
        }

        private void Start()
        {
            _fixedTime = Time.fixedDeltaTime;
        }
    }
}
