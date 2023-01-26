using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TestRoom : MonoBehaviour
{
    [SerializeField]
    Transform _playerPosition;

    [SerializeField]
    Color _baseColor;

    [SerializeField]
    Color _enterColor;

    private bool playerInRoom;
    public GameObject player;

    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.instance.playerIsDragged)
        {
            GetComponent<SpriteRenderer>().color = _enterColor;
            playerInRoom = true;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (!GameManager.instance.playerIsDragged && playerInRoom)
            {
                collision.transform.position = _playerPosition.position;
                GetComponent<SpriteRenderer>().color = _baseColor;
            }
            else 
            { 
                GetComponent<SpriteRenderer>().color = _enterColor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = _baseColor;
            playerInRoom = false;
        }
    }


}
