using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    public Animator animator;

    public void Fade()
    {
        animator.SetTrigger("Fade_out");
    }

    public void AfterFade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}