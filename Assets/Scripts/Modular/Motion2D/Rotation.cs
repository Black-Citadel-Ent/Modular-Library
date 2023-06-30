using System;
using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Rotation")]
    public class Rotation : Attachment
    {
        [SerializeField] private Transform target;
        [SerializeField] private FloatLink angle;
        [SerializeField] private BoolLink allowLargeAngles;

        private Rigidbody2D _body;

        private void Start()
        {
            _body = target.gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_body)
                AdjustAngle(angle.FloatValue);
        }

        private void FixedUpdate()
        {
            if (_body)
                AdjustAngle(angle.FloatValue);
        }

        private void AdjustAngle(float value)
        {
            if (allowLargeAngles.BoolValue || (value >= -360.0f && value <= 360.0f))
            {
                var orig = target.localRotation.eulerAngles;
                if(_body)
                    _body.MoveRotation(value);
                else
                    target.localRotation = Quaternion.Euler(orig.x, orig.y, value);
            }
        }
    }
}
