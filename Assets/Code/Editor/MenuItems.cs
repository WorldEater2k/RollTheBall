using UnityEditor;

namespace RollTheBall
{
    internal sealed class MenuItems
    {
        [MenuItem("My extensions/��������� �������")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(GeneratorWindow), false, "��������� �������");
        }
    }
}
