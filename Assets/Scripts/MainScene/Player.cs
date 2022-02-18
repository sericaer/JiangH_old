using JiangH.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

class Player : RxMonoBehaviour
{
    public Button button;

    public Text Name;

    public GameObject prefabs;

    // Start is called before the first frame update
    void Start()
    {

        dataBind.BindText(GSession.inst, x => x.player.name, Name);

        button.onClick.AddListener(() =>
        {
            var instance = (GameObject)Instantiate(prefabs, Global.dialogRoot);

            instance.GetComponent<PersonDetail>().SetPerson(GSession.inst.player);
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}