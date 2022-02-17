using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Assets.MyUIExtentions
{
    public static class MyUIExtention
    {
        #region UGUI source code 
        #endregion
        [MenuItem("GameObject/UI/MyUIExtentions/DialogPanel")]
        public static void AddDialogPanel(MenuCommand menuCommand)
        {
            GameObject dialogPanel = DialogPanel.CreateGameObject();
            PlaceUIElementRoot(dialogPanel, menuCommand);
        }

        static void PlaceUIElementRoot(GameObject go, MenuCommand menuCommand)
        {
            // Retrieve an internal method "MenuOptions.PlaceUIElementRoot".
            var type = Type.GetType("UnityEditor.UI.MenuOptions,UnityEditor.UI");
            var flags = BindingFlags.NonPublic | BindingFlags.Static;
            var method = type.GetMethod("PlaceUIElementRoot", flags);

            // PlaceUIElementRoot(go, menuCommand)
            method.Invoke(null, new System.Object[] { go, menuCommand });
        }
    }
}
