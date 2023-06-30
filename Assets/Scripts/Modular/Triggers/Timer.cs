using UnityEngine;

namespace Modular.Triggers
{
    [AddComponentMenu("Modular/Triggers/Timer")]
    public class Timer : Attachment
    {
        [SerializeField] private FloatLink time;
        private bool _trigger;
        private float _time;

        public override string[] LinkedBoolNames => new[] { "Trigger" };

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals("Trigger"))
                return _trigger;
            return base.LoadLinkedBool(valueName);
        }

        private void Update()
        {
            _trigger = false;
            _time += Time.deltaTime;
            if (_time >= time.FloatValue)
            {
                _trigger = true;
                _time -= time.FloatValue;
            }
        }
    }
}
