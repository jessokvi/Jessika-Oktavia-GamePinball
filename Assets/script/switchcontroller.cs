using System.Collections;
using UnityEngine;

public class switchcontroller : MonoBehaviour
{
    private enum SwitchState
    {
        Off,
        On,
        Blink
    }
    
    public Collider bola;
    public Material offMaterial;
    public Material OnMaterial;
    public float score;

    public ScoreManager scoreManager;

    public AudioManajerSwitch audioManajer;
    public VFXSwitchManager vfxSwitchManager;

    private SwitchState state;
    private Renderer renderer;

    private void Start() 
    {
        renderer = GetComponent<Renderer>();

        Set(false);

        StartCoroutine(BlinkTimerStart(5));
    }

    private void OnTriggerEnter(Collider other) 
    {
        if (other == bola)
        {
            Toggle();

            if (audioManajer != null)
            {
                if (state == SwitchState.On)
                {
                    audioManajer.PlaySwitchOnSFX(other.transform.position);
                }
                else if (state == SwitchState.Off)
                {
                    audioManajer.PlaySwitchOffSFX(other.transform.position);
                }
                
                if (vfxSwitchManager != null)
                {
                    if (state == SwitchState.On)
                    {
                        vfxSwitchManager.PlaySwitchOnVFX(other.transform.position);
                    }
                    else if (state == SwitchState.Off)
                    {
                        vfxSwitchManager.PlaySwitchOffVFX(other.transform.position);
                    }

                }

            }
        }


    }

    private void Set(bool active)
    {
        if (active == true)
        {
            state = SwitchState.On;
            renderer.material = OnMaterial;
            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimerStart(5));
        }
    }

    private void Toggle()
    {
        if (state == SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }

        scoreManager.AddScore(score);

    }

    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
    
        for (int i = 0; i < times; i++)
        {
            renderer.material = OnMaterial;
            yield return new WaitForSeconds(0.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(0.5f);
        }

        state = SwitchState.Off;

        StartCoroutine(BlinkTimerStart(5));
    }

    private IEnumerator BlinkTimerStart(float time)
    {
        yield return new WaitForSeconds(time);
        StartCoroutine(Blink(2));
    }
}
