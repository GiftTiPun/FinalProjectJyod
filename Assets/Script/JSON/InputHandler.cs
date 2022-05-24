using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputHandler : MonoBehaviour
{
    [SerializeField] InputField nameInput;
    [SerializeField] public string filename;

    List<InputEntry> entries = new List<InputEntry>();

    public void AddnameToList()
    {
        entries.Add(new InputEntry(nameInput.text));
        nameInput.text = "";

        FileHandler.SaveToJson<InputEntry>(entries,filename);
    }
}
