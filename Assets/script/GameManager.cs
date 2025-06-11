using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.StandaloneInputModule;

//�̱���
//������Ʈ �� �ϳ��� ���縦 �Ѵ�
//�ٷ� ������ �Ѵ�


[Serializable]
public class UserData
{
    public string userID;
    public string password;
    public string userName;
    public int cash;
    public int bankBalance;

    // ������
    public UserData(string userID, string password, string userName, int cash, int bankBalance)
    {
        //���̵�� �н����� �߰�
        //���̵�� �н����尡 �´ٸ� �α��� ��ư���� ���� ����
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
            Debug.Log("�Էµ� ��: " + value);
        }
        else
        {
            Debug.Log("���ڰ� �ƴ�");
        }
    }

    //input �Ա�
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
    //input ���
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
        else // �̹� ���� �Ѵٸ�
        {
            Destroy(gameObject);
        }

        // �����ڸ� ���� ������ �ʱ�ȭ
        //1. ���̴ٰ� �ִ°��
        //2. ���̵� ���°��
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
    //��ư�� ��� �ҷ��� �ݵ�� piblic���� ���
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
