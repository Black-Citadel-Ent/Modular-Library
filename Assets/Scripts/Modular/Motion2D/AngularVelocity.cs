using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Angular Velocity")]
    public class AngularVelocity : Attachment
    {
        [SerializeField] private Transform target;
        [SerializeField] private FloatLink velocity;
        private Rigidbody2D _body;

        private void Start()
        {
            _body = target.gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_body)
            {
                var current = target.localRotation.eulerAngles;
                var newZ = current.z + velocity.FloatValue * Time.deltaTime;
                target.localRotation = Quaternion.Euler(current.x, current.y, newZ);
            }
        }

        private void FixedUpdate()
        {
            if (_body)
                _body.angularVelocity = velocity.FloatValue;
        }
    }
}
