using JiangH.API;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using UnityUITable;

class PersonTableAvatarCell : StyleableTableCell<ButtonCellStyle>
{

	public PersonTableDialog.PersonView personView => obj as PersonTableDialog.PersonView;

	public Button button;
	public Text label;

	public GameObject prefabPersonDetail;

	bool subscribed = false;

	public override int GetPriority(MemberInfo member)
	{
		return 10;
	}

	public override bool IsCompatibleWithMember(MemberInfo member)
	{
		return (member.MemberType == MemberTypes.Field || member.MemberType == MemberTypes.Property || typeof(PersonTableDialog.PersonView).IsAssignableFrom(table.ElementType));
	}

	void Update()
	{
		if (!subscribed)
		{
			button.onClick.AddListener(OnButtonClicked);
			subscribed = true;
		}
	}

	public override void UpdateContent() 
	{
        if (property == null || property.IsEmpty)
            return;
        object o = property.GetValue(obj);
        if (o == null)
            label.text = "null";
        else if (Table.IsCollection(o.GetType()))
            label.text = string.Join(", ", (o as IEnumerable).OfType<object>().Select(obj => obj.ToString()).ToArray());
        else
            label.text = o.ToString();
    }

	protected virtual void OnButtonClicked()
	{
        var instance = (GameObject)Instantiate(prefabPersonDetail, Global.dialogRoot);

        instance.GetComponent<PersonDetail>().SetPerson(personView.person);
    }
}
