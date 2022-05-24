using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VivoxUnity;
using System.ComponentModel;
using System;
using UnityEngine.UI;
using TMPro;

public class LoginCredential : MonoBehaviour
{
    VivoxUnity.Client client;
    private Uri server = new Uri("https://unity.vivox.com/appconfig/18967-final-47784-udash");
    private string issuer = "18967-final-47784-udash";
    private string domain = "mtu1xp.vivox.com";
    private string tokenKey = "y9TvMTGczvZHH8Q04EEKSqxoU5Twn2gt";
    private TimeSpan timespan = TimeSpan.FromSeconds(90);

    private ILoginSession loginSession;
    private IChannelSession channelSession;



    #region UI Variables
    [SerializeField] string Username;
    //[SerializeField] Text txt_Channel_Name;
    //[SerializeField] Text txt_Message_Prefab;
    [SerializeField] string ChannelName ;
    [SerializeField] InputField tmp_Input_Username;
    [SerializeField] GameObject JoinButton;
    [SerializeField] GameObject LeaveButton;

    //[SerializeField] InputField tmp_Input_Channelname;
    //[SerializeField] InputField tmp_Input_SendMSG;
    //[SerializeField] Image container;
    #endregion 

    public void getPlayerCurrentPosition(string roomname)
    {
        Debug.Log("ChangePosition");
        ChannelName = roomname;
        Btn_Leave_Channel_Click();
    }

    private void Awake()
    {
        client = new Client();
        client.Uninitialize();
        client.Initialize();
        DontDestroyOnLoad(this);
    }

    private void OnApplicationQuit()
    {
        client.Uninitialize();
    }

    void Start()
    {
        
    }

    public void Bind_Login_Callback_Listeners(bool bind, ILoginSession loginSes)
    {
        if (bind)
        {
            loginSes.PropertyChanged += Login_Status;
        }
        else
        {
            loginSes.PropertyChanged -= Login_Status;
        }
        
    }

    public void Bind_Channel_Callback_Listeners(bool bind, IChannelSession channelSess)
    {
        if (bind)
        {
            channelSess.PropertyChanged += On_Channel_Status_Change;
        }
        else
        {
            channelSess.PropertyChanged -= On_Channel_Status_Change;
        }
    }

    #region Login Method
    public void LoginUser()
    {
        Username = tmp_Input_Username.text;
        Login(Username);
    }

    public void Login(string userName)
    {
        AccountId accountId = new AccountId(issuer, userName, domain);
        loginSession = client.GetLoginSession(accountId);

        Bind_Login_Callback_Listeners(true, loginSession);
        loginSession.BeginLogin(server, loginSession.GetLoginToken(tokenKey, timespan), ar =>
        {
            try
            {
                loginSession.EndLogin(ar);
            }
            catch (Exception e)
            {
                Bind_Login_Callback_Listeners(false, loginSession);
                Debug.Log(e.Message);
            }
        });
    }

    public void Logout()
    {
        loginSession.Logout();
        Bind_Login_Callback_Listeners(false, loginSession);
    }

    public void Login_Status(object sender, PropertyChangedEventArgs loginArgs)
    {
        var source = (ILoginSession)sender;
        switch (source.State)
        {
            case LoginState.LoggingIn:
                Debug.Log("Logging In");
                break;

            case LoginState.LoggedIn:
                Debug.Log($"Logged In {loginSession.LoginSessionId.Name}");
                JoinButton.SetActive(true);
                LeaveButton.SetActive(false);
                ChannelName = "Mainroom";
                break;
        }
    }
    #endregion

    #region JoinChannel Method
    public void JoinChannel(string channelname, bool IsAudio, bool IsText, bool switchTranmission, ChannelType channelType)
    {
        ChannelId channelid = new ChannelId(issuer, channelname, domain, channelType);
        channelSession = loginSession.GetChannelSession(channelid);
        Bind_Channel_Callback_Listeners(true, channelSession);
        channelSession.BeginConnect(IsAudio, IsText, switchTranmission, channelSession.GetConnectToken(tokenKey, timespan), ar =>
        {
            try
            {
                channelSession.EndConnect(ar);
                Debug.Log("try");
            }
            catch(Exception e)
            {
                Bind_Channel_Callback_Listeners(false, channelSession);
                Debug.Log(e.Message);
            }
        });
        JoinButton.SetActive(false);
        LeaveButton.SetActive(true);
    }

    public void Btn_Join_Channel_Click()
    {
        JoinChannel(ChannelName, true, true, true, ChannelType.NonPositional);
    }
    public void Leave_Channel(IChannelSession channelToDisconnect, string channelName)
    {
        channelToDisconnect.Disconnect();
        loginSession.DeleteChannelSession(new ChannelId(issuer, channelName, domain));
        JoinButton.SetActive(true);
        LeaveButton.SetActive(false);
    }

    public void Btn_Leave_Channel_Click()
    {
        Leave_Channel(channelSession, ChannelName);
    }

    public void On_Channel_Status_Change(object sender, PropertyChangedEventArgs channelArgs)
    {
        IChannelSession source = (IChannelSession)sender;
        switch (source.ChannelState)
        {
            case ConnectionState.Connecting:
                Debug.Log("Channel Connecting");
                break;

            case ConnectionState.Connected:
                Debug.Log($"{source.Channel.Name} Connected");
                break;

            case ConnectionState.Disconnecting:
                Debug.Log($"{source.Channel.Name} DisConnecting");
                break;

            case ConnectionState.Disconnected:
                Debug.Log($"{source.Channel.Name} DisConnected");
                JoinButton.SetActive(true);
                LeaveButton.SetActive(false);
                break;
        }
    }

    #endregion

    
}
