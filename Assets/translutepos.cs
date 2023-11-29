using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translutepos : MonoBehaviour
{
    public enum pos { a, b }
    public pos p;

    private void OnEnable()
    {
        print("1111");
        print(translute.instance.pos);
    }

}
