using UnityEngine;

namespace Modular.Animation
{
    [AddComponentMenu("Modular/Animation/Animation Finished")]
    public class AnimationFinished : Attachment
    {
        public override string[] LinkedBoolNames => new[] { "Trigger" };

        private bool _triggerReady;
        private bool _trigger;

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _trigger;
            return base.LoadLinkedBool(valueName);
        }

        private void Update()
        {
            _trigger = false;
            if (_triggerReady)
            {
                _trigger = true;
                _triggerReady = false;
            }
        }

        private void Finish()
        {
            _triggerReady = true;
        }
    }
}
