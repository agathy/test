using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace hgcxt
{
    public class LayerController : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            gameObject.GetComponent<SpriteRenderer>().sortingOrder = -(int)(transform.position.y *3);
        }
    }
}
