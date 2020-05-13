using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeTransition : MonoBehaviour
{
    public Animator animator;
    // Update is called once per frame
    void Update()
    {

    }

    public void Fade()
    {
        animator.SetTrigger("Fade_out");
    }

    public void AfterFade()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}