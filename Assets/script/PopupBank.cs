using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//���, �Ա� ��ư�� ��������
//�ش�Ǵ� �˾�â�� ����.
public class PopupBank : MonoBehaviour
{
    [SerializeField] //�ν����� â���� �������ִ�
    private GameObject withdrawPannel;
    [SerializeField]
    private GameObject dsepositPannl;
    [SerializeField]
    private GameObject back;
    [SerializeField]
    private GameObject RemittancePannl;
    //��ư�� ����� �Լ��� �����
    //��ư�� ����� public ����� �����ϴ�
    //�۱��ϱ� �Լ� ����
    //�۱��ϱ� �Ҷ� InputField ���̵�� PlayerPrefs ���̵� ���ٸ� ���� �۱�
    //�ٸ��ٸ� ����� �����ϴ� â
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
