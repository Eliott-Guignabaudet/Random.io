using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRoom : MonoBehaviour
{
    [SerializeField]
    Transform _playerPosition;
    
    [SerializeField]
    Transform _ennemyPosition1;
    [SerializeField]
    Transform _ennemyPosition2;

    [SerializeField]
    Animator animator;

    [SerializeField]
    Color _baseColor;

    [SerializeField]
    Color _enterColor;

    [SerializeField]
    private bool playerInRoom;
    public GameObject player;
    public EnnemyController[] ennemyController;

    private bool isFighting;
    private void Start()
    {
        isFighting= false;
        player = GameObject.FindGameObjectWithTag("Player");
        ennemyController[0].transform.position = _ennemyPosition1.position;
        if (ennemyController.Length > 1)
        {
            ennemyController[0].transform.position = _ennemyPosition2.position;
            ennemyController[1].transform.position= _ennemyPosition1.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && GameManager.instance.playerIsDragged)
        {
            GetComponent<SpriteRenderer>().color = _enterColor;
            playerInRoom = true;
            animator.SetTrigger("OnAttack");
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
                if (!isFighting)
                {
                    Fight();
                    isFighting= true;
                }
                
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

    private void Fight()
    {
        Debug.Log(ennemyController.Length);
        for (int i = 0; i < ennemyController.Length; i++)
        {
            PlayerController playerController = player.GetComponent<PlayerController>();
            Debug.Log(playerController.level);
            if (playerController.level > ennemyController[i].levelEnnemy)
            {
                playerController.level += ennemyController[i].levelEnnemy;
                playerController.textMeshPro.text = playerController.level.ToString();
                Destroy(ennemyController[i].gameObject); // Remplacer par une animation plus tard 
            }
            else
            {
                Destroy(player); // peut afficher à la place la lose scène
            }
        }
    }


}
