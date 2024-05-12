using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinhGiaiThua : MonoBehaviour
{
    //input
    public InputField Nhap1SoGiaiThua;
    //output
    public Text KetQuaGiaiThua;

    public Button Result;
    
    public void TinhToanGiaiThua()
    {
        int nhap1SoGiaiThua = int.Parse(Nhap1SoGiaiThua.text);
        int giaiThua = 1;
        for (int i = 1; i <= nhap1SoGiaiThua; i++)
        {
            giaiThua *= i;  
        }
        KetQuaGiaiThua.text = giaiThua.ToString();
    }

    public void ResultButton()
    {
        TinhToanGiaiThua();
    }

}
