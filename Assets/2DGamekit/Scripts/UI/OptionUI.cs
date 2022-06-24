using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class OptionUI : MonoBehaviour
    {
        public void ExitMenus()
        {
            print("aaaa");
            PlayerCharacter.PlayerInstance.Unmenus();
        }

        public void RestartLevel()
        {
            ExitMenus();
            SceneController.RestartZone();
        }

        public void BackToStart()
        {
            Time.timeScale = 1;
            //ExitMenus();
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync("Start", UnityEngine.SceneManagement.LoadSceneMode.Single);
        }
    }
}