using UnityEngine;

namespace Assets.CodeBase.Player
{
    public class CameraController : MonoBehaviour
    {
        Transform _cameraTransform;
        private void Start()
        {
            _cameraTransform = Camera.main.transform;
        }
        private void LateUpdate()
        {
            _cameraTransform.position = new Vector3(transform.position.x, transform.position.y, _cameraTransform.position.z);
        }
    }
}
