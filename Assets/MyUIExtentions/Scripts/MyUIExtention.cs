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
            DialogPanel.CreateGameObject(menuCommand.context as GameObject);
        }
    }
}
