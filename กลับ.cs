using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class กลับ : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene("Manu");
    }
}
