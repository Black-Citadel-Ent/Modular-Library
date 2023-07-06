using System;
using UnityEngine;

namespace Modular.Physics2D
{
    [AddComponentMenu("Modular/2D Physics/Predict Frame Motion")]
    public class PredictFrameMotion : Attachment
    {
        [SerializeField] private Vector2Link velocity;
        [SerializeField] private Vector2Link acceleration;
        
        public override string[] LinkedVector2Names => new[] { "Next Frame Motion" };

        public override Vector2 LoadLinkedVector2(string valueName)
        {
            if (valueName.Equals(LinkedVector2Names[0]))
                return (velocity.Vector2Value + acceleration.Vector2Value * Time.fixedDeltaTime) * Time.fixedDeltaTime;
            return base.LoadLinkedVector2(valueName);
        }
    }
}
