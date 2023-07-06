using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Acceleration")]
    public class Acceleration : Attachment
    {
        [SerializeField] private Vector2Link acceleration;
        [SerializeField] private BoolLink reset;
        
        public override string[] LinkedVector2Names => new[] { "Velocity" };

        private Vector2 _velocity;

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return _velocity;
            return base.LoadLinkedVector2(valueName);
        }

        private void Update()
        {
            if(reset.BoolValue)
                _velocity = Vector2.zero;
            else
                _velocity += acceleration.Vector2Value * Time.deltaTime;
        }
    }
}
