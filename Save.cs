using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Save : MonoBehaviour
{
    public TMP_InputField inputField;
    public void SaveData()
    {
        PlayerPrefs.SetString("Input", inputField.text);
    }

    public void LoadData()
    {
        inputField.text = PlayerPrefs.GetString("Input");
    }
    
    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Input");
    }
}
