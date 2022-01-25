using UnityEngine;

public class TimerConverter : MonoBehaviour
{
    public static string ToSeconds(float time)
    {
        decimal decimalValue = (decimal)time;

        decimal seconds = decimal.Truncate(decimalValue);
        decimal miliSeconds = decimal.Truncate((decimalValue - decimal.Truncate(decimalValue)) * 100);

        string zero = string.Empty;

        if (miliSeconds < 10)
        {
            zero = "0";
        }

        string toReturn = string.Format("{0}:{1}{2}", seconds, zero, miliSeconds);

        return toReturn;

    }
}
