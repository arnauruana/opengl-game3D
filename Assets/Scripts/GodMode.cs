using UnityEngine;
using UnityEngine.SceneManagement;


public class GodMode : MonoBehaviour
{
    [Header("Status")]
    public bool enabled;

    private static GodMode instance;

    private void Awake()
    {
        if (GodMode.instance == null)
        {
            GodMode.instance = this;
            GameObject.DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GodMode.Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        this.enabled = false;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F9))
        {
            this.toggle();
        }
    }

    public void enable()
    {
        this.enabled = true;
    }

    public void disable()
    {
        this.enabled = false;
    }

    public bool isEnabled()
    {
        return this.enabled;
    }

    public void toggle()
    {
        this.enabled = !this.enabled;
    }
}