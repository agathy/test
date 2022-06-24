using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move1 : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 a = new Vector3(+8f + 5.5f * Mathf.Cos(Mathf.PI / 2 - i / 50), -5 + 5.5f * Mathf.Sin(Mathf.PI / 2 - i / 50), -13.5f);
    
        transform.position = a;
        i++;
    }
}
