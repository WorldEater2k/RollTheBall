using UnityEngine;

namespace RollTheBall
{
    internal sealed class InputController : IInitialization, IUpdatable
    {
        [SerializeField] private float _mouseSensitivity = 100f;
        private Player _player;
        private Transform _cameraPos;
        private Transform _cameraCenter;
        private readonly Initializator _initializator;
        private readonly UpdateController _updateController;
        private readonly DataRepository _dataRepository;

        public InputController(Initializator initializator, UpdateController updateController)
        {
            _initializator = initializator;
            _updateController = updateController;
            SubscribeToInit();
            SubscribeToUpdate();
            _dataRepository = new DataRepository();
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

            if (Input.GetKeyDown(KeyCode.F5))
                _dataRepository.Save(_player);
            if (Input.GetKeyDown(KeyCode.F6))
                _dataRepository.Load();
        }
        public void SubscribeToInit()
        {
            _initializator.OnInitialization += Init;
        }
        public void SubscribeToUpdate()
        {
            _updateController.OnUpdate += MyUpdate;
        }
        public void Dispose()
        {
            _updateController.OnUpdate -= MyUpdate;
            _initializator.OnInitialization -= Init;
        }
    }
}
