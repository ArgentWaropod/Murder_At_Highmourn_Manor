using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameManager : MonoBehaviour
{

    public static NameManager save_Names;
    public TMP_InputField inputField;
    public string userName;

    private void Awake()
    {
        if (save_Names == null)
        {
            save_Names = this;
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (userName != inputField.text)
        {
            userName = inputField.text;
        }
    }
}