using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellController : MonoBehaviour
{
    [SerializeField] private Color colorNone;
    [SerializeField] private Color colorExist;
    [SerializeField] private Color colorCorrect;
    [SerializeField] private Color colorFail;

    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI text;

    public void UpdateText(char message)
    {
        text.SetText(message.ToString());
    }

    public void UpdateState(State state)
    {
        //Debug.Log("cell controllerdaki updatestate çalýþýyor mu");
        background.color = GetColor(state);
    }

    private Color GetColor(State state)
    {
        return state switch
        {
            State.None => colorNone,
            State.Contain => colorExist,
            State.Correct => colorCorrect,
            State.Fail => colorFail,
        };
    }
}

public enum State
{
    None,
    Contain,
    Correct,
    Fail
}