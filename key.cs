using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class key : MonoBehaviour
{
    public Text qText;

    public string q = ("#include <stdio.h>\r\nint main() {\r\n    int num;\r\n    printf(\"Enter an integer: \");\r\n    scanf(\"%d\", &num);\r\n\r\n    // true if num is perfectly divisible by 2\r\n    if(num % 2 == 0)\r\n        printf(\"%d is even.\", num);\r\n    else\r\n        printf(\"%d is odd.\", num);\r\n    \r\n    return 0;\r\n}");
    private void Start()
    {
        qText.text = q;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("enter");
        }
            
        
    }
}
