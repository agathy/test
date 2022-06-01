using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class PauseUI : MonoBehaviour
    {
        public void ExitPause()
        {
            PlayerCharacter.PlayerInstance.Unpause();
        }

        public void RestartLevel()
        {
            ExitPause();
            SceneController.RestartZone();
        }
    }
}