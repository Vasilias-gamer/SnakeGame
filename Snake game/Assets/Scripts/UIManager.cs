using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private GameData Data;
    [SerializeField]
    private TextMeshProUGUI Score;
    public Button PauseResume;
    public Sprite Pause;
    public Sprite Resume;

    // Start is called before the first frame update
    void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        Data.CurrentScene = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if (Data.CurrentScene.Equals("Game"))
        {
            Score.text = "0" + Data.Score.ToString();
        }
        if (Data.GameOver)
        {
            StartCoroutine(Menu());
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("Game");
    } 

    public void _PauseResume()
    {
        if (Time.timeScale > 0)
        {
            Time.timeScale = 0;
            Data.GamePause = true;
            PauseResume.image.sprite = Pause;
        }
        else
        {
            Data.GamePause = false;
            Time.timeScale = 1;
            PauseResume.image.sprite = Resume;
        }
    }

    IEnumerator Menu()
    {
        
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("Menu");
    }
    
}
