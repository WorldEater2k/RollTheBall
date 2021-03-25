using UnityEditor;
using UnityEngine;

namespace RollTheBall
{
    internal sealed class GeneratorWindow : EditorWindow
    {
        private GameObject _bonusPrefab;
        private string _objectName = "NewBonus";
        private bool _groupEnabled;
        private int _count = 5;
        private Color _color = Color.yellow;
        private float _x1 = -10f;
        private float _z1 = -10f;
        private float _x2 = 10f;
        private float _z2 = 10f;

        private void OnGUI()
        {
            GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
            _bonusPrefab = EditorGUILayout.ObjectField
                ("Префаб бонуса", _bonusPrefab, typeof(GameObject), true) as GameObject;
            _objectName = EditorGUILayout.TextField("Имя объекта", _objectName);

            _groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", _groupEnabled);

            _color = EditorGUILayout.ColorField("Цвет", _color);
            _count = EditorGUILayout.IntSlider("Кол-во бонусов", _count, 1, 100);
            GUILayout.Label("Точка 1");
            _x1 = EditorGUILayout.FloatField("X1", _x1);
            _z1 = EditorGUILayout.FloatField("Z1", _z1);
            GUILayout.Label("Точка 2");
            _x2 = EditorGUILayout.FloatField("X2", _x2);
            _z2 = EditorGUILayout.FloatField("Z2", _z2);

            EditorGUILayout.EndToggleGroup();

            var button = GUILayout.Button("Создать объекты");
            if (button)
            {
                if (_bonusPrefab)
                {
                    GameObject root = new GameObject("BonusesRoot");
                    for (int i = 0; i < _count; i++)
                    {
                        Vector3 pos = new Vector3(Random.Range(_x1, _x2), 0f, Random.Range(_z1, _z2));
                        GameObject temp = Instantiate(_bonusPrefab, pos, Quaternion.identity);
                        temp.name = _objectName + " (" + i + ")";
                        temp.transform.parent = root.transform;
                        var renderer = temp.GetComponent<Renderer>();
                        if (renderer)
                            renderer.material.color = _color;
                    }
                }
            }
        }
    }
}
