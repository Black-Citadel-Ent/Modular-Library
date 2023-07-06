using System;
using UnityEngine;

namespace Modular.Physics2D
{
    [AddComponentMenu("Modular/2D Physics/Trigger Enter")]
    public class TriggerEnter : Attachment
    {
        [SerializeField] private LayerMask layer;
        public override string[] LinkedBoolNames => new[] { "Trigger" };

        private bool _trigger;
        private bool _prevFrame;

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _trigger;
            return base.LoadLinkedBool(valueName);
        }

        private void Update()
        {
            if (_prevFrame)
            {
                _trigger = false;
                _prevFrame = false;
            }

            if (_trigger)
                _prevFrame = true;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (((1 << other.gameObject.layer) & layer.value) != 0)
                _trigger = true;
        }
    }
}
