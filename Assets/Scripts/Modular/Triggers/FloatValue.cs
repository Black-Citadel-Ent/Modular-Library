using UnityEngine;

namespace Modular.Triggers
{
    [AddComponentMenu("Modular/Triggers/Value Of Float")]
    public class FloatValue : Attachment
    {
        private enum TriggerType { HigherThan, LowerThan }
        
        [SerializeField] private FloatLink value;
        [SerializeField] private FloatLink limit;
        [SerializeField] private TriggerType side;
        
        private bool _trigger;

        public override string[] LinkedBoolNames => new[] { "Trigger" };

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals("Trigger"))
                return side == TriggerType.HigherThan
                    ? value.FloatValue > limit.FloatValue
                    : value.FloatValue < limit.FloatValue;
            return base.LoadLinkedBool(valueName);
        }
    }
}
