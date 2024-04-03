using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backto02 : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {

        SceneManager.LoadScene("page02");
    }
}
