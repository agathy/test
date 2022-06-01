using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
namespace hgcxt {
    public class emituofo : MonoBehaviour
    {
        public static emituofo Instance;
        // Start is called before the first frame update
        private void Awake()
        {
            Instance = this;
        }
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
           
                
            emituofoConf conf = Resources.Load<emituofoConf>("Emituofo");
            conf = Resources.Load<emituofoConf>("Emituofo");
            for (int i = 0; i < conf.test.Count; i++)
            {
                for (int j = 0; j < conf.test[i].XianSuo.Count; j++)
                {
                    if (conf.test[i].XianSuo[j].jiesuo)
                    {
                        string way = conf.test[i].anzi + "/Image/" + j.ToString();
                        print(way);
                        transform.Find(way).GetComponent<TextMeshProUGUI>().text= conf.test[i].XianSuo[j].content;
                /*        Transform a = transform.Find(conf.test[i].anzi);
                        print(a.name+j);
                        Transform b = .Find(j.ToString());

                        print(b.name);
                        b.GetComponent<TextMeshProUGUI>().text = ;*/
                    }
                }
            }
            print(conf.name);

         
                
                
           
        }
       
    }
}