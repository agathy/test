using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    [CreateAssetMenu(fileName = "NPC����", menuName = "��ɫ����/��ɫ״̬")]

    public class NPCState : ScriptableObject
    {
        [LabelText("�Ի�״̬")]
        [ListDrawerSettings(ShowIndexLabels = true, AddCopiesLastElement = true)]
        public List<NPCConf> NPCStates;


        
    }
}
