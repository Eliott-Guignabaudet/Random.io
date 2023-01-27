using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    Animator _animator;
    public bool playerIsDragged;
    public bool playerInRoom;
    public int enemysCount;

    private void Awake()
    {
        // A : Je m'initialise
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    private void Update()
    {
        if (enemysCount <= 0)
        {
            _animator.SetTrigger("OnWin");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
