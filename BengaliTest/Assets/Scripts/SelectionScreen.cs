using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectionScreen : MonoBehaviour
{
    [SerializeField] private TMP_InputField row, column;
    [SerializeField] private Button confirmBtn;

    void Update()
    {
        if (row.text != "" && column.text != "")
        {
            confirmBtn.gameObject.SetActive(true);
            int.TryParse(row.text, out int rowVal);
            int.TryParse(column.text, out int colVal);
            if(rowVal > 1 && rowVal < 7 && colVal > 1 && colVal < 7)
            {
                confirmBtn.gameObject.SetActive(true);
            }
            else
            {
                confirmBtn.gameObject.SetActive(false);
            }
        }
        else
        {
            confirmBtn.gameObject.SetActive(false);
        }
    }

    void OnDisable()
    {
        row.text = "";
        column.text = "";
    }

    public void SetGrid()
    {
        int.TryParse(row.text, out int rowVal);
        int.TryParse(column.text, out int colVal);
        Delegates.OnGameScreenOpened?.Invoke(rowVal, colVal);
    }
}
