using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class OptionUI : MonoBehaviour
    {
        public void ExitMenus()
        {
            PlayerCharacter.PlayerInstance.Unmenus();
        }

        public void RestartLevel()
        {
            ExitMenus();
            SceneController.RestartZone();
        }

        public void BackToStart()
        {
            //ExitMenus();
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Start", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}