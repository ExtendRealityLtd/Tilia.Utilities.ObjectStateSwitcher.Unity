namespace Tilia.Utilities.ObjectStateSwitcher.Utility
{
    using System.IO;
    using UnityEditor;
    using Zinnia.Utility;

    public class PrefabCreator : BasePrefabCreator
    {
        private const string group = "Tilia/";
        private const string project = "Utility/";
        private const string menuItemRoot = topLevelMenuLocation + group + subLevelMenuLocation + project;

        private const string package = "io.extendreality.tilia.utilities.objectstateswitcher.unity";
        private const string baseDirectory = "Runtime";
        private const string prefabDirectory = "Prefabs";
        private const string prefabSuffix = ".prefab";

        private const string prefabObjectStateSwitcher = "Utilities.ObjectStateSwitcher";

        [MenuItem(menuItemRoot + prefabObjectStateSwitcher, false, priority)]
        private static void AddObjectStateSwitcher()
        {
            string prefab = prefabObjectStateSwitcher + prefabSuffix;
            string packageLocation = Path.Combine(packageRoot, package, baseDirectory, prefabDirectory, prefab);
            CreatePrefab(packageLocation);
        }
    }
}