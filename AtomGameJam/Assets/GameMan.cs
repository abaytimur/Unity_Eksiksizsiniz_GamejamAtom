using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMan : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void Startt()
    {
        SceneManager.LoadScene("PlayScene");
    }
}
