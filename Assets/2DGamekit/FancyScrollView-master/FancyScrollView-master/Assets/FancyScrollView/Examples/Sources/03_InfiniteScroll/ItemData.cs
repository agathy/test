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
namespace hgcxt.Example03
{
    class ItemData
    {

        public string Name { get;  }
        public Sprite Head { get; }

        public ItemData(string name, Sprite head)
        {
            Name = name;
            Head = head;
        }
    }
}
