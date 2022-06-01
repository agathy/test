/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
namespace hgcxt
{


    public class UI_Dialog : MonoBehaviour
    {
        public static UI_Dialog Instance;
        private Image head;
        private TextMeshProUGUI nameText;
        private TextMeshProUGUI mainText;
        private RectTransform content;
        private Transform Options;
        private GameObject prefab_OptionItem;

        private DialogConf currConf;
        private int currIndex;

        private void Awake()
        {
            Instance = this;
        }
        private void Start()
        {
            *//*  head = transform.Find("Main/Head").GetComponent<Image>();
              nameText = transform.Find("Main/Name").GetComponent<Text>();
              mainText = transform.Find("Main/Scroll View/Viewport/Content/MainText").GetComponent<Text>();
              content = transform.Find("Main/Scroll View/Viewport/Content").GetComponent<RectTransform>();
              Options = transform.Find("Options");*//*

            head = transform.Find("BG/Head").GetComponent<Image>();
            nameText = transform.Find("BG/Name").GetComponent<TextMeshProUGUI>();

            //mainText = transform.Find("Main/MainText").GetComponent<Text>();
            mainText = transform.Find("BG/TextMeshPro Text").GetComponent<TextMeshProUGUI>();
            content = transform.Find("BG").GetComponent<RectTransform>();
            Options = transform.Find("Options");
            prefab_OptionItem = Resources.Load<GameObject>("Options_Item");
            TestDialog();
        }

        /// <summary>
        /// 开始对话
        /// </summary>
        private void TestDialog()
        {
            //找到需要的对话配置文件
            currConf = NPCManager.Instance.GetDialogConf(0);
            //要从第0条数据开始
            currIndex = 0;

            StartDialog(currConf, 0);
            //StartCoroutine(DoMainTextEF("这是一个测试文字~~~~~~~~~~~~~~~~"));
        }

        private void StartDialog(DialogConf conf, int index)
        {
            DialogModel model = conf.DialogModels[index];
            //修改npc头像和名字

            head.sprite = model.NPCConf.Head;
            nameText.text = model.NPCConf.Name;
            
            //npc开始说话
        StartCoroutine(DoMainTextEF(model.NPCContent));

            //npc事件
            for (int i = 0; i < model.DialogEventModels.Count; i++)
            {
                ParseDiaLogEvent(model.DialogEventModels[i].DialogEvent, model.DialogEventModels[i].Args);
            }

            //玩家选项
            //       删除已有的玩家选项
            Transform[] items = Options.GetComponentsInChildren<Transform>();
            for (int i = 1; i < items.Length; i++)
            {
                Destroy(items[i].gameObject);
            }

            //生成玩家选项
            for (int i = 0; i < model.DialogPlayerSelects.Count; i++)
            {
                UI_Options_Item item = NPCManager.Instantiate<GameObject>(prefab_OptionItem, Options).GetComponent<UI_Options_Item>();
                item.Init(model.DialogPlayerSelects[i]);

            }
        }

        public void ParseDiaLogEvent(DialogEventEnum dialogEvent, string args)
        {
            switch (dialogEvent)
            {
                case DialogEventEnum.ScreenEffect:

                    NPCManager.Instance.ScreenEF(float.Parse(args));
                    break;
                case DialogEventEnum.NextDialog:
                    NextDialogEvent();
                    break;
                case DialogEventEnum.ExitDialog:
                    ExitDialogEvent();
                    break;
                case DialogEventEnum.JumpDialog:
                    JumpDialogEvent(int.Parse(args));
                    break;

            }
        }

        /// <summary>
        /// 出发下一条对话
        /// </summary>
        private void NextDialogEvent()
        {

            currIndex += 1;
            print(currIndex);
            StartDialog(currConf, currIndex);
        }
        /// <summary>
        /// 退出对话
        /// </summary>
        public void ExitDialogEvent()
        {
            Debug.Log("对话退出");
        }
        /// <summary>
        /// 跳转对话
        /// </summary>
        public void JumpDialogEvent(int index)
        {
            currIndex = index;
            StartDialog(currConf, currIndex);
        }
        IEnumerator DoMainTextEF(string txt)
        {

            // 字符数量决定了 conteng的高 每23个字符增加25的高
            float addHeight = txt.Length / 23 + 1;
            content.sizeDelta = new Vector2(content.sizeDelta.x, addHeight * 25);

            string currStr = "";
            for (int i = 0; i < txt.Length; i++)
            {
                currStr += txt[i];
                yield return new WaitForSeconds(0.08f);
                mainText.text = currStr;
                // 每满23个字，下移一个距离 25
                if (i > 23 * 3 && i % 23 == 0)
                {
                    content.anchoredPosition = new Vector2(content.anchoredPosition.x, content.anchoredPosition.y + 25);
                }
            }
        }

    }
}
*/