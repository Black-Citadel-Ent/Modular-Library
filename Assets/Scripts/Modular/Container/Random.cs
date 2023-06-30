using UnityEngine;

namespace Modular.Container
{
    [AddComponentMenu("Modular/Containers/Random")]
    public class Random : Attachment
    {
        [SerializeField] private FloatLink lowValue;
        [SerializeField] private FloatLink highValue;
        private float _value;
        
        public override string[] LinkedFloatNames => new[] { "Value" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Value"))
                return _value;
            return base.LoadLinkedFloat(valueName);
        }

        private void Start()
        {
            _value = UnityEngine.Random.Range(lowValue.FloatValue, highValue.FloatValue);
        }
    }
}
