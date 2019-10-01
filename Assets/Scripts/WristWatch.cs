using System.Collections;
using System.Collections.Generic;
using OatsUtil;
using UnityEngine;

public class WristWatch : MonoBehaviour
{
    private TMPro.TMP_Text Text;

    private float timeAccumulator = 0f;
    private int elapsedSeconds = 0;
    private int elapsedMinutes = 0;
    // Start is called before the first frame update
    void Start()
    {
        Text = this.RequireDescendantGameObject("WatchText").RequireComponent<TMPro.TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        timeAccumulator += Time.deltaTime;
        if (timeAccumulator > 1f)
        {
            elapsedSeconds += 1;
            timeAccumulator -= 1f;
        }
        if (elapsedSeconds >= 60)
        {
            elapsedMinutes += 1;
            elapsedSeconds -= 60;
        }
        Text.text = "8:0" + elapsedMinutes.ToString() + " " + elapsedSeconds.ToString("00");
    }
}
