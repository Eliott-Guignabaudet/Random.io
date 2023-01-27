using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int level;
    public TextMesh textMesh;

    private void Start()
    {
        textMesh.text = level.ToString();
   
    }
}
