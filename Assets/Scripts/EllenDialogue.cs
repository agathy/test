using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
namespace hgcxt
{

    public class EllenDialogue : MonoBehaviour
    {
        public UnityEvent OnStart;
       // public GameObject blackSreen;
        public static EllenDialogue Instance;
        public GameObject AnimationCanvas;


       
        emituofoConf emituofoconf;

        public static bool IsAutomaticSpeaking;

        NPCConf npcConf;
        GameObject Yun;
        // Start is called before the first frame update
        private void Awake()
        {
             Instance = this;
        }
        void Start()
        {
            emituofoconf = Resources.Load<emituofoConf>("Emituofo");
            for (int i = 0; i < emituofoconf.test.Count; i++)
            {
                for (int j = 0; j < emituofoconf.test[i].XianSuo.Count; j++)
                {
                    emituofoconf.test[i].XianSuo[j].jiesuo = false;
                }
            }
            //blackSreen.SetActive(true);
            npcConf = Resources.Load<NPCConf>("Conf/" + "����");
            npcConf.State = 0;
            npcConf.isUnlock = false;
            IsAutomaticSpeaking = false;
            PlayerInput.Instance.Horizontal.Disable();
            PlayerInput.Instance.Vertical.Disable();
           // OnStart.Invoke();
            //   DialogueCanvasController.Instance.ActivateCanvasWithText("����");
        }

        // Update is called once per frame
        void Update()
        {
           // print(Yun.name);
            //print(Yun.transform.GetComponent<Image>().sprite.name);
            if (IsAutomaticSpeaking)
            {
                if (PlayerInput.Instance.Interact.Down)
                {
                      
                    OnStart.Invoke();
                }
            }
        } /// <summary>
          /// ����
          /// </summary>
        public void ScreenEF(bool black)
        {
            StartCoroutine(DoScreenEF(black));     
        }


        /// <summary>
        /// ��������
        /// </summary>
        public void AutoSpeaking(bool flag)
        {
            IsAutomaticSpeaking = flag;
        }
        /// <summary>
        /// �����ӷ�
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        public void test(string name, int index)
        {  
            print(emituofoconf.name);

            if (name == "��ȸ��")
            {
                emituofoconf.test[0].XianSuo[index].jiesuo=true;
            }
            else if (name == "ȡ�޸�ˮ")
            {
                emituofoconf.test[1].XianSuo[index].jiesuo=true;
            }
            else if (name == "ժ���ָ�")
            {
                emituofoconf.test[2].XianSuo[index].jiesuo=true;
            }

        }
        private IEnumerator DoScreenEF(bool black)
        {
            if (black)
            {
              
                PlayerInput.Instance.Horizontal.Disable();
                PlayerInput.Instance.Vertical.Disable();
            }
            else
            {
                //blackSreen.SetActive(false);
                //yield return new WaitForSeconds(0.15f);
                //blackSreen.SetActive(true);
                //yield return new WaitForSeconds(0.15f);
                //blackSreen.SetActive(false);
                //yield return new WaitForSeconds(0.15f);
                //blackSreen.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                //blackSreen.SetActive(false);
                PlayerInput.Instance.Horizontal.Enable();
                PlayerInput.Instance.Vertical.Enable();
            }
        }

        public void AnimationPlayEvent(string name)
        {
            StartCoroutine("AnimationPlay",name);
           

        }
        private IEnumerator AnimationPlay(string name)
        {
            yield return new WaitForSeconds(1);
            GameObject AnimationItem = Resources.Load<GameObject>("AnimationItem/" + name);
            Yun=Instantiate(AnimationItem, AnimationCanvas.transform);
  /*          int i = 0;
            while (Yun.transform.GetComponent<Image>().sprite.name != "��_00071")
            {
                i++;
              
                
                yield return new WaitForEndOfFrame();
              
            }
  */         /* npcConf.State = 1;
            IsAutomaticSpeaking = true;*/
//            Yun.SetActive(false);

//            DialogueCanvasController.Instance.ActivateCanvasWithText("����");
            /*   while (Yun.transform.GetComponent<Image>().color.a == 1)
               {
                   print("0");
                   npcConf.State = 1;
                   DialogueCanvasController.Instance.ActivateCanvasWithText("����");
               }*/
          //npcConf.State = 1;
          //  DialogueCanvasController.Instance.ActivateCanvasWithText("����");
            StopCoroutine("AnimationPlay");
        }

        
    }
}

