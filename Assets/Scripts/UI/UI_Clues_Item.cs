using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace hgcxt
{

    public class UI_Clues_Item : MonoBehaviour
    {

        private Text text;

    
        public void Init(string clue)
        {

            text = transform.Find("Text").GetComponent<Text>();
            text.text = clue;
        }
    }
}
