using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int level;
    public TextMesh textMesh;
    public bool isDragged = false;

    Vector2 difference = Vector2.zero;

    private void Start()
    {
        textMesh.text = level.ToString();
    }

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

    public void AddPoint(int levelAdd)
    {
        level += levelAdd;
        textMesh.text = level.ToString();
    }

}
