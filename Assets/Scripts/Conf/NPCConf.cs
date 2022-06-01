using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hgcxt
{
    [CreateAssetMenu(fileName = "NPC配置", menuName = "角色配置/新增角色")]
    public class NPCConf : ScriptableObject
    {
        [HorizontalGroup("NPC", 75, LabelWidth = 50), HideLabel, PreviewField(75)]
        public Sprite Head;
        [VerticalGroup("NPC/NPCField"), LabelText("名字")]
        public string Name;
        [VerticalGroup("NPC/NPCField"), LabelText("对话状态")]
        public float State;
        [VerticalGroup("NPC/NPCField"), LabelText("位置状态")]
        public int Pos;
        [VerticalGroup("NPC/NPCField"), LabelText("解锁")]
        public bool isUnlock;
        [VerticalGroup("NPC/NPCField"),LabelText("移动")]
        public bool move;
        [LabelText("解锁文本")]
        public DialogModel unlockmessage;
        [LabelText("移动路线")]
        public List<Vector3> MovePositions;

        /* [LabelText("主角专用——自言自语")]
         public DialogModel unlockmessage;
 */


    }
}

