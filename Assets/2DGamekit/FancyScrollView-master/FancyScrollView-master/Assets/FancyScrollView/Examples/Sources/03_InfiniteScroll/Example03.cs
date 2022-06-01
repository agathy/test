/*
 * FancyScrollView (https://github.com/setchi/FancyScrollView)
 * Copyright (c) 2020 setchi
 * Licensed under MIT (https://github.com/setchi/FancyScrollView/blob/master/LICENSE)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using System.Linq;


namespace hgcxt.Example03
{
    class Example03 : MonoBehaviour
    {
        [SerializeField] ScrollView scrollView = default;
        public int CellNum;
        List<ItemData> items;
        public Sprite head;
        ItemData itemData;
        NPCState npcStates;   
        void Start()
        {
            npcStates = Resources.Load<NPCState>("Conf/NPC配置");
      /*      var items = Enumerable.Range(0, CellNum)
                .Select(i => new ItemData($"Cell {i}", head))
                .ToArray();
*/
           items = new List<ItemData>();
               npcStates = Resources.Load<NPCState>("Conf/NPC配置");
            for (int i = 0; i < npcStates.NPCStates.Count; i++)
            {
                itemData = new ItemData(npcStates.NPCStates[i].Name, npcStates.NPCStates[i].Head);
               
               
                items.Add(itemData);
               
            }

            scrollView.UpdateData(items);
            scrollView.SelectCell(0);

        }

    
    }
}
