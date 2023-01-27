using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnnemyController : MonoBehaviour
{
    public int levelEnnemy;
    public TextMeshProUGUI textMesh;

    // Start is called before the first frame update
    void Awake()
    {
        textMesh.text = levelEnnemy.ToString();
    }
}
