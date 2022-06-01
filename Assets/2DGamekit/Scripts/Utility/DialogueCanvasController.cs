using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

namespace hgcxt
{
    public class DialogueCanvasController : MonoBehaviour
    {
        public static DialogueCanvasController Instance;
        public Animator animator;
        public TextMeshProUGUI textMeshProUGUI;
    
        
        protected Coroutine m_DeactivationCoroutine;
    

        protected readonly int m_HashActivePara = Animator.StringToHash ("Active");
        
        //njq added
        [SerializeField] int index = 0, Temp, Count, Lenght;
        [SerializeField] bool full = false, FirstString = false; 
        public int ShowHowManyChar = 70;
        char[] ary;
        bool globalFlag = false;


        //0509
        private Image head;
        private TextMeshProUGUI nameText;
        private TextMeshProUGUI mainText;
        //private RectTransform content;
        
        private Transform Options;
        private GameObject prefab_OptionItem;

        
        private DialogConf currConf;
        private int currIndex;
        private NPCConf npcConf;
        //0510
       

        //0511
        private GameObject dialogueCanvas;
        private TextMeshProUGUI bubbleText;
        private GameObject reviewCanvas;
        private TextMeshProUGUI reviewText;
        private GameObject bubbleCanvas;
        //++++++



        private void Awake()
        {
           
            
            head = transform.Find("DialogueBG/Head").GetComponent<Image>();
            nameText = transform.Find("DialogueBG/Name").GetComponent<TextMeshProUGUI>();
            //mainText = transform.Find("Main/MainText").GetComponent<Text>();

            //mainText = transform.Find("DialogueBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
            
            
           
            //content = transform.Find("DialogueBG").GetComponent<RectTransform>();
            Options = transform.Find("Options");
            prefab_OptionItem = Resources.Load<GameObject>("Options_Item");
            Instance = this;
            //dialogConfs = Resources.LoadAll<DialogConf>("Conf");


            //0511
            //对话框
            dialogueCanvas = transform.Find("DialogueBG").gameObject;
            dialogueCanvas.SetActive(false);

            //线索回顾
            reviewCanvas = transform.Find("ReviewBG").gameObject;
            reviewCanvas.SetActive(false);
            reviewText =transform.Find("ReviewBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
            //气泡
            bubbleCanvas= transform.Find("BubbleBG").gameObject;
            bubbleCanvas.SetActive(false);
            bubbleText = transform.Find("BubbleBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();

            paramReduction();


        }

        private void Start()
        {
            

        }


        public void TestDialog(string name,bool isunlock)
        {
            paramReduction();
         
            PlayerInput.Instance.Interact.Disable();
            //找到需要的对话配置文件
            currConf = Resources.Load<DialogConf>("Conf/" + name+"对话");
            npcConf = Resources.Load<NPCConf>("Conf/" + name);
            
            
            //解锁人物
            if (isunlock)
            {   reviewCanvas.SetActive(true);
                
                bubbleCanvas.SetActive(false);
                dialogueCanvas.SetActive(false);
                mainText = transform.Find("ReviewBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
                //GameObject.Find(name).GetComponent<InteractOnButton2D>().enabled = false;
               // currIndex = currConf.DialogModels.Count - 1;
                ShowHowManyChar = 150;
              
                StartDialog(npcConf.unlockmessage, true);
            }
            else
            {
              
                ShowHowManyChar = 70;
                //要从第0条数据开始
                
                currIndex = (int)npcConf.State;
               // DialogModel model = conf.DialogModels[index];
                
                StartDialog(currConf.DialogModels[(int)npcConf.State], false);

            }
                 //StartCoroutine(DoMainTextEF("这是一个测试文字~~~~~~~~~~~~~~~~"));
        }

        private void StartDialog(DialogModel model,bool isunlock)
        {
          
            //修改npc头像和名字
            if (!isunlock) {
              
                if (model.DialogClass == 1)
                {
                    //气泡框
                    mainText = transform.Find("BubbleBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
                    bubbleCanvas.SetActive(true);
                    dialogueCanvas.SetActive(false);
                    reviewCanvas.SetActive(false);
                }
                else if (model.DialogClass == 0)
                {
                    //
                    mainText = transform.Find("DialogueBG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
                    dialogueCanvas.SetActive(true);
                    bubbleCanvas.SetActive(false);
                    reviewCanvas.SetActive(false);
                }
                head.sprite = model.NPCConf.Head;
                nameText.text = model.NPCConf.Name;
            }


            paramReduction();
            //选择对话框类型
    
            //npc开始说话
//            StartCoroutine(DoMainTextEF(model.NPCContent));
            StartCoroutine(DoMainTextEF(model));

            //npc事件
            for (int i = 0; i < model.DialogEventModels.Count; i++)
            {
                ParseDiaLogEvent(model.DialogEventModels[i].DialogEvent, model.DialogEventModels[i].Args);
            }

            //玩家选项
            //删除已有的玩家选项
            Transform[] items = Options.GetComponentsInChildren<Transform>();
            for (int i = 1; i < items.Length; i++)
            {
                Destroy(items[i].gameObject);
            }
            if (full)
            {

            }
        }

        public void ParseDiaLogEvent(DialogEventEnum dialogEvent, string args)
        {
            switch (dialogEvent)
            {
                case DialogEventEnum.Eventtrigger:
                    if (args !="")
                    {
                        if (args.Split('_').Length > 1)
                        {
                            EventtriggerEvent(args.Split('_')[0], int.Parse(args.Split('_')[1]));
                        }
                        else
                        {
                            EventtriggerEvent(int.Parse(args));
                        }
                        
                    }
                    else
                    {
                        EventtriggerEvent();
                    }
                    break;

                case DialogEventEnum.ScreenEffect:
                    EllenDialogue.Instance.ScreenEF(bool.Parse(args));
                    break;
                case DialogEventEnum.AutomaticSpeaking:
                    EllenDialogue.Instance.AutoSpeaking(bool.Parse(args));
                    break;
                case DialogEventEnum.NextDialog:

                    if (args != "")
                    {
                        if (args.Split('_').Length > 1)
                        {
                            NextDialogEvent(args.Split('_')[0], int.Parse(args.Split('_')[1]));
                        }
                        else
                        {
                            NextDialogEvent(int.Parse(args));
                        }
                    }
                    else
                    {
                        NextDialogEvent();
                    }
                    break;

                case DialogEventEnum.ExitDialog:
                    ExitDialogEvent(int.Parse(args));
                    break;
                case DialogEventEnum.JumpDialog:
                    JumpDialogEvent(args.Split('_')[0],float.Parse(args.Split('_')[1]));
                    break;
              
                case DialogEventEnum.CharacterUnlock:
                    NPCManager.Instance.CharacterUnlockEvent(args);
                    break;
                case DialogEventEnum.ClueGet:
                    NPCManager.Instance.ClueGetEvent(args.Split('_')[0], int.Parse(args.Split('_')[1]));
                    break;
                case DialogEventEnum.ItemGet:
                    NPCManager.Instance.ItemGetEvent(args);
                    break;
                case DialogEventEnum.ItemLose:
                    NPCManager.Instance.ItemLoseEvent(args);
                    break;
                case DialogEventEnum.DirectionalMigration:
                    NPCManager.Instance.DirectionalMigrationEvent(args);
                    break;
                case DialogEventEnum.emituofo:
                    print("jingli");
                    EllenDialogue.Instance.test(args.Split('_')[0],int.Parse(args.Split('_')[1]));
                    break;



            }
        }
        /// <summary>
        /// 下一条
        /// </summary>
        private void NextDialogEvent()
        {
            npcConf.State += 1;    
            currIndex += 1;
            StartDialog(currConf.DialogModels[(int)npcConf.State], false);
        }
        private void NextDialogEvent(string name, int index)
        {
            NPCConf nextnpc = Resources.Load<NPCConf>("Conf/" + name);
            nextnpc.State = index;
            DialogConf nextnpcdialog= Resources.Load<DialogConf>("Conf/" + name+"对话");
            StartDialog(nextnpcdialog.DialogModels[index], false);
        }
        private void NextDialogEvent(int index)
        {
            npcConf.State =index;
            currIndex= (int)npcConf.State;
            StartDialog(currConf.DialogModels[(int)npcConf.State], false);
        }

        /// <summary>
        /// 退出对话
        /// </summary>
        public void ExitDialogEvent(int delay)
        {
            DeactivateCanvasWithDelay(delay);
        }
         
        /// <summary>
        /// 对话触发条件
        /// </summary>
        public void JumpDialogEvent(string name,float index)
        {
            NPCConf jumpnpc = Resources.Load<NPCConf>("Conf/" + name);
            jumpnpc.State += index;
        }
        /// <summary>
        /// 对话触发其他对话事件
        /// </summary>
        public void EventtriggerEvent(string name,int index)
        {         
            NPCConf triggernpc = Resources.Load<NPCConf>("Conf/" + name);
            triggernpc.State = index;
        }
        public void EventtriggerEvent(int index)
        {
            npcConf.State = index;
        }
        public void EventtriggerEvent()
        {
            npcConf.State += 1;
        }



        private void paramReduction()
        {
            index = 0;
            Temp = 0;
            Count = 0; 
            Lenght = 0;
            full = false;
            FirstString = false;
            globalFlag = false;

        }

        IEnumerator SetAnimatorParameterWithDelay (float delay)
        {

           
            yield return new WaitForSeconds (delay);
            animator.SetBool(m_HashActivePara, false);
            gameObject.SetActive(false);
            PlayerInput.Instance.Interact.Enable();
        }


        public void ActivateCanvasWithText(string name)
        {
         
            //TestDialog();
            if (!gameObject.activeInHierarchy)
            {
                if (m_DeactivationCoroutine != null)
                {
                    StopCoroutine(m_DeactivationCoroutine);
                    m_DeactivationCoroutine = null;
                }
                gameObject.SetActive(true);
                animator.SetBool(m_HashActivePara, true);
            }
            else
            {
            }
            paramReduction();
            TestDialog(name,false);
        }

        public void ActivateSkillCanvasWithText(string name)
        {
            print("解锁");
            //TestDialog();
            if (!gameObject.activeInHierarchy)
            {
                if (m_DeactivationCoroutine != null)
                {
                    StopCoroutine(m_DeactivationCoroutine);
                    m_DeactivationCoroutine = null;
                }
                gameObject.SetActive(true);
                animator.SetBool(m_HashActivePara, true);
            }
            else
            {
            }
  
        
            TestDialog(name,true);
        }


        //弹出对话框
        public void ActivateCanvasWithTranslatedText (string phraseKey)
        {
            print("调用");
            if (!gameObject.activeInHierarchy)
            {
                if (m_DeactivationCoroutine != null)
                {
                    StopCoroutine(m_DeactivationCoroutine);
                    m_DeactivationCoroutine = null;
                }
                
                
                //gameObject.transform.position = npc.transform.position;
                gameObject.SetActive(true);
     
                animator.SetBool(m_HashActivePara, true);
                //textMeshProUGUI.text = Translator.Instance[phraseKey];
                //测试文本
                mainText.text = "";
                ary = Translator.Instance[phraseKey].ToCharArray();
                mainText.text = "";
                
                Lenght = ary.Length;
                Count = (ary.Length < ShowHowManyChar) ? ary.Length : ShowHowManyChar;
                for (int i = index; i < Count; i++)
                {
                    string s = ary[i].ToString();
                    string temp = mainText.text;
                    mainText.text = temp + s;                   
                    Temp = i + 1;
                }          
                globalFlag = true;
            }
            else
            {
            }
        }


        /// <summary>
        /// 关闭对话框
        /// </summary>
        /// <param name="delay"></param>
        public void DeactivateCanvasWithDelay(float delay)
        {
            if (gameObject.activeInHierarchy)
            {
              
                m_DeactivationCoroutine = StartCoroutine(SetAnimatorParameterWithDelay(delay));
                //gameObject.SetActive(false);
            }
        }




        /// <summary>
        /// 对话显示
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        IEnumerator DoMainTextEF(DialogModel model)
        {

            paramReduction();
            ary = model.NPCContent.ToCharArray();

            FirstString = false;
       
            while (!full)
            {

               
                index = Temp;
                Count = (index > ary.Length) ? ary.Length : (Count + ShowHowManyChar);
             
                if (ary.Length - index < ShowHowManyChar)
                {
                    Count = ary.Length;
                    full = true;
                }
                mainText.text = "";
                for (int i = index; i < Count;i++)
                {
                    string temp = mainText.text;
                    string s = ary[i].ToString();
                    mainText.text = temp + s;
                 
                    yield return new WaitForSeconds(0.03f);

                    Temp = i + 1;
                }

                yield return new WaitForSeconds(0.2f);
            }
            if (full)
            {
                print("已到文本最后");
           
                //生成玩家选项
                for (int i = 0; i < model.DialogPlayerSelects.Count; i++)
                {
                   
                    var item = NPCManager.Instantiate<GameObject>(prefab_OptionItem, Options).GetComponent<UI_Options_Item>();
                    item.Init(model.DialogPlayerSelects[i]);

                }
                //gameObject.SetActive(false);
                //yield return new WaitForSeconds(1);
                PlayerInput.Instance.Interact.Enable();
                if (model.DialogPlayerSelects.Count==0)
                {
                 //   DeactivateCanvasWithDelay(1);
                }

            }


            /*  // 字符数量决定了 conteng的高 每23个字符增加25的高
              float addHeight = txt.Length / 23 + 1;
              content.sizeDelta = new Vector2(content.sizeDelta.x, addHeight * 25);

              string currStr = "";
              for (int i = 0; i < txt.Length; i++)
              {
                  currStr += txt[i];

                  mainText.text = currStr;
                  // 每满23个字，下移一个距离 25
                  if (i > 23 * 3 && i % 23 == 0)
                  {
                      content.anchoredPosition = new Vector2(content.anchoredPosition.x, content.anchoredPosition.y + 25);
                  }
              }*/
        }
    }
}
