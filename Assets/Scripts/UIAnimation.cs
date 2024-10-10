using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public GameObject[] uiElements; // Arrastra tus elementos UI aquí en el Inspector

    private void Start()
    {
        StartCoroutine(AnimateUI());
    }

    private IEnumerator AnimateUI()
    {
        foreach (GameObject element in uiElements)
        {
            CanvasGroup canvasGroup = element.GetComponent<CanvasGroup>();
            RectTransform rectTransform = element.GetComponent<RectTransform>();

            // Aparecer en el medio de la pantalla
            //   rectTransform.anchoredPosition = new Vector2(500, 0);

            rectTransform.anchoredPosition = new Vector2(0 , 0); // Arriba
            canvasGroup.alpha = 0; // Comienza con opacidad 0
            // Animación para aparecer
            yield return AnimateElement(canvasGroup, rectTransform, true);

            // Mantener visible por 1.3 segundos
            yield return new WaitForSeconds(0.3f);

            // Animación para desaparecer
            yield return AnimateElement(canvasGroup, rectTransform, false);
        }
    }

    private IEnumerator AnimateElement(CanvasGroup canvasGroup, RectTransform rectTransform, bool show)
    {
        float duration = 0.3f; // Duración total de la animación
        float elapsedTime = 0;

        Vector2 startPosition = show ? new Vector2(0, -Screen.height / 2) : Vector2.zero; // Comienza arriba o en el centro
        Vector2 endPosition = show ? Vector2.zero : new Vector2(0, -Screen.height / 2); // Centro o arriba

        while (elapsedTime < duration)
        {
            float t = elapsedTime / duration;

            // Movimiento gradual
            rectTransform.anchoredPosition = Vector2.Lerp(startPosition, endPosition, t);

            // Opacidad gradual
            canvasGroup.alpha = Mathf.Lerp(show ? 0 : 1, show ? 1 : 0, t);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Asegúrate de que termina en el estado final
        rectTransform.anchoredPosition = endPosition;
        canvasGroup.alpha = show ? 1 : 0;
    }
}
