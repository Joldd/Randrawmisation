using TMPro;
using UnityEngine;

public class copy : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] GameObject msg;
    bool isMsg;
    float timerMax = 2f;
    float timer;

    private void Start()
    {
        msg.SetActive(false);
        timer = timerMax;
    }

    public void copySeed()
    {
        TextEditor textEditor = new TextEditor();
        textEditor.text = text.text;
        textEditor.SelectAll();
        textEditor.Copy();
        msg.SetActive(true);
        isMsg = true;
    }

    private void Update()
    {
        if (isMsg)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                isMsg = false;
                msg.SetActive(false);
                timer = timerMax;
            }
        }
    }
}
