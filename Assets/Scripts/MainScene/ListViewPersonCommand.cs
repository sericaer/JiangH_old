using JiangH.API;
using System;
using UIWidgets;

class ListViewPersonCommand : ListViewCustom<ListViewPersonCommandItem, IPersonCommand>
{
    public Action<IPersonCommand> OnSelectCommand;
}
