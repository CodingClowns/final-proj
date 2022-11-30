using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class SceneTransition : MonoBehaviour
{
    [SerializeField] private SceneName sceneNameToGoTo = SceneName.TinScene_Demo;
    [SerializeField] private Vector3 scenePositionToGoTo = new Vector3();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player player = collision.GetComponent<Player>();

        /*
        if (player != null)
        {
            // player.transform.position = new Vector3(scenePositionToGo.x, scenePositionToGo.y, 0.0f);
            SceneGameManager.Instance.FadeAndLoadScene(sceneNameToGoTo.ToString(), scenePositionToGoTo);
        }
        */
    }
}
