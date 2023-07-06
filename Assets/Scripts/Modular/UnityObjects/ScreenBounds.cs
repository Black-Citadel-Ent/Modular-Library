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
            if (valueName.Equals(LinkedFloatNames[0]))
                return _camera.transform.position.x - _camera.orthographicSize * Screen.width / Screen.height;
            if (valueName.Equals(LinkedFloatNames[2]))
                return _camera.transform.position.x + _camera.orthographicSize * Screen.width / Screen.height;
            if (valueName.Equals(LinkedFloatNames[1]))
                return _camera.transform.position.y - _camera.orthographicSize;
            if (valueName.Equals(LinkedFloatNames[3]))
                return _camera.transform.position.y + _camera.orthographicSize;
            if (valueName.Equals(LinkedFloatNames[4]))
                return _camera.orthographicSize * 2 * Screen.width / Screen.height;
            if (valueName.Equals(LinkedFloatNames[5]))
                return _camera.orthographicSize * 2;
            return base.LoadLinkedFloat(valueName);
        }

        private void Start()
        {
            _camera = Camera.main;
        }
    }
}
