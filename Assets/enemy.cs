using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public staes a;
    // Start is called before the first frame update
    void Start()
    {
        a = new A();
        a.onenter();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
