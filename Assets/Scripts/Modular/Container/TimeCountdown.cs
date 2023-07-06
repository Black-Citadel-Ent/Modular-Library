using System;
using UnityEngine;

namespace Modular.Container
{
    [AddComponentMenu("Modular/Timers/Time Countdown")]
    public class TimeCountdown : Attachment
    {
        [SerializeField] private FloatLink time;
        [SerializeField] private BoolLink reset;
        [SerializeField] private BoolLink cancel;

        private float _time;
        
        public override string[] LinkedFloatNames => new[] { "Time" };

        public override float LoadLinkedFloat(string valueName)
        {
            if(valueName.Equals(LinkedFloatNames[0]))
                return _time;
            return base.LoadLinkedFloat(valueName);
        }

        private void Update()
        {
            _time = Mathf.Max(_time - Time.deltaTime, 0);
            if (cancel.BoolValue)
                _time = 0;
            if (reset.BoolValue)
                _time = time.FloatValue;
        }
    }
}
