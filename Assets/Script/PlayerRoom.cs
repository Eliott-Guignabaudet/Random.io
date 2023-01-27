using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRoom : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private Transform PlayerPosition;


    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().lastPos= PlayerPosition.position;
        player.transform.position = PlayerPosition.position;
    }

}
