using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersonCommandDetailPanel : MonoBehaviour
{
    public IPersonCommand command;
    public Action<IPersonCommand, bool> onCommandFinish;

    public Text title;

    public Button cancel;
    public Button confirm;

    // Start is called before the first frame update
    void Start()
    {
        title.text = command.key;

        cancel.onClick.AddListener(() =>
        {
            Destroy(this.gameObject);
            onCommandFinish?.Invoke(command, false);
        });

        confirm.onClick.AddListener(() =>
        {
            Destroy(this.gameObject);
            onCommandFinish?.Invoke(command, true);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
