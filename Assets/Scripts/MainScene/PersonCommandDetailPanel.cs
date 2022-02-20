using JiangH.API;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

class PersonCommandDetailPanel : RxMonoBehaviour
{
    public IPersonCommand command;
    public Action<bool, IPersonCommand, IEnumerable<ICommandTarget>> onPanelExit;

    public Text title;

    public ListViewCommandTagert tagertlistView;

    public Button cancel;
    public Button confirm;

    private List<ICommandTarget> selectedTargets = new List<ICommandTarget>();

    // Start is called before the first frame update
    void Start()
    {
        selectedTargets.Clear();
        confirm.interactable = false;

        title.text = command.key;

        cancel.onClick.AddListener(OnCancel);

        confirm.onClick.AddListener(OnConfirm);

        tagertlistView.OnSelectStateChanegd = OnTargetSelectStateChanegd;

        if(command.targets != null)
        {
            foreach (var target in command.targets)
            {
                tagertlistView.Add(target);
            }
        }

    }

    private void OnTargetSelectStateChanegd(ICommandTarget target, bool isSelected)
    {
        if(isSelected)
        {
            selectedTargets.Add(target);
            confirm.interactable = true;
        }
        else
        {
            selectedTargets.Remove(target);
            if(!selectedTargets.Any())
            {
                confirm.interactable = false;
            }
        }
    }

    private void OnConfirm()
    {
        Destroy(this.gameObject);
        onPanelExit?.Invoke(true, command, selectedTargets);
    }

    private void  OnCancel()
    {
        Destroy(this.gameObject);

        onPanelExit?.Invoke(false, command, selectedTargets);
    }
}
