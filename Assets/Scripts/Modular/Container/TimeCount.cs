using System;
using UnityEngine;

namespace Modular.Container
{
    [AddComponentMenu("Modular/Timers/Time Counter")]
    public class TimeCount : Attachment
    {
        [SerializeField] private BoolLink reset;

        public override string[] LinkedFloatNames => new[] { "Time" };

        private float _time;

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return _time;
            return base.LoadLinkedFloat(valueName);
        }

        private void Update()
        {
            _time += Time.deltaTime;
            if (reset.BoolValue)
                _time = 0;
        }
    }
}
