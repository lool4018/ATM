using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//출금, 입금 버튼을 눌렀을때
//해당되는 팝업창을 띄운다.
public class PopupBank : MonoBehaviour
{
    [SerializeField] //인스펙터 창에서 담을수있다
    private GameObject withdrawPannel;
    [SerializeField]
    private GameObject dsepositPannl;
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private GameObject RemittancePannl;
    //버튼에 등록할 함수를 만든다
    //버튼에 등록할 public 등록이 가능하다
    //송금하기 함수 제작
    //송금하기 할때 InputField 아이디랑 PlayerPrefs 아이디가 같다면 돈을 송금
    //다르다면 대상이 없습니다 창
    public void OpenWidrawBtn()
    {
        back.SetActive(false);
        withdrawPannel.SetActive(true);
        dsepositPannl.SetActive(false);
        RemittancePannl.SetActive(false);
    }

    public void CloseWidrawBtn()
    {
        back.SetActive(false);
        withdrawPannel.SetActive(false);
        dsepositPannl.SetActive(true);
        RemittancePannl.SetActive(false);
    }
    
    public void Returnbutton()
    {
        back.SetActive(true);
        withdrawPannel.SetActive(false);
        dsepositPannl.SetActive(false);
        RemittancePannl.SetActive(false);
    }
    
    public void Remittance()
    {
        back.SetActive(false);
        withdrawPannel.SetActive(false);
        dsepositPannl.SetActive(false);
        RemittancePannl.SetActive(true);
    }

}
