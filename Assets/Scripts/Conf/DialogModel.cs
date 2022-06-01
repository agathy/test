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

        [Required(ErrorMessage = "NPC必须说点什么")]
        [VerticalGroup("NPC/NPCField"), HideLabel, Multiline(4)]
        public string NPCContent;

        [VerticalGroup("NPC/NPCField"), LabelText("对话类型")]
        //0=头像对话框，1=气泡框
        public int DialogClass;



        [LabelText("NPC事件")]
        public List<DialogEventModel> DialogEventModels;
        [LabelText("玩家选项")]
        public List<DialogPlayerSelect> DialogPlayerSelects;



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

    /// <summary>
    /// 对话事件数据
    /// </summary>
    public enum DialogEventEnum
    {
        [LabelText("对话触发(F)")]
        Eventtrigger,

        [LabelText("播放对话(NF)")]
        NextDialog,

        [LabelText("退出对话")]
        ExitDialog,

        [LabelText("对话触发条件(多重条件)")]
        JumpDialog,

        [LabelText("黑屏状态")]
        ScreenEffect,
        
        [LabelText("主角自言自语状态")]
        AutomaticSpeaking,

        [LabelText("解锁人物")]
        CharacterUnlock,

        [LabelText("获取线索")]
        ClueGet,
        [LabelText("获取道具")]
        ItemGet,
        [LabelText("失去道具")]
        ItemLose,
        [LabelText("定向移动")]
        DirectionalMigration,
        [LabelText("临时线索获取")]
        emituofo

    }
    /// <summary>
    /// 对话事件数据
    /// </summary>
    [Serializable]
    public class DialogEventModel
    {
        [HideLabel, HorizontalGroup("事件", MaxWidth = 100)]
        //  [LabelText("事件")]
        public DialogEventEnum DialogEvent;
        [HideLabel, HorizontalGroup("事件")]

        //    [LabelText("参数")]
        public string Args;
    }

    /// <summary>
    /// 玩家选择
    /// </summary>
    [Serializable]
    public class DialogPlayerSelect
    {
        [LabelText("选项文字"), MultiLineProperty(2), LabelWidth(50)]
        public string Conent;
        [LabelText("事件")]
        public List<DialogEventModel> DialogEventModels;

    }
}