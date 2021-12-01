using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelChange : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject subPanel;
    public GameObject buttonPanel;
    public GameObject menuPanel;
    public ButtonController buttonCon;

    void Start()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        buttonPanel.SetActive(false);
        menuPanel.SetActive(false);
    }

    public void MainView()
    {
        mainPanel.SetActive(true);
        subPanel.SetActive(false);
        buttonPanel.SetActive(false);
        menuPanel.SetActive(false);
        buttonCon.returnFlag = false;
    }

    public void SubView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(true);
        buttonPanel.SetActive(false);
        menuPanel.SetActive(false);
        buttonCon.returnFlag = true;

    }

    public void ButtonView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        buttonPanel.SetActive(true);
        menuPanel.SetActive(false);
    }

    public void MenuView()
    {
        mainPanel.SetActive(false);
        subPanel.SetActive(false);
        buttonPanel.SetActive(false);
        menuPanel.SetActive(true);
    }

}