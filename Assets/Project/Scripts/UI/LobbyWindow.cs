using UnityEngine;
using UnityEngine.UI;
using Zenject;
using TMPro;
using System;
using Mirror;

public class LobbyWindow : BaseWindow
{
    [Inject]
    private ConnectionManager connectionManager;
   
    [Inject]
    private NetworkManager _networkManager;

    [Header("Find")]
    [SerializeField]
    private Button buttonCreate;

    [Header("Find")]
    [SerializeField]
    private Button buttonFind;
    [SerializeField]
    private TMP_InputField uriInput;

    [Header("Connect")]
    [SerializeField]
    private Button buttonConnect;

    private string _networkAddress;

    public override void Init()
    {
        base.Init();

        buttonCreate.onClick.AddListener(ClickCreate);
        buttonConnect.onClick.AddListener(ClickConnect);
        buttonFind.onClick.AddListener(ClickFind);

 
        uriInput.onValueChanged.AddListener(CheckHostUri);
        uriInput.text = _networkManager.networkAddress;
    }

    private void ClickCreate()
    {
        connectionManager.StartHost();
    }

    private void ClickConnect()
    {   
        connectionManager.Connect(_networkAddress);
    }

    private void ClickFind()
    {
        connectionManager.FindServer();
    }

    private void CheckHostUri(string text)
    {
        _networkAddress = text;

        buttonConnect.interactable = !string.IsNullOrEmpty(_networkAddress); ;
    }

}
