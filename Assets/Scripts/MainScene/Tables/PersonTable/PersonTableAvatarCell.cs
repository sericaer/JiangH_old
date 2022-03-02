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

	public PersonTable.PersonView personView => obj as PersonTable.PersonView;

	public Button button;
	public Text label;

	public GameObject prefabPersonDetail;

	bool subscribed = false;

	private IPerson person;

	public override int GetPriority(MemberInfo member)
	{
		return 10;
	}

	public override bool IsCompatibleWithMember(MemberInfo memberInfo)
	{
		switch(memberInfo)
        {
			case FieldInfo field:
				return typeof(IPerson).IsAssignableFrom(field.FieldType);
			case PropertyInfo property:
				return typeof(IPerson).IsAssignableFrom(property.PropertyType);
			default:
				return false;
        }
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
        {
			return;
		}
            
        object o = property.GetValue(obj);
        if (o == null)
        {
			label.text = "null";
			return;
		}

		person = o as IPerson;
		label.text = person.name;
	}

	protected virtual void OnButtonClicked()
	{
        var instance = (GameObject)Instantiate(prefabPersonDetail, Global.dialogRoot);

        instance.GetComponent<PersonDetail>().assocData = person;
    }
}
