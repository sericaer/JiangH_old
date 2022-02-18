using JiangH.API;
using JiangH.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UIWidgets;
using UnityEngine;

class PersonDetailCommandPanel : RxMonoBehaviour
{
    public IPerson person;
    public ListViewPersonCommand commands;

    internal void SetPerson(IPerson person)
    {
        this.person = person;

        Action<IPersonCommand> onAddCommand = (item) =>
        {
            commands.DataSource.Add(item);
        };

        Action<IPersonCommand> onRemoveCommand = (item) =>
        {
            commands.DataSource.Remove(item);
        };

        dataBind.BindObservableCollection<IPersonCommand>(person.commands, onAddCommand, onRemoveCommand);
    }
}
