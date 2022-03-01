using JiangH.Runtime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;

class PlayerMoney : RxMonoBehaviour
{
    public Button button;

    public Text Value;

    // Start is called before the first frame update
    void Start()
    {
        dataBind.BindText(GSession.inst, x => x.player.money, Value);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
