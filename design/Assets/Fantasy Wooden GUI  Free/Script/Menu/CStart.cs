using UnityEngine;
using System.Collections;

public class CStart : MonoBehaviour
{

    // Use this for initialization
    public GameObject target;
    public GameObject Load;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Press(int type)
    {
        if(type == 0)
        {
            CPlayerData.pd.Init();
            if(target != null)
                CPlayerData.pd.player_position = target.transform.position;
            GameObject[] m_Desk = GameObject.FindGameObjectsWithTag("start_ui");
            foreach (Transform child in gameObject.transform)
            {
                child.gameObject.SetActive(false);
            }
            Application.LoadLevelAsync("工会内");
            CPlayerData.pd.mapName = "工会内";
            CPlayerData.pd.mapNameText.text = CPlayerData.pd.mapName;
            BgMusic.dd.StopBgMusic();
            BgMusic.dd.LoadMusicSource();
            BgMusic.dd.PlayBgMusic();
        }
    }

    public void ShowLoad()
    {
        Load.SetActive(true);
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
        CPlayerData.pd.sm.InfoLoad();
        for (int i = 0; i < 3; i++)
        {
            if (CPlayerData.pd.sm.Saves[i] != null && CPlayerData.pd.m_LoadText[i] != null)
            {
                CPlayerData.pd.m_LoadText[i].text = CPlayerData.pd.sm.Saves[i].Time.ToString();
            }
            else if (CPlayerData.pd.m_LoadText[i] != null)
            {
                CPlayerData.pd.m_LoadText[i].text = "";
            }
        }
    }

    public void BackToStart()
    {
        Debug.Log("BackToStart");
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        GameObject[] m_Desk = GameObject.FindGameObjectsWithTag("start"); 

    
        for(int i = 0; i < m_Desk.Length; i++)  
        {
            foreach (Transform child in m_Desk[i].transform)
            {
                child.gameObject.SetActive(true);
            }
        }

        m_Desk = GameObject.FindGameObjectsWithTag("back");


        for (int i = 0; i < m_Desk.Length; i++)
        {
            Destroy(m_Desk[i]);
        }

        Application.LoadLevelAsync("start");
        CMenuObject.mo.m_MenuButton.SetActive(true);
        CMenuObject.mo.m_Menu.SetActive(false);
        CMenuObject.mo.m_MenuButton.SetActive(true);
        CMenuObject.mo.m_BattleUI.SetActive(false);
        CPlayerData.pd.mapNameText.text = "";
    }

    public void Quit()
    {
        Application.Quit();
    }
}
