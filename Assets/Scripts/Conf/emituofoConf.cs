using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace hgcxt
{
    [CreateAssetMenu(menuName  = "�����ӷ�")]

    public class emituofoConf : ScriptableObject
    {
       
        [LabelText("����")]
        public List<xiansuo> test;

    }
    [Serializable]
    public class xiansuo
    {
        public string anzi;
        public List<strings> XianSuo;
   
    
    }
    [Serializable]
    public class strings
    {
        public string content;
        public bool jiesuo;
    }


}