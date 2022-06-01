using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace hgcxt
{
    [CreateAssetMenu(fileName = "线索配置", menuName = "线索配置/新增线索数据")]

    public class ClueConf : ScriptableObject

    {
        [LabelText("线索数据")]

        [HideLabel]
        [OnValueChanged("NPCConfOnValueChanged")]
        public NPCConf NPCConf;

        [HorizontalGroup("NPC", 75, LabelWidth = 50), ReadOnly, HideLabel, PreviewField(75)]
        public Sprite NPCHead;

        [VerticalGroup("NPC/NPCField"), HideLabel, LabelText("NPC线索")]
        public List<string> Clues;


        [HorizontalGroup("NPC",35)]
        public List<bool> IsClueGet;
        /// <summary>
        /// NPC配置文件修改时要用的方法
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