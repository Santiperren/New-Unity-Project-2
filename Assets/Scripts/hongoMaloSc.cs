using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class hongoMaloSc : MonoBehaviour
{
    public PostProcessVolume volume;
    public BoxCollider colliderA;

    public LensDistortion lens;
    public ChromaticAberration chromaticAberration;
    public ColorGrading colorgrading;

    void Start()
    {
        volume.profile.TryGetSettings(out lens);
        volume.profile.TryGetSettings(out chromaticAberration);
        volume.profile.TryGetSettings(out colorgrading);
        ResetEffects();
    }

    void Update() { }

    private IEnumerator AnimateChangingLensDistortion(float totalDuration)
    {
        float changeDuration = 8f;
        float fadeOutDuration = 2f;
        float totalElapsed = 0f;

        while (totalElapsed < changeDuration)
        {
            float newIntensityX = Random.Range(0f, 1.5f);
            float newIntensityY = Random.Range(0f, 1.5f);
            yield return StartCoroutine(AnimateLensDistortion(1f, newIntensityX, newIntensityY));
            yield return new WaitForSeconds(1f);
            totalElapsed += 1f;
        }
        yield return StartCoroutine(AnimateLensDistortion(fadeOutDuration, 0f, 0f));
    }

    private IEnumerator AnimateLensDistortion(float duration, float targetXMultiplier, float targetYMultiplier)
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

    private IEnumerator AnimateChromaticAberration(float fadeInDuration, float maxIntensity, float holdDuration)
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

    private IEnumerator AnimateColorGrading(float fadeInDuration, float maxHueShift, float maxSaturation, float holdDuration)
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
        float startSaturation = colorgrading.saturation.value;
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
            colorgrading.saturation.value = Mathf.Lerp(maxSaturation, 0f, t);
            yield return null;
        }
        colorgrading.saturation.value = 0f;
    }

    private void ResetEffects()
    {
        lens.intensityX.value = 0f;
        lens.intensityY.value = 0f;
        chromaticAberration.intensity.value = 0f;
        colorgrading.hueShift.value = 0f;
        colorgrading.saturation.value = 0f;
    }

    public void OnTriggerEnter(Collider other)
    {
        Debug.Log("Objeto entró en contacto: " + other.gameObject.name);
        StartCoroutine(AnimateChangingLensDistortion(10f));
        StartCoroutine(AnimateChromaticAberration(3f, 1f, 15f));
        StartCoroutine(AnimateColorGrading(2f, 180f, 100f, 15f)); // Animate hue and saturation

    }
}
