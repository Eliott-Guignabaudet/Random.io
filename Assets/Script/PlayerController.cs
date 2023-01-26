using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int level;
<<<<<<< HEAD
    public TextMesh textMesh;
    public bool isDragged = false;

    Vector2 difference = Vector2.zero;
=======
    public TextMeshProUGUI textMeshPro;

    public bool isDragged = false;

    Vector2 difference = Vector2.zero;

    Vector2 size;
>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c

    private void Start()
    {
        textMeshPro.text = level.ToString();
        size = GetComponent<CapsuleCollider2D>().size;
    }

    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        GameManager.instance.playerIsDragged = true;
        
        GetComponent<CapsuleCollider2D>().size = new Vector2(0.1f, 0.0001f);
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

<<<<<<< HEAD
    private void OnMouseDown()
    {
        difference = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - (Vector2)transform.position;
        isDragged = true;
    }

    private void OnMouseDrag()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition) - difference;
    }

    private void OnMouseUp()
    {
        isDragged = false;
    }



=======
    private void OnMouseUp()
    {
        GameManager.instance.playerIsDragged = false;
        GetComponent<CapsuleCollider2D>().size = size;

    }

    public void AddPoint(int levelAdd)
    {
        level += levelAdd;
        textMeshPro.text = level.ToString();
    }

>>>>>>> 5da9f10ef42fd16ebed43f6b50fe8895372c724c
}
