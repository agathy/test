using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEditor;


namespace hgcxt
{

    public class NPCManager : MonoBehaviour
    {
        public static NPCManager Instance;
      
        DialogConf dialogConf;
        ClueConf clueConf;
        NPCConf npcConf;
        NPCState npcStates;
        DialogueCanvasController dialogueCanvasController;
        private bool move;
        string MoveNPC;

        //[MenuItem("Tools/检测对话数据配置")]

      


        public static void CheckDialogConfs()
        {
            DialogConf[] dialogConfs = Resources.LoadAll<DialogConf>("Conf");
            
            //遍历全部对话数据的配置文件
            for (int i = 0; i < dialogConfs.Length; i++)
            {
                //遍历对话数据中的list模型
                for (int j = 0; j <= dialogConfs[i].DialogModels.Count; j++)
                {
                    if (dialogConfs[i].DialogModels[j].NPCConf == null || dialogConfs[i].DialogModels[j].NPCConf.Head == null || dialogConfs[i].DialogModels[j].NPCConf.Name == null)
                    {
                        Debug.LogError(dialogConfs[i].name + "__中的第" + j + "条数据缺少npc数据或头像");
                    }
                }
            }
            Debug.Log("检测完毕");
        }


        private void Awake()
        {
            Instance = this;
            //dialogConfs = Resources.LoadAll<DialogConf>("Conf");

        }
        private void Start()
        {
            //初始化
    
            clueConf = Resources.Load<ClueConf>("Conf/" + this.name + "线索");         
            npcStates = Resources.Load<NPCState>("Conf/NPC配置");
            dialogConf = Resources.Load<DialogConf>("Conf/" + this.name + "对话");
            npcConf = Resources.Load<NPCConf>("Conf/" + this.name);
            npcConf.State = 0f;
            npcConf.currPos = -1;
            npcConf.targetPos = -1;
            npcConf.move = false;
            npcConf.isUnlock = false;
           
            for (int i = 0; i < clueConf.IsClueGet.Count; i++)
            {
                clueConf.IsClueGet[i]= false;
            }

            //！！！！！！！！！！！！！！！！！！临时初始化！！！！！！！！！！！！！！！！！！！！后期修改
            npcStates.NPCStates.Clear(); ;

        }


        private void Update()
        {
            
       //解锁
            if (npcConf.isUnlock)
            {
                gameObject.GetComponent<InteractOnButton2D>().OnSkillPressDown.SetPersistentListenerState(0,UnityEngine.Events.UnityEventCallState.RuntimeOnly);
            }
            else
            {
            }
            //移动
            int count = npcConf.MovePositions.Count;
            if (npcConf.targetPos == npcConf.currPos||count==0)
            {
                npcConf.move = false;
            }
            else
            {
                if (npcConf.move)
                {
                    print(this.name + count);
                    this.transform.position = Vector3.MoveTowards(this.transform.position, npcConf.MovePositions[npcConf.currPos+1], 0.8f*Time.deltaTime);
                }
                if (this.transform.position == npcConf.MovePositions[npcConf.currPos+1])
                {
                    npcConf.currPos+=1;
                }
            }            
            //npcConf.isUnlock=IsAllClueGet(clueConf);
        }



        /// <summary>
        /// 角色解锁
        /// </summary>
        /// <param name="name"></param>
        public void CharacterUnlockEvent(string name)
        {
            print("解锁" + name);
            NPCConf unlocknpc = Resources.Load<NPCConf>("Conf/"+ name);
            unlocknpc.isUnlock = true;
        }
        /// <summary>
        /// 获得线索
        /// </summary>
        public void ClueGetEvent(string name, int index)
        {
            ClueConf cluegets = Resources.Load<ClueConf>("Conf/" + name + "线索");
            cluegets.IsClueGet[index] = true;
        }
        /// <summary>
        /// 获取道具
        /// </summary>
        public void ItemGetEvent(string name)
        {
            print("获取道具——" + name);
        }
        /// <summary>
        /// 使用道具
        /// </summary>
        public void ItemLoseEvent(string name)
        {
            print("失去道具——" + name);
        }
        /// <summary>
        /// 定向移动
        /// </summary>
        public void DirectionalMigrationEvent(string name,int index)
        {
            print("动一动");
            MoveNPC = name;
            NPCConf movenpc = Resources.Load<NPCConf>("Conf/" + name);
            movenpc.move = true;
            movenpc.targetPos = index;
            
        }

        /// <summary>
        /// 摄像机效果-闪烁
        /// </summary>
        public void ScreenEF(float delay)
        {
            StartCoroutine(DoScreenEF(delay));
        }


        private IEnumerator DoScreenEF(float delay)
        {
            //GameObject.Find("Canvas/BG").GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(delay);
            //GameObject.Find("Canvas/BG").GetComponent<Image>().color = Color.white;
        }

      

        public bool IsAllClueGet(ClueConf clueConfs)
        {
            for (int i = 0; i < clueConfs.IsClueGet.Count; i++)
            {
    
                if (!clueConfs.IsClueGet[i])
                {
                    return false;
                }
                else if (!npcStates.NPCStates.Contains(npcConf))
                {
                        npcStates.NPCStates.Add(npcConf);
                }
               
            }
            return true;
        }
        public void GetDialogConf()
        {
            string name = this.name;
            dialogueCanvasController.ActivateCanvasWithText(name);
            //return dialogConf;
        }

    }
}
