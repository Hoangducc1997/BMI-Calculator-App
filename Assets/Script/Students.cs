using UnityEngine;
using UnityEngine.UI;
using System;
using JetBrains.Annotations;
using Unity.VisualScripting;
using System.IO;

public class Students : MonoBehaviour
{
    //Input
    public InputField IdStudent;
    public InputField NameStudent;
    public InputField DOBStudent;
    public Toggle MaleStudent;
    public Toggle FemaleStudent;
    public Toggle UnisexStudent;
    public InputField HeightStudent;
    public InputField WeightStudent;
    public Slider BmiResultBar;

    //Output
    public Button result;

    public Text NameResult;
    public Text IdResult;
    public Text DobResult;
    public Text SexResult;
    public Text WeightResult;
    public Text HeightResult;
    public Text BmiResult;

    private string sexChoice;
    private float height;
    private double weight;

    private void InfoStudent()
    {
        int idStudent = int.Parse(IdStudent.text);
        string nameStudent = NameStudent.text;
        DateTime dayOfBirth = DateTime.Parse(DOBStudent.text);
        
        float height = float.Parse(HeightStudent.text);
        double weight = double.Parse(WeightStudent.text);
    }

    public void Weight()
    {
        if (!double.TryParse(WeightStudent.text, out weight) || weight <= 0 || weight >= 500)
        {
            Debug.Log("Invalid weight. Please enter weight between 0 and 500.");
        }
    }

    // Change return type to void
    public void Height()
    {
        if (!float.TryParse(HeightStudent.text, out height) || height <= 0 || height >= 300)
        {
            Debug.Log("Invalid height. Please enter height between 0 and 300.");
        }
    }

    public int AgeCalculation()
    {
        DateTime DOB;
        if (!DateTime.TryParseExact(DOBStudent.text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DOB))
        {
            Debug.Log("Invalid date format. Please enter date in dd/MM/yyyy format.");
            return 0;
        }

        DateTime now = DateTime.Now;
        int age = now.Year - DOB.Year;
        if (now < DOB.AddYears(age)) age--;
        return age;
    }

    public void SexChoice()
    {
        if (MaleStudent.isOn && !FemaleStudent.isOn && !UnisexStudent.isOn)
        {
            sexChoice = "Male";
            Debug.Log("Male");
        }
        else if (FemaleStudent.isOn && !MaleStudent.isOn && !UnisexStudent.isOn)
        {
            sexChoice = "Female";
            Debug.Log("Female");
        }
        else if (UnisexStudent.isOn && !MaleStudent.isOn && !FemaleStudent.isOn)
        {
            sexChoice = "Unisex";
            Debug.Log("Unisex");
        }
        else
        {
            sexChoice = "Unisex";
        }
    }

    private void BmiBar()
    {
        
        double BmiCalculation = weight / ((height / 100) * (height / 100));
        if (BmiCalculation > 0 && BmiCalculation < 18.5)
        {
            BmiResultBar.value = 0.9f;
        }
        else if (BmiCalculation >= 18.5 && BmiCalculation <= 24.9)
        {
            BmiResultBar.value = 3.5f;
        }
        else if (BmiCalculation >= 25 && BmiCalculation <= 29.9)
        {
            BmiResultBar.value = 17.5f;
        }
        else if (BmiCalculation >= 30 && BmiCalculation <= 34.9)
        {
            BmiResultBar.value = 25.5f;
        }
        else if (BmiCalculation >= 35)
        {
            BmiResultBar.value = 34f;
        }
        else
        {
            BmiResultBar.value = 0;
        }
    }
    public void BMI()
    {
        Weight(); // Update weight value
        Height(); // Update height value
        double BmiCalculation = weight / ((height / 100) * (height / 100));
        if (BmiCalculation > 0 && BmiCalculation < 18.5)
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " : UNDERWEIGHT";
        }
        else if (BmiCalculation >= 18.5 && BmiCalculation <= 24.9)
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " : NORMAL";
        }
        else if (BmiCalculation >= 25 && BmiCalculation <= 29.9)
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " : OVERWEIGHT";
        }
        else if (BmiCalculation >= 30 && BmiCalculation <= 34.9)
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " : OBESE";
        }
        else if (BmiCalculation >= 35)
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " : EXTREMELY OBESE";
        }
        else
        {
            BmiResult.text = BmiCalculation.ToString("F2") + " PLEASE TRY AGAIN! ";
        }
    }

    public void Result()
    {
        NameResult.text = NameStudent.text;
        IdResult.text = IdStudent.text;
        DobResult.text = AgeCalculation().ToString();
        //SexResult
        Weight(); // Update weight value
        Height(); // Update height value
        WeightResult.text = weight.ToString() + " KILOGRAMS";
        HeightResult.text = height.ToString() + " CENTIMETERS";
        SexChoice();
        SexResult.text = sexChoice.ToString();
        BMI();
        BmiBar();
        //Output in Text 
        WriteToFile($"Name: {NameResult.text} \nID: {IdResult.text} \nDay of Birth: {DobResult.text} \nWEIGHT: {WeightResult.text} \nHEIGHT: {HeightResult.text} \nSEX: {SexResult.text} \n -> BMI: {BmiResult.text}\n");
    }

    //Create Text
    private string outputPath = "C:\\Users\\HP\\Documents\\BMI Student.txt"; // Đường dẫn tới tệp văn bản xuất ra

    private void WriteToFile(string data)
    {  
        using (StreamWriter writer = new StreamWriter(outputPath, true))
        {
            writer.WriteLine(data);
        }
    }
}
