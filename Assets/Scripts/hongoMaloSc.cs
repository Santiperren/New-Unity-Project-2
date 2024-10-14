using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class hongoMaloSc : MonoBehaviour
{
    public PostProcessVolume volume;
    public PostProcessVolume volume2;
    public BoxCollider colliderA;
    public float desapareceTiempo = 3f;
    public LensDistortion lens1;
    public ChromaticAberration chromaticAberration1;
    public ColorGrading colorgrading1;
    public LensDistortion lens2;
    public ChromaticAberration chromaticAberration2;
    public ColorGrading colorgrading2;
    public GameObject hongoMalo;
    public PostProcessLayer ppLayer1;
    public PostProcessLayer ppLayer2;
    public float saturacionbase1;

    void Start()
    {
        volume.profile.TryGetSettings(out lens1);
        volume.profile.TryGetSettings(out chromaticAberration1);
        volume.profile.TryGetSettings(out colorgrading1);
        volume2.profile.TryGetSettings(out lens2);
        volume2.profile.TryGetSettings(out chromaticAberration2);
        volume2.profile.TryGetSettings(out colorgrading2);
        ResetEffects();
    }

    void Update() { }

    private IEnumerator AnimateChangingLensDistortion(LensDistortion lens, float totalDuration)
    {
        float changeDuration = 4f;
        float fadeOutDuration = 2f;
        float totalElapsed = 0f;

        while (totalElapsed < changeDuration)
        {
            float newIntensityX = Random.Range(0f, 1.5f);
            float newIntensityY = Random.Range(0f, 1.5f);
            yield return StartCoroutine(AnimateLensDistortion(lens, 1f, newIntensityX, newIntensityY));
            yield return new WaitForSeconds(1f);
            totalElapsed += 1f;
        }
        yield return StartCoroutine(AnimateLensDistortion(lens, fadeOutDuration, 0f, 0f));
    }

    private IEnumerator AnimateLensDistortion(LensDistortion lens, float duration, float targetXMultiplier, float targetYMultiplier)
    {
        float startXMultiplier = lens.intensityX.value;
        float startYMultiplier = lens.intensityY.value;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;
            lens.intensityX.value = Mathf.Lerp(startXMultiplier, targetXMultiplier, t);
            lens.intensityY.value = Mathf.Lerp(startYMultiplier, targetYMultiplier, t);
            yield return null;
        }
        lens.intensityX.value = targetXMultiplier;
        lens.intensityY.value = targetYMultiplier;
    }

    private IEnumerator AnimateChromaticAberration(ChromaticAberration chromaticAberration, float fadeInDuration, float maxIntensity, float holdDuration)
    {
        float elapsed = 0f;
        float startIntensity = chromaticAberration.intensity.value;

        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;
            chromaticAberration.intensity.value = Mathf.Lerp(startIntensity, maxIntensity, t);
            yield return null;
        }
        chromaticAberration.intensity.value = maxIntensity;
        yield return new WaitForSeconds(holdDuration);
        elapsed = 0f;
        float fadeOutDuration = 2f;
        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;
            chromaticAberration.intensity.value = Mathf.Lerp(maxIntensity, 0f, t);
            yield return null;
        }
        chromaticAberration.intensity.value = 0f;
    }

    private IEnumerator AnimateColorGrading(ColorGrading colorgrading, float fadeInDuration, float maxHueShift, float maxSaturation, float holdDuration)
    {
        float elapsed = 0f;

        // Animate Hue Shift
        float startHueShift = colorgrading.hueShift.value;
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;
            colorgrading.hueShift.value = Mathf.Lerp(startHueShift, maxHueShift, t);
            yield return null;
        }
        colorgrading.hueShift.value = maxHueShift;

        // Hold duration
        yield return new WaitForSeconds(holdDuration);

        // Fade out Hue Shift
        elapsed = 0f;
        float fadeOutDuration = 2f;
        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;
            colorgrading.hueShift.value = Mathf.Lerp(maxHueShift, 0f, t);
            yield return null;
        }
        colorgrading.hueShift.value = 0f;

        // Animate Saturation
        elapsed = 0f;
        float startSaturation = saturacionbase1;
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;
            colorgrading.saturation.value = Mathf.Lerp(startSaturation, maxSaturation, t);
            yield return null;
        }
        colorgrading.saturation.value = maxSaturation;

        // Hold duration
        yield return new WaitForSeconds(holdDuration);

        // Fade out Saturation
        elapsed = 0f;
        while (elapsed < fadeOutDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeOutDuration;
            colorgrading.saturation.value = Mathf.Lerp(maxSaturation, saturacionbase1, t);
            yield return null;
        }
        colorgrading.saturation.value = saturacionbase1;
    }

    private void ResetEffects()
    {
        lens1.intensityX.value = 0f;
        lens1.intensityY.value = 0f;
        chromaticAberration1.intensity.value = 0f;
        colorgrading1.hueShift.value = 0f;
        colorgrading1.saturation.value = saturacionbase1;
        lens2.intensityX.value = 0f;
        lens2.intensityY.value = 0f;
        chromaticAberration2.intensity.value = 0f;
        colorgrading2.hueShift.value = 0f;
        colorgrading2.saturation.value = saturacionbase1;
    }

    public void OnTriggerEnter(Collider other)
    {
        
        LensDistortion lens;
        ChromaticAberration aberration;
        ColorGrading grading;
        if (other.gameObject.CompareTag("autoUno"))
        {
            lens = lens1;
            aberration = chromaticAberration1;
            grading = colorgrading1;
        }
        else
        {
            lens = lens2;
            aberration = chromaticAberration2;
            grading = colorgrading2;
        }

        Debug.Log("Objeto entró en contacto: " + other.gameObject.name);
        StartCoroutine(AnimateChangingLensDistortion(lens, 8f));
        Debug.Log("debug1");
        StartCoroutine(AnimateChromaticAberration(aberration, 3f, 1f, 15f));
        Debug.Log("debusexsexnyugiug");
        StartCoroutine(AnimateColorGrading(grading, 2f, 180f, 100f, 10f)); // Animate hue and saturation
        Debug.Log("debug");
        hongoMalo.SetActive(false);
        
        Invoke("Reappear", desapareceTiempo);
    }
    void Reappear()
    {
        hongoMalo.SetActive(true);
    }
}
