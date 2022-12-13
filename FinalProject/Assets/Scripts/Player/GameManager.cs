using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI textmeshPro;
    void Start()
    {
        
    }
    void Update()
    {
        textmeshPro.text = ": " + score;
    }
}
