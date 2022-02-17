using JiangH.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InitScene : MonoBehaviour
{
    public Button newGame;

    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(() =>
        {
            GSession.inst = GSession.Builder.Build();

            SceneManager.LoadScene(nameof(MainScene));
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
