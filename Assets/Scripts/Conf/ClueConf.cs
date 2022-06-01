using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hgcxt
{
    [CreateAssetMenu(fileName = "��������", menuName = "��������/������������")]

    public class ClueConf : ScriptableObject

    {
        [LabelText("��������")]

        [HideLabel]
        [OnValueChanged("NPCConfOnValueChanged")]
        public NPCConf NPCConf;

        [HorizontalGroup("NPC", 75, LabelWidth = 50), ReadOnly, HideLabel, PreviewField(75)]
        public Sprite NPCHead;

        [VerticalGroup("NPC/NPCField"), HideLabel, LabelText("NPC����")]
        public List<string> Clues;


        [HorizontalGroup("NPC",35)]
        public List<bool> IsClueGet;
        /// <summary>
        /// NPC�����ļ��޸�ʱҪ�õķ���
        /// </summary>
        private void NPCConfOnValueChanged()
        {
            if (NPCConf == null || NPCConf.Head == null)
            {
                NPCHead = null;

            }
            else
            {
                NPCHead = NPCConf.Head;
            }
        }
    }


}