using UnityEngine;

namespace Modular.Motion2D
{
    [AddComponentMenu("Modular/2D Motion/Velocity")]
    public class Velocity : Attachment
    {
        [SerializeField] private GameObject target;
        [SerializeField] private Vector2Link value;

        private Rigidbody2D _body;
        
        private void Start()
        {
            _body = target.GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_body)
                _body.velocity = value.Vector2Value;
            else
                target.transform.localPosition += new Vector3(value.Vector2Value.x, value.Vector2Value.y, 0) * Time.deltaTime;
        }
    }
}
