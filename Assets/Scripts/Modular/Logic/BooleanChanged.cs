using System;
using UnityEngine;

namespace Modular.Logic
{
    [AddComponentMenu("Modular/Triggers/Boolean Changed")]
    public class BooleanChanged : Attachment
    {
        [SerializeField] private BoolLink value;

        public override string[] LinkedBoolNames => new[] { "Trigger" };

        private bool _value;
        private bool _changed;

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _changed;
            return base.LoadLinkedBool(valueName);
        }

        private void Update()
        {
            _changed = false;
            if (_value != value.BoolValue)
            {
                _changed = true;
                _value = value.BoolValue;
            }
        }
    }
}
