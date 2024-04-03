using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Home1 : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene("Manu");
    }
}
