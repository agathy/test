using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class GuideCanvasController : MonoBehaviour
    {
        public static int flag;
        private bool flag2;
        public GameObject GuideIcon;
        // Start is called before the first frame update

        private void Awake()
        {
            flag = 0;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (GuideIcon != null)
            {
                if (flag==2)
                {
                    GuideIcon.SetActive(true);
                    //   StartCoroutine("ShowGuide");
                    flag = 3;
                }
            }
            
        }
        IEnumerator ShowGuide()
        {
            GuideIcon.SetActive(true);
            yield return new WaitForSeconds(5);
            Destroy(GuideIcon);
            StopCoroutine("ShowGuide");
        }
    }
}
