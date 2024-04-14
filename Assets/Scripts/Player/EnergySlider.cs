using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class EnergySlider : MonoBehaviour
{
    public static EnergySlider Instance { get; private set; }
    public Slider MunSlider;
    public float MaxEnergy = 100f;
    public float Energy;
    private bool regen = true;
    private Action regenTask;
    private CancellationTokenSource regenToken { get; set; }

    public bool CanDoAction(float cost)
    {
        return Energy >= cost;
    }

    public bool Regen
    {
        get => regen;
        set
        {
            if (value == regen)
                return;


            regenToken?.Cancel();

            if (!value)
                regen = false;
            else
            {
                regenTask = RegenTask;
                regenToken = new CancellationTokenSource();
                Task.Run(regenTask, regenToken.Token);
            }
        }
    }

    private async void RegenTask()
    {
        await Task.Delay(500);
        regen = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        Energy = MaxEnergy;
    }

    // Update is called once per frame
    void Update()
    {
        if(Math.Abs(MunSlider.value - Energy) > 0.01f)
        {
            MunSlider.value = Energy;
        }
        //Regen at the rate of 15 munitions per second
        if (Energy < MaxEnergy && regen)
        {
            Energy = Math.Min(15 * Time.deltaTime, MaxEnergy) + Energy;
        }
        

    }

}
