using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuManager : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
