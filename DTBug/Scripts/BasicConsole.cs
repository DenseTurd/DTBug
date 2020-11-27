using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
[RequireComponent(typeof(TMP_Text))]
[RequireComponent(typeof(IFormatter))]
public class BasicConsole : MonoBehaviour,IConsole
{
    public TMP_Text textPrefab;

    public KeyCode openCloseKey = KeyCode.Tab;

    public RectTransform content;
    public ScrollRect scrollRect;

    
    public IFormatter formatter;

    bool scrollRequired;
    float scrollTimer;
    public void Init()
    {
        formatter = GetComponent<IFormatter>();
        formatter.Init();

        //Debug.Log("DTBug console initialised");
    }

    public void AddLine(LogType type, string line)
    {
        var prefab = Instantiate(textPrefab, content);
        prefab.text = formatter.Format(type, line);
        EraseOldLogs();
        scrollRequired = true;
    }

    void EraseOldLogs()
    {
        if (content.childCount > 100)
        {
            for (int i = 0; i < 10; i++)
            {
                Destroy(content.GetChild(i).gameObject);
            }
        }
    }

    void ScrollToBottom()
    {
        scrollRect.verticalNormalizedPosition = 0;
    }

    void Update()
    {
        if (Input.GetKeyDown(openCloseKey))
        {
            if (scrollRect.gameObject.activeSelf)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        if (scrollRequired)
        {
            scrollTimer -= Time.deltaTime;

            if(scrollTimer <= 0)
            {
                ScrollToBottom();
                scrollRequired = false;
                scrollTimer = 0.1f;
            }
        }
    }

    void Hide()
    {
        scrollRect.gameObject.SetActive(false);
    }
    void Show()
    {
        scrollRect.gameObject.SetActive(true);
        scrollRequired = true;
    }
}
