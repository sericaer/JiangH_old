using System;
using UnityEngine;

public class MainScene : MonoBehaviour
{
    public Canvas uiCanvas;

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
