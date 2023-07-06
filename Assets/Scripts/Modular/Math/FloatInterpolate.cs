using UnityEngine;

namespace Modular.Math
{
    [AddComponentMenu("Modular/Math/Float Linear Interpolation")]
    public class FloatInterpolate : Attachment
    {
        [SerializeField] private FloatLink startTime;
        [SerializeField] private FloatLink endTime;
        [SerializeField] private FloatLink startValue;
        [SerializeField] private FloatLink endValue;
        [SerializeField] private FloatLink time;

        public override string[] LinkedFloatNames => new[] { "Value" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return time.FloatValue.Lerp(startTime.FloatValue, endTime.FloatValue, startValue.FloatValue,
                    endValue.FloatValue);
            return base.LoadLinkedFloat(valueName);
        }
    }
}