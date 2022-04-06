using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{
    
    [SerializeField]
    private Color offColor;
    [SerializeField]
    private Color onColor;
    [SerializeField]
    private Color circleColor;
    [SerializeField]
    public float _animationDuration;

    private bool isAnimating = false;

    private int mode = -1;

    private Button _button;
    private Image _buttonImage;
    private GameObject _buttonCircle;
    private Image _buttonCircleImage;

    void Start()
    {
        _button = GetComponent<Button>();
        _buttonImage = GetComponent<Image>();
        _buttonCircle = transform.GetChild(0).gameObject;

        _buttonCircleImage = _buttonCircle.GetComponent<Image>();

        _buttonImage.color = offColor;
        _buttonCircleImage.color = circleColor;

        _button.onClick.AddListener(StartAnimation);
    }

    private void StartAnimation()
    {
        if (isAnimating) return;
        Vector3 pos = _buttonCircle.transform.localPosition;

        StartCoroutine(LinearInterpolation(pos.x, -pos.x, _animationDuration));
        _buttonImage.color = (mode == -1) ? onColor : offColor;
        mode *= -1;
    }

    IEnumerator LinearInterpolation(float startPosition, float endPosition, float duration)
    {
        // https://gamedevbeginner.com/the-right-way-to-lerp-in-unity-with-examples/
        isAnimating = true;
        float timeElapsed = 0;
        while (timeElapsed < duration)
        {
            _buttonCircle.transform.localPosition = new Vector3(Mathf.Lerp(startPosition, endPosition, timeElapsed / duration), 0, 0);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        _buttonCircle.transform.localPosition = new Vector3(endPosition, 0, 0);
        isAnimating = false;
    }
}
