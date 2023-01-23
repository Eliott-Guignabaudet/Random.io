using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom : MonoBehaviour
{
    [SerializeField]
    Transform _playerPosition;

    [SerializeField]
    Color _baseColor;

    [SerializeField]
    Color _enterColor;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GetComponent<SpriteRenderer>().color = _enterColor;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerController playerController = collision.GetComponent<PlayerController>();
            if (!playerController.isDragged)
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
        GetComponent<SpriteRenderer>().color = _baseColor;
    }
}
