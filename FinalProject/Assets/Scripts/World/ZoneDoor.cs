using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Collider2D))]
/// <summary>
/// Creates a trigger which, when entered, loads the next zone.
/// </summary>
public class ZoneDoor : MonoBehaviour
{
    [Tooltip("The zone to load.")]
    [SerializeField] private string nextScene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(nextScene, LoadSceneMode.Single);
        }
    }
}
