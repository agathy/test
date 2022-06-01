using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
namespace hgcxt
{

    public class EllenDialogue : MonoBehaviour
    {
        public UnityEvent OnStart;
        public GameObject blackSreen;
        public static EllenDialogue Instance;
        emituofoConf emituofoconf;

        bool IsAutomaticSpeaking;

        NPCConf npcConf;

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
            blackSreen.SetActive(true);
            npcConf = Resources.Load<NPCConf>("Conf/" + "Ö÷½Ç");
            npcConf.State = 0;
            npcConf.isUnlock = false;
            IsAutomaticSpeaking = true;
            PlayerInput.Instance.Horizontal.Disable();
            PlayerInput.Instance.Vertical.Disable();
            OnStart.Invoke();
            //   DialogueCanvasController.Instance.ActivateCanvasWithText("Ö÷½Ç");
        }

        // Update is called once per frame
        void Update()
        {
            if (IsAutomaticSpeaking)
            {
                if (PlayerInput.Instance.Interact.Down)
                {
                    
                
                    OnStart.Invoke();
                }
            }
        } /// <summary>
          /// ºÚÆÁ
          /// </summary>
        public void ScreenEF(bool black)
        {
            StartCoroutine(DoScreenEF(black));     
        }


        /// <summary>
        /// ×ÔÑÔ×ÔÓï
        /// </summary>
        public void AutoSpeaking(bool flag)
        {
            IsAutomaticSpeaking = flag;
        }
        /// <summary>
        /// °¢ÃÖÍÓ·ð
        /// </summary>
        /// <param name="name"></param>
        /// <param name="index"></param>
        public void test(string name, int index)
        {
            print("ÀÇÄ©");
           
            print(emituofoconf.name);

            if (name == "¿×È¸°¸")
            {
                emituofoconf.test[0].XianSuo[index].jiesuo=true;
            }
            else if (name == "È¡ÎÞ¸ùË®")
            {
                emituofoconf.test[1].XianSuo[index].jiesuo=true;
            }
            else if (name == "ÕªÐÇÀÖ¸®")
            {
                emituofoconf.test[2].XianSuo[index].jiesuo=true;
            }

        }
        private IEnumerator DoScreenEF(bool black)
        {
            if (black)
            {
                blackSreen.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(false);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(false);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(true);
                PlayerInput.Instance.Horizontal.Disable();
                PlayerInput.Instance.Vertical.Disable();
            }
            else
            {
                blackSreen.SetActive(false);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(false);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(true);
                yield return new WaitForSeconds(0.15f);
                blackSreen.SetActive(false);
                PlayerInput.Instance.Horizontal.Enable();
                PlayerInput.Instance.Vertical.Enable();
            }
        }
   
    
    
    
    
    }
}

