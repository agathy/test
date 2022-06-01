using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class SetMaterialRenderQueue : MonoBehaviour {

        public Material material;
        public int queueOverrideValue;

        void Start ()
        {
            material.renderQueue = queueOverrideValue;
        }
	
	
    }
}