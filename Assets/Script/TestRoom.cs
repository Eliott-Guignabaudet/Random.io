using System.Collections;
using System.Collections.Generic;
<<<<<<< HEAD
=======
using Unity.VisualScripting;
>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
using UnityEngine;

public class TestRoom : MonoBehaviour
{
    [SerializeField]
    Transform _playerPosition;

    [SerializeField]
    Color _baseColor;

    [SerializeField]
    Color _enterColor;

<<<<<<< HEAD

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = _enterColor;
=======
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
>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
<<<<<<< HEAD
            if (!playerController.isDragged)
=======
            if (!GameManager.instance.playerIsDragged && playerInRoom)
>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
            {
                collision.transform.position = _playerPosition.position;
                GetComponent<SpriteRenderer>().color = _baseColor;
            }
<<<<<<< HEAD
            else
            {
=======
            else 
            { 
>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
                GetComponent<SpriteRenderer>().color = _enterColor;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
<<<<<<< HEAD
        GetComponent<SpriteRenderer>().color = _baseColor;
    }
=======
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = _baseColor;
            playerInRoom = false;
        }
    }


>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
}
