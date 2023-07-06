using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Angular Velocity")]
    public class AngularVelocity : Attachment
    {
        [SerializeField] private GameObject target;
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
                var current = target.transform.localRotation.eulerAngles;
                var newZ = current.z + velocity.FloatValue * Time.deltaTime;
                target.transform.localRotation = Quaternion.Euler(current.x, current.y, newZ);
            }
            else
                _body.angularVelocity = velocity.FloatValue;
        }
    }
}
