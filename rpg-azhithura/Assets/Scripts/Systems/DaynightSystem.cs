using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DaynightSystem : MonoBehaviour
{
    // timer DECREASES (DayTimeDuration -> 0) => DAY-TIME
    // timer INCREASES (0 -> DayTimeDuration) => NIGHT-TIME


    [SerializeField] float DaytimeDuration;
    [SerializeField] float ExtraDuration;
    [SerializeField] AnimationCurve curve;

    float timer;

    [Space]
    bool isDaytime;
    [Space]
    bool showNight;
    [HideInInspector] public bool isDaynightWorking;

    GameManager gm;
    Slider daytimeIndicator;

    void Start()
    {
        gm = GetComponent<GameManager>();

        isDaynightWorking = false;
        timer = DaytimeDuration + ExtraDuration;

        daytimeIndicator = UIManager.Instance.DayNightIndicator;
        daytimeIndicator.maxValue = DaytimeDuration;
        daytimeIndicator.minValue = 0;

    }

    void FixedUpdate()
    {


        if (!isDaynightWorking)
            return;

        #region Time progression

        daytimeIndicator.value = timer;

        if (timer <= -ExtraDuration) // DAY-TIME over
        {
            Debug.Log("day over");

            daytimeIndicator.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 180);
            timer = -ExtraDuration;
            isDaytime = false;

            gm.completeDay();
        }
        else if (timer >= DaytimeDuration) // NIGHT-TIME over
        {
            Debug.Log("night over");

            daytimeIndicator.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, 0);
            timer = DaytimeDuration;
            isDaytime = true;
        }

        daytimeSettings(isDaytime);

        #endregion

    }



    void daytimeSettings(bool isDaytime)
    {
        UIManager.Instance.NighttimeFadePanel.GetComponent<CanvasGroup>().alpha = curve.Evaluate(1 - timer/DaytimeDuration);

        if (!isDaytime) // DURING NIGHT
        {
            Debug.Log("is night now");

            if (showNight) // SHOW night-time
            {
                timer += Time.fixedDeltaTime;
            }
            else // SNAP night-time
            {
                timer = DaytimeDuration;
            }
        }
        else // DURING DAY
        {
            Debug.Log("is day now");

            timer -= Time.fixedDeltaTime;
        }
    }

}
