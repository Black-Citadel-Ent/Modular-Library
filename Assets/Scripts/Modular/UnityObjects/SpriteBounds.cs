using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/Sprite Bounds")]
    public class SpriteBounds : Attachment
    {
        [SerializeField] private SpriteRenderer sprite;

        public override string[] LinkedFloatNames => new[] { "Min X", "Max X", "Min Y", "Max Y" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals(LinkedFloatNames[0]))
                return sprite.bounds.min.x;
            if (valueName.Equals(LinkedFloatNames[1]))
                return sprite.bounds.max.x;
            if (valueName.Equals(LinkedFloatNames[2]))
                return sprite.bounds.min.y;
            if (valueName.Equals(LinkedFloatNames[3]))
                return sprite.bounds.max.y;
            return base.LoadLinkedFloat(valueName);
        }
    }
}
