using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class ClueMapUI : MonoBehaviour
    {
        // Start is called before the first frame update
        public void ExitClueMap()
        {
            PlayerCharacter.PlayerInstance.Uncluemap();
        }

        public void RestartLevel()
        {
            ExitClueMap();
            SceneController.RestartZone();
        }
    }
}
