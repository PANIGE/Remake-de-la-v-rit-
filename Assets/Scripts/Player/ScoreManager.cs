using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    public long Score { get; private set; } = 0;
    public int Combo { get; private set; } = 0;
    public long BulletCombo { get; private set; } = 0;
    public int ComboIncrement = 5;
    public DateTime LastHitTime { get; private set; } = DateTime.MinValue;

    public GameObject ScoreText;
    public GameObject ComboText;

    public CancellationTokenSource TokenSource { get; private set; }

    public ScoreManager()
    {
        Instance = this;
    }

    private void Update()
    {
        if (DateTime.Now - LastHitTime > TimeSpan.FromSeconds(4))
        {
            Combo = 0;
            BulletCombo = 0;
            ComboText.GetComponent<TextMeshProUGUI>().SetText(Combo + "x");
        }
    }

    public void AddScore(long score)
    {
        TokenSource?.Cancel();
        TokenSource = new CancellationTokenSource();

        
        BulletCombo++;
        if (BulletCombo >= ComboIncrement)
        {
            Combo++;
            BulletCombo = 0;
        }
        Score += score * Combo+1;
        ScoreText.GetComponent<TextMeshProUGUI>().SetText(Score + "pts");
        ComboText.GetComponent<TextMeshProUGUI>().SetText(Combo + "x");

        LastHitTime = DateTime.Now;
        
    }

}
