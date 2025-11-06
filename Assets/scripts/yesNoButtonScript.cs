using UnityEngine;
using UnityEngine.UI;

public class ButtonChecker : MonoBehaviour
{
    public Button redButton;
    public Button greenButton;
    public Animator animator;

    void Start()
    {
        redButton.onClick.AddListener(OnRedButtonPressed);
        greenButton.onClick.AddListener(OnGreenButtonPressed);
    }

    void OnRedButtonPressed()
    {
        animator.SetTrigger("redpress");
    }

    void OnGreenButtonPressed()
    {
        animator.SetTrigger("greenpress");
    }
}
