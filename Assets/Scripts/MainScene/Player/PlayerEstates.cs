using JiangH.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIWidgets;
using UnityEngine;
using UnityEngine.UI;

class PlayerEstates : RxMonoBehaviour
{
    public Button button;

    public Text Value;

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.estates.Count, Value);

        button.onClick.AddListener(ShowPersnDetailEstate);
    }

    private void ShowPersnDetailEstate()
    {
        var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);

        var personDetail = instance.GetComponent<PersonDetail>();
        personDetail.assocData = GSession.inst.player;

        personDetail.GetComponentInChildren<Tabs>().SetDefaultSelectedTab("拥有产业");
    }
}
