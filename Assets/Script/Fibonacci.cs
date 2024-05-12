using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fibonacci : MonoBehaviour
{
    //input
    public InputField Nhap1So;
    //output
    public Text KetQua;

    public Button Result;

    public int _Fibonacci( int n)
    {
        
        if ( n == 1 || n == 2)
        {
            return 1;
        }
        return _Fibonacci(n - 1) + _Fibonacci(n - 2);
    }

    public void ResultButton()
    {
        int nhap1So = int.Parse(Nhap1So.text);
        int ketQua = _Fibonacci(nhap1So);
        KetQua.text = ketQua.ToString();
    }
}
