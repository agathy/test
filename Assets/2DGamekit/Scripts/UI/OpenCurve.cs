using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{


    public class OpenCurve : MonoBehaviour
    {
        [SerializeField]
        public AnimationCurve animationCurve;
        float output;
        public float speed;
        private float PosX=400;
        float startTime;
        // Start is called before the first frame update


        private void OnEnable()
        {
            startTime = Time.time;
        
            // PosX = 100;
        }


        // Update is called once per frame
        void Update()
        {
           
            output = animationCurve.Evaluate((Time.time-startTime)* speed) * 1f;

            this.GetComponent<RectTransform>().position = new Vector3(2320 - output * PosX, transform.position.y, transform.position.z);
            print(this.GetComponent<RectTransform>().position);
            // this.transform.position = new Vector3(1000-output * PosX, transform.position.y, transform.position.z);
            if (output == 1)
            {
            //    Time.timeScale = 0;
            }
        }
    }
}
