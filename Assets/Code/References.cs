using UnityEngine;

namespace RollTheBall
{
    internal static class References
    {
        private static Player _player;
        private static Camera _mainCamera;
        private static PlayerStats _stats;
        private static Canvas _canvas;
        public static Player Player
        {
            get
            {
                if (_player == null)
                    _player = GameObject.FindObjectOfType<Player>();
                return _player;
            }
        }

        public static Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                    _mainCamera = Camera.main;
                return _mainCamera;
            }
        }
        public static PlayerStats PlayerStats
        {
            get
            {
                if (_stats == null)
                    _stats = Resources.Load<PlayerStats>("ScriptableObjects/PlayerStats");
                if (_stats == null)
                    _stats = ScriptableObject.CreateInstance<PlayerStats>();
                return _stats;
            }
        }

        public static Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                    _canvas = GameObject.FindObjectOfType<Canvas>();
                return _canvas;
            }
        }

    }
}
