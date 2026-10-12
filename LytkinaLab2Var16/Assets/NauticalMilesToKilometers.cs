
using UnityEngine;
using TMPro;
using System.Globalization;

public class NauticalMilesToKilometers : MonoBehaviour
{
    public TMP_InputField nauticalMilesInput;
    public TextMeshProUGUI resultText;

    public void ConvertToKilometers()
    {
        // Отримуємо введене значення та замінюємо кому на крапку.
        string input = nauticalMilesInput.text.Trim().Replace(',', '.');

        // Перевіряємо, чи введено правильне невід'ємне число.
        if (!double.TryParse(input,
            NumberStyles.Float,
            CultureInfo.InvariantCulture,
            out double nauticalMiles)
            || double.IsNaN(nauticalMiles)
            || double.IsInfinity(nauticalMiles)
            || nauticalMiles < 0)
        {
            resultText.text = "Введіть коректне число, не менше нуля.";
            return;
        }

        // Одна морська миля дорівнює 1,852 кілометра.
        double kilometers = nauticalMiles * 1.852;

        // Виводимо результат з точністю до трьох знаків.
        resultText.text = "Результат: "
            + kilometers.ToString("0.###", CultureInfo.InvariantCulture)
            + " км";
    }
}
