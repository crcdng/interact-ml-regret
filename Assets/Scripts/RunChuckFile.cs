using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunChuckFile : MonoBehaviour
{
    void Start()
    {
        GetComponent<ChuckSubInstance>().RunFile("ChuckScript.ck", "0.4");
    }

}


