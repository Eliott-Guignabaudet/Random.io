using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomController : MonoBehaviour
{
    public PlayerController playerController; 
    public EnnemyController[] ennemyController; //potentiellemnt une variable a ajouté pour les items et mettre une liste d'ennemy
    private int _newLevel;
   /* private bool _ennemyInRoom = false;
    private bool _itemInRoom = false;*/


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Test");
        /*if (collision.CompareTag("Ennemy"))
        {
            _ennemyInRoom = true;
        }*/
        if (collision.CompareTag("Player"))
        {
            for (int i = 0; i < ennemyController.Length; i++)
            {
                Debug.Log(ennemyController[i].levelEnnemy);

                if (playerController.level > ennemyController[i].levelEnnemy)
                {
                    _newLevel = playerController.level + ennemyController[i].levelEnnemy;
                    playerController.textMeshPro.text = _newLevel.ToString();
                    playerController.level = _newLevel;
                    Destroy(ennemyController[i].gameObject); // Remplacer par une animation plus tard 
                }
                else
                {
                    Destroy(collision.gameObject); // peut afficher à la place la lose scène
                }
            }

            Debug.Log("Player in room with Ennemy");
        }
        
    }

}
