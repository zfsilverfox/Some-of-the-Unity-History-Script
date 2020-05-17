using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayButtonManager : MonoBehaviour
{
    public GameObject _StageBtn;

   public void QuitButton()
    {
       // this.transform.parent.gameObject.SetActive(false);
        GlobalPlayerStatement._INSTANCE.playerCtrl.turnSmoothing = 3f;
        GlobalPlayerStatement._INSTANCE.playerCtrl.speed = 3f;
        GlobalPlayerStatement._INSTANCE.playerCtrl.jumpPower = 7f;
        _StageBtn.SetActive(false);
    }

    public void LvlBtn(string LvlNum)
    {
        GlobalPlayerStatement._INSTANCE.playerCtrl.turnSmoothing = 3f;
        GlobalPlayerStatement._INSTANCE.playerCtrl.speed = 3f;
        GlobalPlayerStatement._INSTANCE.playerCtrl.jumpPower = 7f;
        SceneManager.LoadScene("Lvl"+LvlNum);
        SceneManager.sceneLoaded += OnSceneLoad;

    }

    void OnSceneLoad(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "LvlOne")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position = new Vector3(-22.7f, -24.965f, -10.4f);
            Camera.main.GetComponent<Transform>().position = new Vector3(-27.90996f, -16.3f, -20.61996f);
        }
    }


}
