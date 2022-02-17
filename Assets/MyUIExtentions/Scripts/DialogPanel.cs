using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[AddComponentMenu("UI/MyUIExtentions/DialogPanel")]
public class DialogPanel : MonoBehaviour
{
    internal static GameObject CreateGameObject()
    {
        
        GameObject instance = (GameObject)Instantiate(Resources.Load("DialogPanel"));
        return instance;
    }

    public Button closeButton;

    
    [HideInInspector]
    public bool isMode 
    {
        get
        {
            return backgroundObject != null;
        }
        set
        {
            if(value == isMode)
            {
                return;
            }

            if(value)
            {
                backgroundObject = CreatePanel();
                backgroundObject.name = "Background";

                backgroundObject.transform.SetParent(this.transform.parent);
                var backgroundRectTransform = backgroundObject.GetComponent<RectTransform>();

                backgroundRectTransform.anchorMin = Vector2.zero;
                backgroundRectTransform.anchorMax = Vector2.one;
                backgroundRectTransform.sizeDelta = Vector2.zero;
                backgroundRectTransform.anchoredPosition = Vector2.zero;

                this.transform.SetParent(backgroundObject.transform);
            }
            else
            {
                this.transform.SetParent(backgroundObject.transform.parent);
                backgroundObject.transform.SetParent(null);

#if UNITY_EDITOR
                DestroyImmediate(backgroundObject);
#else
                Destroy(backgroundObject);
#endif
            }

            Debug.Log(isMode);
        }
    }

    private GameObject CreatePanel()
    {
        GameObject panel = new GameObject("Panel");
        Image i = panel.AddComponent<Image>();

        var color = i.color;
        color.a = 0.25f;
        i.color = color;

        return panel;
    }

    [HideInInspector]
    [SerializeField]
    private GameObject backgroundObject;

    // Start is called before the first frame update
    void Start()
    {
        closeButton.onClick.AddListener(() =>
        {
            if(backgroundObject != null)
            {
                Destroy(backgroundObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        });
    }

    // Update is called once per frame
    void Update()
    {

    }
}