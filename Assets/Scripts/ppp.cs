using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class ppp : MonoBehaviour
{
    public PostProcessVolume volume;


    private LensDistortion lens;
    private ChromaticAberration chromaticAberration;


    // Start is called before the first frame update
    void Start()
    {
        volume.profile.TryGetSettings(out lens);
        volume.profile.TryGetSettings(out chromaticAberration);  // Obtener el efecto Chromatic Aberration
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Iniciar animación con cambios bruscos en los primeros 8 segundos, luego apagarse gradualmente
            StartCoroutine(AnimateChangingLensDistortion(10f));  // Duración total de 10 segundos
            StartCoroutine(AnimateChromaticAberration(3f, 1f, 15f));  // Subir Chromatic Aberration en 3 segundos, mantener por 15 segundos, luego apagar en 2 segundos
        }


        // Reset values to zero when "O" key is pressed
        if (Input.GetKeyDown(KeyCode.O))
        {
            ResetEffects();
        }
    }


    private IEnumerator AnimateChangingLensDistortion(float totalDuration)
    {
        float changeDuration = 8f;   // Cambios bruscos durante 8 segundos
        float fadeOutDuration = 2f;  // Apagado gradual en los últimos 2 segundos
        float totalElapsed = 0f;


        // Fase 1: Cambios bruscos de distorsión durante 8 segundos
        while (totalElapsed < changeDuration)
        {
            // Generar nuevos cambios bruscos dentro de los rangos especificados
            float newIntensityX = Random.Range(0f, 1.5f);  // X Multiplier
            float newIntensityY = Random.Range(0f, 1.5f);  // Y Multiplier


            // Animar Lens Distortion hacia los nuevos valores
            yield return StartCoroutine(AnimateLensDistortion(1f, newIntensityX, newIntensityY));


            // Esperar un segundo antes del próximo cambio
            yield return new WaitForSeconds(1f);


            // Actualizar el tiempo total
            totalElapsed += 1f;
        }


        // Fase 2: Apagado gradual de los efectos en los últimos 2 segundos
        yield return StartCoroutine(AnimateLensDistortion(fadeOutDuration, 0f, 0f));
    }


    private IEnumerator AnimateLensDistortion(float duration, float targetXMultiplier, float targetYMultiplier)
    {
        // Valores iniciales de todos los parámetros
        float startXMultiplier = lens.intensityX.value;
        float startYMultiplier = lens.intensityY.value;


        float elapsed = 0f;


        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / duration;


            // Interpolación de los valores
            lens.intensityX.value = Mathf.Lerp(startXMultiplier, targetXMultiplier, t);
            lens.intensityY.value = Mathf.Lerp(startYMultiplier, targetYMultiplier, t); // Sincronizar Y con X


            yield return null;  // Espera el siguiente frame
        }


        // Ajustar los valores finales
        lens.intensityX.value = targetXMultiplier;
        lens.intensityY.value = targetYMultiplier; // Asegurarse de que Y coincida con X
    }


    private IEnumerator AnimateChromaticAberration(float fadeInDuration, float maxIntensity, float holdDuration)
    {
        float elapsed = 0f;
        float startIntensity = chromaticAberration.intensity.value;


        // Fase 1: Subir la intensidad de Chromatic Aberration en fadeInDuration
        while (elapsed < fadeInDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fadeInDuration;
            chromaticAberration.intensity.value = Mathf.Lerp(startIntensity, maxIntensity, t);
            yield return null;
        }
        chromaticAberration.intensity.value = maxIntensity;


        // Fase 2: Mantener la intensidad en 1 durante holdDuration
        yield return new WaitForSeconds(holdDuration);


        // Fase 3: Bajar la intensidad de 1 a 0 en los últimos 2 segundos
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


    // Function to reset all effects to zero
    private void ResetEffects()
    {
        lens.intensityX.value = 0f;
        lens.intensityY.value = 0f;
        chromaticAberration.intensity.value = 0f;
    }
}


