using UnityEditor;

namespace RollTheBall
{
    internal sealed class MenuItems
    {
        [MenuItem("My extensions/Генерация бонусов")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(GeneratorWindow), false, "Генерация бонусов");
        }
    }
}
