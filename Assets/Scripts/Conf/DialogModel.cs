using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System;
namespace hgcxt
{
    [Serializable]
    public class DialogModel
    {
        [HideLabel]
        [OnValueChanged("NPCConfOnValueChanged")]
        public NPCConf NPCConf;



        [HorizontalGroup("NPC", 75, LabelWidth = 50), ReadOnly, HideLabel, PreviewField(75)]
        public Sprite NPCHead;

        [Required(ErrorMessage = "NPC����˵��ʲô")]
        [VerticalGroup("NPC/NPCField"), HideLabel, Multiline(4)]
        public string NPCContent;

        [VerticalGroup("NPC/NPCField"), LabelText("�Ի�����")]
        //0=ͷ��Ի���1=���ݿ�
        public int DialogClass;



        [LabelText("NPC�¼�")]
        public List<DialogEventModel> DialogEventModels;
        [LabelText("���ѡ��")]
        public List<DialogPlayerSelect> DialogPlayerSelects;



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

    /// <summary>
    /// �Ի��¼�����
    /// </summary>
    public enum DialogEventEnum
    {
        [LabelText("�Ի�����(F)")]
        Eventtrigger,

        [LabelText("���ŶԻ�(NF)")]
        NextDialog,

        [LabelText("�˳��Ի�")]
        ExitDialog,

        [LabelText("�Ի���������(��������)")]
        JumpDialog,

        [LabelText("����״̬")]
        ScreenEffect,
        
        [LabelText("������������״̬")]
        AutomaticSpeaking,

        [LabelText("��������")]
        CharacterUnlock,

        [LabelText("��ȡ����")]
        ClueGet,
        [LabelText("��ȡ����")]
        ItemGet,
        [LabelText("ʧȥ����")]
        ItemLose,
        [LabelText("�����ƶ�")]
        DirectionalMigration,
        [LabelText("��ʱ������ȡ")]
        emituofo

    }
    /// <summary>
    /// �Ի��¼�����
    /// </summary>
    [Serializable]
    public class DialogEventModel
    {
        [HideLabel, HorizontalGroup("�¼�", MaxWidth = 100)]
        //  [LabelText("�¼�")]
        public DialogEventEnum DialogEvent;
        [HideLabel, HorizontalGroup("�¼�")]

        //    [LabelText("����")]
        public string Args;
    }

    /// <summary>
    /// ���ѡ��
    /// </summary>
    [Serializable]
    public class DialogPlayerSelect
    {
        [LabelText("ѡ������"), MultiLineProperty(2), LabelWidth(50)]
        public string Conent;
        [LabelText("�¼�")]
        public List<DialogEventModel> DialogEventModels;

    }
}