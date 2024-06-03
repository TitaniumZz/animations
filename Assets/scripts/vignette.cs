using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class VignetteController : MonoBehaviour
{
    public PostProcessVolume postProcessVolume;
    public float duration = 2f;
    public AnimationCurve intensityCurve;

    private float currentTime = 0f;
    private bool isIncreasing = true;

    void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > duration)
        {
            isIncreasing = !isIncreasing;
            currentTime = 0f;
        }

        float intensity = intensityCurve.Evaluate(currentTime / duration);

        Vignette vignette;
        if (postProcessVolume.profile.TryGetSettings(out vignette))
        {
            vignette.intensity.value = intensity;
        }
    }
}
