using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public int level;
    public TextMeshProUGUI textMeshPro;

    public bool isDragged = false;
    public Vector3 lastPos;

    

    Vector2 difference = Vector2.zero;

    Vector2 size;

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

    private void OnMouseUp()
    {
        StartCoroutine(UnDragPlayer());
    }

    public void AddPoint(int levelAdd)
    {
        level += levelAdd;
        textMeshPro.text = level.ToString();
    }

    System.Collections.IEnumerator UnDragPlayer()
    {
        GameManager.instance.playerIsDragged = false;
        GetComponent<CapsuleCollider2D>().size = size;
        yield return new WaitForSeconds(0.03f);
        transform.position = lastPos;
    }
}
