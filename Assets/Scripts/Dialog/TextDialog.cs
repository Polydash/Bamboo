using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class TextDialog : MonoBehaviour
{
    private void Start()
    {
        Text dialogText = GetComponent<Text>();
        string dialogString = dialogText.text;
        int index = dialogString.IndexOf("_");
        while(index >= 0)
        {
            dialogString = dialogString.Remove(index, 1);
            char letter = RetrieveActionChar((int) (dialogString[index] - '0'));
            dialogString = dialogString.Remove(index, 1);
            dialogString = dialogString.Insert(index, letter.ToString());
            index = dialogString.IndexOf("_");
        }
        dialogText.text = dialogString;
    }

    private char RetrieveActionChar(int index)
    {
        ShipControl shipControl = GameObject.FindWithTag("Ship").GetComponent<ShipControl>();
        return (char) shipControl.Controls[index].Keycode;
    }
}
