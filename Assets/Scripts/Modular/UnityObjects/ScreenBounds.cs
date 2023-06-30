using UnityEngine;

namespace Modular.UnityObjects
{
    [AddComponentMenu("Modular/Unity Objects/2D Camera Bounds")]
    public class ScreenBounds : Attachment
    {
        private Camera _camera;
        public override string[] LinkedFloatNames => new[] { "Min X", "Min Y", "Max X", "Max Y", "Width", "Height" };

        public override float LoadLinkedFloat(string valueName)
        {
            if (valueName.Equals("Min X"))
                return _camera.transform.position.x - _camera.orthographicSize * Screen.width / Screen.height;
            if (valueName.Equals("Max X"))
                return _camera.transform.position.x + _camera.orthographicSize * Screen.width / Screen.height;
            if (valueName.Equals("Min Y"))
                return _camera.transform.position.y - _camera.orthographicSize;
            if (valueName.Equals("Max Y"))
                return _camera.transform.position.y + _camera.orthographicSize;
            if (valueName.Equals("Width"))
                return _camera.orthographicSize * 2 * Screen.width / Screen.height;
            if (valueName.Equals("Height"))
                return _camera.orthographicSize * 2;
            return base.LoadLinkedFloat(valueName);
        }

        private void Start()
        {
            _camera = Camera.main;
        }
    }
}
