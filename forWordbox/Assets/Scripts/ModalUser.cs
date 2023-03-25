using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Gui;
public class ModalUser : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Name;
    public Text Age;
    public Text City;
    public Text Mail;
    public Text Gender;
    [SerializeField]LeanWindow modalWindow;
    public Image BigPic;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void popUp() {

        modalWindow.On = true;

    
    }
}
