using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour
{
    [SerializeField] private List<CellController> cells;
    public int CellAmount => cells.Count;


    public void UpdateText(string message)
    {
        var arrayChar = message.ToCharArray();
        for (int i = 0; i < cells.Count; i++)
        {
            var cell = cells[i];

            bool isExist = i < arrayChar.Length;
            var content = isExist ? arrayChar[i] : ' ';
            cell.UpdateText(content);
        }
    }

    public void UpdateState(List<State> states)
    {
        //Debug.Log("row controllerdaki updatestate çalýþýyor mu");

        for (int i = 0; i < states.Count; i++)
        {
            var cell = cells[i];
            var state = states[i];
            cell.UpdateState(state);
        }
    }
}