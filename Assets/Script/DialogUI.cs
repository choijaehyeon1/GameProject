using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{    
    public static void Show(string contentString, string button1Text, UnityAction button1Action = null, string button2Text = null, UnityAction button2Action = null, string button3Text = null, UnityAction button3Action = null)
    {
        var scene = SceneManager.GetSceneByName("Dialog");
        if (scene.isLoaded)
            Close();

        SceneManager.LoadScene("Dialog", LoadSceneMode.Additive);
        string[] texts = new string[] { button1Text, button2Text, button3Text };
        UnityAction[] actions = new UnityAction[] { button1Action, button2Action, button3Action };

        dialogParams = new DialogParams(contentString, texts, actions);
    }

    public static void Close()
    {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName("Dialog"));
    }

    struct DialogParams
    {
        public string contentString;
        public string[] buttonTexts;
        public UnityAction[] actions;

        public DialogParams(string contentString, string[] buttonTexts, UnityAction[] actions)
        {
            this.contentString = contentString;
            this.buttonTexts = buttonTexts;
            this.actions = actions;
        }
    }

    static DialogParams dialogParams;

    //========================================================

    [SerializeField]
    Text content;

    [SerializeField]
    Text[] texts;

    [SerializeField]
    Button[] buttons;

    public void Start()
    {
        content.text = dialogParams.contentString;

        bool isVisibleButton = false;
        for (int i = 0; i < buttons.Length; i++)
        {
            isVisibleButton = dialogParams.buttonTexts[i] != null; 
            buttons[i].gameObject.SetActive(isVisibleButton);
            if (!isVisibleButton)
                continue;

            texts[i].text = dialogParams.buttonTexts[i];
            if (dialogParams.actions[i] != null)
                buttons[i].onClick.AddListener(dialogParams.actions[i]);
            buttons[i].onClick.AddListener(Close);
        }

    }

}
