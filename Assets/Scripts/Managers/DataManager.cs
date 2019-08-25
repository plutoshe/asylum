using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;

public class DataManager : Singleton<DataManager>
{
    public DialogManager dialog;

    // Start is called before the first frame update
    DataManager()
    {
        dialog = new DialogManager();
    }

    private void Awake()
    {
        dialog.Load("Assets/Resources/Data/dialog_test.xml");
    }

    private void Update()
    {
    }

}
