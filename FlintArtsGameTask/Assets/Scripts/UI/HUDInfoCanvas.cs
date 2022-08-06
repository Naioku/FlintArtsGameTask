using System.Collections;
using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// Manages displaying of info messages. 
    /// </summary>
    public class HUDInfoCanvas : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI displayedTextField;
        [SerializeField] private float fadeInTime = 1.2f;
        [SerializeField] private float fadeOutTime = 1.2f;
        [SerializeField] private float waitTimeBetweenFades = 1f;

        private CanvasGroup _canvasGroup;
        private Coroutine _currentRunningCoroutine;

        private void Start()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _canvasGroup.alpha = 0f;
        }

        /// <summary>
        /// Showing messages with fade in and out.
        /// </summary>
        /// <param name="message">Message to display.</param>
        public void FadeInOutMessage(string message)
        {
            displayedTextField.text = message;
            ResetCanvas();
            _currentRunningCoroutine = StartCoroutine(FadeInOut());
        }

        private void ResetCanvas()
        {
            if (_currentRunningCoroutine != null)
            {
                StopCoroutine(_currentRunningCoroutine);
            }

            _canvasGroup.alpha = 0f;
        }

        private IEnumerator FadeInOut()
        {
            yield return FadeIn(fadeInTime);
            yield return new WaitForSecondsRealtime(waitTimeBetweenFades);
            yield return FadeOut(fadeOutTime);
        }

        private IEnumerator FadeIn(float time)
        {
            while (_canvasGroup.alpha < 1)
            {
                _canvasGroup.alpha += Time.deltaTime / time;
                yield return new WaitForEndOfFrame();
            }
        }
        
        private IEnumerator FadeOut(float time)
        {
            while (_canvasGroup.alpha > 0)
            {
                _canvasGroup.alpha -= Time.deltaTime / time;
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
