using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
namespace hgcxt
{
    public class ToggleSc : MonoBehaviour
    {
        public static ToggleSc _Instance;
        public TextMeshProUGUI textMeshProUGUI;

        [SerializeField] int index = 0, Temp, Count, Lenght;
        public int ShowHowManyChar = 20;
        char[] ary;
        [SerializeField] bool full = false, FirstString = false;
        string c = "qwertyuiopasdfghjklzxcvbnmqwertyuiopqwertyuiopasdfghjklzxcvbnmqwertyuiopqwertyuiopasdfghjklzxcvbnmqwertyuiopqwertyuiopasdfghjklzxcvbnmqwertyuiop";
        // Start is called before the first frame update
        void Start()
        {
            textMeshProUGUI.text = "";
            ary = c.ToCharArray();
            Lenght = ary.Length;
            Count = (ary.Length < ShowHowManyChar) ? ary.Length : ShowHowManyChar;
            for (int i = index; i < Count; i++)
            {
                string s = ary[i].ToString();
                string temp = textMeshProUGUI.text;
                textMeshProUGUI.text = temp + s;
                Temp = i + 1;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                FirstString = false;
                if (full)
                {
                    print("已到文本最后");
                    return;
                }

                index = Temp;
                Count = (index > ary.Length) ? ary.Length : (Count + ShowHowManyChar);
                if (ary.Length - index < ShowHowManyChar)
                {
                    Count = ary.Length;
                    full = true;
                }
                textMeshProUGUI.text = "";
                for (int i = index; i < Count; i++)
                {
                    string temp = textMeshProUGUI.text;
                    string s = ary[i].ToString();
                    textMeshProUGUI.text = temp + s;
                    Temp = i + 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (FirstString)
                {
                    print("到达文本最前");
                    return;
                }
                full = false;
                index -= ShowHowManyChar;
                Count = index + ShowHowManyChar;
                Temp = Count;
                if (index <= 0)
                {
                    index = 0;
                    Temp = 0;
                    Count = ShowHowManyChar;
                    FirstString = true;
                }
                textMeshProUGUI.text = "";
                for (int i = index; i < Count; i++)
                {
                    string temp = textMeshProUGUI.text;
                    string s = ary[i].ToString();
                    textMeshProUGUI.text = temp + s;
                    Temp = i + 1;
                }
            }
        }
    }
}