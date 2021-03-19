using UnityEngine;

namespace RollTheBall
{
    internal sealed class InputController : IInitialization, IUpdatable
    {
        [SerializeField] private float _mouseSensitivity = 100f;
        private Player _player;
        private Transform _cameraPos;
        private Transform _cameraCenter;
        private Initializator _initializator;
        private UpdateController _updateController;
        public InputController(Initializator initializator, UpdateController updateController)
        {
            _initializator = initializator;
            _updateController = updateController;
            SubscribeToInit();
            SubscribeToUpdate();
        }
        public void Init()
        {
            Cursor.lockState = CursorLockMode.Locked;
            _player = References.Player;
            _cameraPos = References.MainCamera.transform;
            _cameraCenter = _cameraPos.parent;
        }
        public void MyUpdate()
        {
            float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity * Time.deltaTime;
            _cameraCenter.Rotate(Vector3.up * mouseX, Space.World);

            float z = Input.GetAxis("Vertical");
            _player.Move(z * Time.deltaTime, _cameraPos.forward);
            _cameraCenter.position = _player.transform.position;
        }
        public void SubscribeToInit()
        {
            References.Initializator.OnInitialization += Init;
        }
        public void SubscribeToUpdate()
        {
            References.UpdateController.OnUpdate += MyUpdate;
        }
        public void Dispose()
        {
            References.UpdateController.OnUpdate -= MyUpdate;
            References.Initializator.OnInitialization -= Init;
        }
    }
}
