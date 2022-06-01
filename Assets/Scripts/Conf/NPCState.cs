using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    [CreateAssetMenu(fileName = "NPCÅäÖÃ", menuName = "½ÇÉ«ÅäÖÃ/½ÇÉ«×´Ì¬")]

    public class NPCState : ScriptableObject
    {
        [LabelText("¶Ô»°×´Ì¬")]
        [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement = true)]
        public List<NPCConf> NPCStates;


        
    }
}
