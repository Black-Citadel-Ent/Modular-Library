using UnityEngine;

namespace Modular.Storage
{
    [AddComponentMenu("Modular/Storage/Float Random")]
    public class RandomFloat : Attachment
    {
        [SerializeField] private FloatLink lowValue;
        [SerializeField] private FloatLink highValue;
        
        public override string[] LinkedFloatNames => new[] { "Value" };

        private float _value;
        
        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return _value;
            return base.LoadLinkedFloat(valueName);
        }

        private void Start()
        {
            _value = UnityEngine.Random.Range(lowValue.FloatValue, highValue.FloatValue);
        }
    }
}
