using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.UI;
public class GoonbtnClick : MonoBehaviour {

    public Button button_nextScene;
     
    void Start()
    {
        button_nextScene.onClick.AddListener(nextScene);
    }
    public void nextScene()
    {
        EditorSceneManager.LoadScene(1);
    }
}
