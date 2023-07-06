using System;
using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Rotation")]
    public class Rotation : Attachment
    {
        [SerializeField] private GameObject target;
        [SerializeField] private FloatLink angle;
        [SerializeField] private BoolLink allowLargeAngles;

        private Rigidbody2D _body;

        private void Start()
        {
            _body = target.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            var value = angle.FloatValue;
            if (allowLargeAngles.BoolValue || (value >= -360.0f && value <= 360.0f))
            {
                var orig = target.transform.localRotation.eulerAngles;
                if(_body)
                    _body.MoveRotation(value);
                else
                    target.transform.localRotation = Quaternion.Euler(orig.x, orig.y, value);
            }
        }
    }
}
