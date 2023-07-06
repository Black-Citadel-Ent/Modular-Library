using UnityEngine;

namespace Modular.Physics2D
{
    [AddComponentMenu("Modular/2D Physics/Read Rigidbody Velocity")]
    public class RigidBodyVelocity : Attachment
    {
        public override string[] LinkedVector2Names => new[] { "velocity" };

        private Rigidbody2D _body;

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if(valueName.Equals(LinkedVector2Names[0]))
                return _body ? _body.velocity: Vector2.zero;
            return base.LoadLinkedVector2(valueName);
        }

        private void Start()
        {
            _body = gameObject.GetComponent<Rigidbody2D>();
        }
    }
}
