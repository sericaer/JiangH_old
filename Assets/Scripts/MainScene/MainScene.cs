using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Canvas uiCanvas;
    public Button exitButton;

    void Awake()
    {
        Global.dialogRoot = uiCanvas.transform;
    }

    void OnDestroy()
    {
        Global.dialogRoot = null;
    }

    // Start is called before the first frame update
    void Start()
    {
        exitButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene(nameof(InitScene));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class Global
{
    public static Transform dialogRoot { get; set; }

}
