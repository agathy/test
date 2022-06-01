using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace hgcxt
{
    [CreateAssetMenu(fileName = "NPC����", menuName = "��ɫ����/������ɫ")]
    public class NPCConf : ScriptableObject
    {
        [HorizontalGroup("NPC", 75, LabelWidth = 50), HideLabel, PreviewField(75)]
        public Sprite Head;
        [VerticalGroup("NPC/NPCField"), LabelText("����")]
        public string Name;
        [VerticalGroup("NPC/NPCField"), LabelText("�Ի�״̬")]
        public float State;
        [VerticalGroup("NPC/NPCField"), LabelText("λ��״̬")]
        public int Pos;
        [VerticalGroup("NPC/NPCField"), LabelText("����")]
        public bool isUnlock;
        [VerticalGroup("NPC/NPCField"),LabelText("�ƶ�")]
        public bool move;
        [LabelText("�����ı�")]
        public DialogModel unlockmessage;
        [LabelText("�ƶ�·��")]
        public List<Vector3> MovePositions;

        /* [LabelText("����ר�á�����������")]
         public DialogModel unlockmessage;
 */


    }
}

