using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    public int levelEnnemy;
    public TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh.text = levelEnnemy.ToString();
    }
}
