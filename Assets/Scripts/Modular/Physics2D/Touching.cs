using UnityEngine;

namespace Modular.Physics2D
{
    [AddComponentMenu("Modular/2D Physics/Touching Object")]
    public class Touching : Attachment
    {
        public override string[] LinkedBoolNames => new[] { "Touching" };

        [SerializeField] private LayerMask layer;
        
        private bool _touching;
        private bool _frameTouch;

        public override bool LoadLinkedBool(string valueName)
        {
            if (valueName.Equals(LinkedBoolNames[0]))
                return _touching;
            return base.LoadLinkedBool(valueName);
        }

        private void FixedUpdate()
        {
            _touching = _frameTouch;
            _frameTouch = false;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (((1 << other.collider.gameObject.layer) & layer) != 0)
                _frameTouch = true;
        }

        private void OnCollisionStay2D(Collision2D other)
        {
            if (((1 << other.collider.gameObject.layer) & layer) != 0)
                _frameTouch = true;
        }
    }
}
