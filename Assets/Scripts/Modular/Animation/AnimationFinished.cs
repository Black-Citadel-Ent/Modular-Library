using UnityEngine;

namespace Modular.Animation
{
    [AddComponentMenu("Modular/Animation/Animation Finished")]
    public class AnimationFinished : Attachment
    {
        public override string[] LinkedBoolNames => new[] { "Trigger" };
        
        private bool _trigger;

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals("Trigger"))
                return _trigger;
            return base.LoadLinkedBool(valueName);
        }

        private void Finish()
        {
            _trigger = true;
        }
    }
}
