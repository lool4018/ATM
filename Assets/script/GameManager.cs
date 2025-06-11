using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

//싱글톤
//프로젝트 상에 하나만 존재를 한다
//바로 연결을 한다


[Serializable]
public class UserData
{
    public string userID;
    public string password;
    public string userName;
    public int cash;
    public int bankBalance;

    // 생성자
    public UserData(string userID, string password, string userName, int cash, int bankBalance)
    {
        //아이디와 패스워드 추가
        //아이디와 패스워드가 맞다면 로그인 버튼으로 게임 시작
        this.userName = userName;
        this.cash = cash;
        this.bankBalance = bankBalance;
        this.userID = userID;
        this.password = password;

    }
}

public class GameManager : MonoBehaviour
{
    public InputField inputField;
    public InputField outputField;

    public static GameManager Instance;
    public UserData userData;
    public Text nameTxt;
    public Text descriptionTxt;
    public Text cashTxt;
    public GameObject Insufficientbalance;
    int inputmoney;
    public InputField ID_InputField;
    public InputField Password_InputField;
    public GameObject PopupSignUp;

    public void SignBtn()
    {
        PlayerPrefs.SetString(ID_InputField.text, ID_InputField.text);
        PlayerPrefs.SetString(Password_InputField.text, Password_InputField.text);
        PopupSignUp.SetActive(false);
    }
    private void Start()
    {
        inputField.onEndEdit.AddListener(Hadnlelnput);
        outputField.onEndEdit.AddListener(Hadnlelnput);
        Load();
    }

    private void Hadnlelnput(string input)
    {
        int value;
        if (int.TryParse(input, out value))
        {
            inputmoney = value;
            Debug.Log("입력된 값: " + value);
        }
        else
        {
            Debug.Log("숫자가 아님");
        }
    }

    //input 입금
    public void DepositByInput()
    {
        if (inputmoney <= userData.bankBalance)
        {
            userData.cash += inputmoney;
            userData.bankBalance -= inputmoney;
            Save();
        }
        inputmoney = 0;
    }
    //input 출금
    public void InputWithdrawal()
    {
        if (inputmoney <= userData.cash)
        {
            userData.cash -= inputmoney;
            userData.bankBalance += inputmoney;
            Save();
        }
        inputmoney = 0;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else // 이미 존재 한다면
        {
            Destroy(gameObject);
        }

        // 생성자를 통해 데이터 초기화
        //1. 아이다가 있는경우
        //2. 아이디가 없는경우
        if (PlayerPrefs.GetString("ID") != null)
        {
            userData = new UserData(userData.userID, userData.password, userData.userName, userData.cash, userData.bankBalance);
        }
        else
        {
            userData = new UserData("lool4018", "asdf", userData.userName, userData.cash, userData.bankBalance);
        }
    }

    public void Refresh()
    {
        nameTxt.text = PlayerPrefs.GetString("userName");
        descriptionTxt.text = "Balance : " + PlayerPrefs.GetInt("bankBalance").ToString("N0");
        cashTxt.text = PlayerPrefs.GetInt("cash").ToString("N0");
    }
    //버튼에 등록 할려면 반드시 piblic으로 등록
    public void Depositbutton(int money)
    {
        if (money <= userData.bankBalance)
        {
            userData.cash += money;
            userData.bankBalance -= money;
            Save();
        }
        else
        {
            Insufficientbalance.SetActive(true);
        }
    }

    public void Withdrawalbutton(int money)
    {
        if (money <= userData.cash)
        {
            userData.cash -= money;
            userData.bankBalance += money;
            Save();
        }
        else
        {
            Insufficientbalance.SetActive(true);
        }
    }

    private void Save()
    {
        PlayerPrefs.SetString("userName", userData.userName);
        PlayerPrefs.SetInt("bankBalance", userData.bankBalance);
        PlayerPrefs.SetInt("cash", userData.cash);
        PlayerPrefs.SetString("ID", userData.userID);
        PlayerPrefs.SetString("password", userData.password);
    }

    private void Load()
    {
        Debug.Log(PlayerPrefs.GetString("userName"));
        Debug.Log(PlayerPrefs.GetInt("bankBalance"));
        Debug.Log(PlayerPrefs.GetInt("cash"));
    }

    public void back()
    {
        Insufficientbalance.SetActive(false);
    }

    private void Update()
    {
        Refresh();
    }
}
