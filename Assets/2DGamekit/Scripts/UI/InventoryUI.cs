using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hgcxt
{
    public class InventoryUI : MonoBehaviour
    {
        public void ExitInventory()
        {
            PlayerCharacter.PlayerInstance.Uninventory();
        }

        public void RestartLevel()
        {
            ExitInventory();
            SceneController.RestartZone();
        }
    }
}