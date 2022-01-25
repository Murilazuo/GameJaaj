using UnityEngine;

public class TimerConverter : MonoBehaviour
{
    public static string ToSeconds(float time)
    {
        decimal decimalValue = (decimal)time;

        decimal minutes = decimal.Truncate(decimalValue / 60);
        decimal seconds = decimal.Truncate(decimalValue % 60);

        string zero = string.Empty;

        if (seconds < 10)
        {
            zero = "0";
        }

        string toReturn = string.Format("{0}:{1}{2}", minutes, zero, seconds);

        return toReturn;

    }
}
