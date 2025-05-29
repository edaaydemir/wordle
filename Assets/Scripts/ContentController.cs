using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class ContentController : MonoBehaviour
{
	[SerializeField] private TMP_InputField inputField;
	[SerializeField] private Button temp;
	[SerializeField] private List<RowController> rows;
	[SerializeField] private WordManager wordManager;

	private int _index;

	private void Start()
	{
		inputField.onValueChanged.AddListener(OnUpdateContent);
		inputField.onSubmit.AddListener(OnSubmit);
	}

	private void OnUpdateContent(string message)
	{
		var row = rows[_index];
		row.UpdateText(message);
	}

	private bool UpdateState()
	{
		var states = wordManager.GetStates(inputField.text);
        //Debug.Log("wordmanager getstates çalýþýyor mu");
        rows[_index].UpdateState(states);

		foreach (var state in states)
		{
			if (state != State.Correct)
				return false;
		}
        return true;

	}

	private void OnSubmit(string msg)
	{
		temp.Select();
		inputField.Select();

		if (!IsEnough())
		{
			Debug.Log("UNFIT...");
			return;
		}

		var isWin = UpdateState();
        //Debug.Log(" contentcontrollerdaki updatestate calýþýyor mu");

        if (isWin)
		{
			Debug.Log("YOU WIN...");
			inputField.enabled = false;
			return;
		} 

		_index++;
		var isLost = _index == rows.Count;
		if (isLost)
		{
			Debug.Log("YOU LOSE!");
			inputField.enabled = false;
			return;
		} 

		inputField.text = "";
	}

	private bool IsEnough()
	{
        //Debug.Log("ýsenough çalýþýyor mu");
        return inputField.text.Length == rows[_index].CellAmount;
	}
}