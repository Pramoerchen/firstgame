using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowDownFactor = 0.05f;
    public float slowDownLength = 2f;
    public PauseMenu myPauseMenu;
    bool itsPause;
    private void Update()
    {
        
        myPauseMenu = GameObject.FindGameObjectWithTag("Canvas").GetComponent<PauseMenu>();
        itsPause = myPauseMenu.GameIsPaused;

        if(!itsPause)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            Debug.Log("Hier wird die ZeitLupe gekillt");
        }

    }
    public void DoSlowMotion()
    {
        Time.timeScale = slowDownFactor;
        Time.fixedDeltaTime = Time.timeScale * 0.2f;
    }

}
