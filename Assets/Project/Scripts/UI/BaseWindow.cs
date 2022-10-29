using UnityEngine;

public class BaseWindow : MonoBehaviour
{
    public bool IsOpen { get; protected set; }
    public Canvas Canvas { get; protected set; }
    public CanvasGroup CanvasGroup { get; protected set; }

    private void OnDestroy()
    {
        Destroy();
    }

    public virtual void Init()
    {
        Canvas = this.GetComponent<Canvas>();
        CanvasGroup = this.GetComponent<CanvasGroup>();
    }


    public virtual void Destroy()
    {

    }

    public virtual void Show()
    {
        IsOpen = true;
        this.gameObject.SetActive(true);
    }

    public virtual void Hide()
    {
        IsOpen = false;
        this.gameObject.SetActive(false);
    }

}
