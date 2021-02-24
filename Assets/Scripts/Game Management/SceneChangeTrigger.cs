using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField] int targetSceneIndex;

   public void ChangeScene()
    {
        SceneManager.LoadScene(targetSceneIndex);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeScene();
    }

}
