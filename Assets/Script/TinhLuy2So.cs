using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TinhLuy2So : MonoBehaviour
{
    //input
    public InputField Nhap1So;
    public InputField NhapSoMu;
    //output
    public Text KetQua;

    public Button Result;

    public int LuyThua(int x, int n)
    {

        if (n == 0)
        {
            return 1;
        }
        return x * LuyThua(x, n - 1);
    }


    public void ResultButton()
    {
        int nhap1So = int.Parse(Nhap1So.text);
        int nhapSoMu = int.Parse (NhapSoMu.text);   
        int ketQua = LuyThua(nhap1So, nhapSoMu);
        KetQua.text = ketQua.ToString();
    }
}
