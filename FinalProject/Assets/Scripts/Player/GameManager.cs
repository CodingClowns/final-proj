using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    [SerializeField] private Text textmeshPro;
    void Start()
    {
        textmeshPro = FindObjectOfType<Text>();
    }
    void Update()
    {
        textmeshPro.text = "Score: " + score;
    }
}
