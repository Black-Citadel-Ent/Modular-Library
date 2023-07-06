using UnityEngine;

namespace Modular.Triggers
{
    [AddComponentMenu("Modular/Triggers/Value Of Float")]
    public class FloatValue : Attachment
    {
        private enum TriggerType { Higher, Lower, Equal, HigherOrEqual, LowerOrEqual }
        
        [SerializeField] private FloatLink value;
        [SerializeField] private FloatLink limit;
        [SerializeField] private TriggerType side;
        
        private bool _trigger;

        public override string[] LinkedBoolNames => new[] { "Trigger" };

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
            {
                var eq = (value.FloatValue - limit.FloatValue).NearZero();
                if (side == TriggerType.Equal)
                    return eq;
                if (side == TriggerType.Higher)
                    return !eq && value.FloatValue > limit.FloatValue;
                if (side == TriggerType.Lower)
                    return !eq && value.FloatValue < limit.FloatValue;
                if (side == TriggerType.HigherOrEqual)
                    return eq || value.FloatValue > limit.FloatValue;
                return eq || value.FloatValue < limit.FloatValue;
            }
            return base.LoadLinkedBool(valueName);
        }
    }
}
