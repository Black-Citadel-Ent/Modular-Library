using UnityEngine;

namespace Modular.Convert
{
    [AddComponentMenu("Modular/Convert/Angle -> Vector2")]
    public class AngleToVector2 : Attachment
    {
        [SerializeField] private FloatLink angle;

        public override string[] LinkedVector2Names => new[] { "Result" };

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return Calculate(angle.FloatValue);
            return base.LoadLinkedVector2(valueName);
        }

        private Vector2 Calculate(float val)
        {
            var aRad = val * Mathf.Deg2Rad;
            return new Vector2(Mathf.Cos(aRad), Mathf.Sin(aRad));
        }
    }
}
