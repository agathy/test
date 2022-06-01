using System;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    [CreateAssetMenu]
    public class ClueMessage : ScriptableObject
    {
        //public string language;
        public List<Clues> clues = new List<Clues>();

        public string this[string key]
        {
            get
            {
                for (int i = 0; i < clues.Count; i++)
                {
                    if (clues[i].key == key)
                        return clues[i].value;
                }

                return "Key not found.";
            }
        }
    }

    [Serializable]
    public class Clues
    {
        public string key;
        public string value;
    }
}