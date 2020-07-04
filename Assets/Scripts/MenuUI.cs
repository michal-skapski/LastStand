using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUI : MonoBehaviour {
    //serializacja i prywatne
    //clean
    [SerializeField]
	private Canvas quitMenu;
    [SerializeField]
    private Button btnStart;
    [SerializeField]
    private Button btnExit;
    [SerializeField]
	private Canvas menuUI;
    private void Awake()
    {
        menuUI = GetComponent<Canvas>();

        quitMenu = quitMenu.GetComponent<Canvas>();

        btnStart = btnStart.GetComponent<Button>();
        btnExit = btnExit.GetComponent<Button>();
    }
    void Start ()
    {
		quitMenu.enabled = false; 

		Time.timeScale = 0;
		Cursor.visible = menuUI.enabled;
		Cursor.lockState = CursorLockMode.Confined;
	}
	public void ButtonQuit()
    {
		quitMenu.enabled = true; 
		btnStart.enabled = false; 
		btnExit.enabled = false; 
	}

	
	public void Buttonbtg()
    {
		quitMenu.enabled = false; 
		btnStart.enabled = true; 
		btnExit.enabled = true; 
	}

	
	public void ButtonStart()
    {
		SceneManager.LoadScene(1);

		
		menuUI.enabled = false; 

		Time.timeScale = 1;

		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked; 
	}

	
	public void ButtonQuit2()
    {
		Application.Quit();	
	}
}
