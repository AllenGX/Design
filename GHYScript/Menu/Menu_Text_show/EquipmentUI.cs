using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;


public class EquipmentUI : MonoBehaviour
{
    public Text[] EquipText = new Text[6];
    public Image[] EquipImg = new Image[6];
    // Use this for initialization

    public Text[] AttrText = new Text[8];


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int type = 0;
    public void Refresh()
    {
        Person nowPlayer = null;
        if (type == 0)
        {
            nowPlayer = CPlayerData.pd.p1;
        }
        else if (type == 1)
        {
            nowPlayer = CPlayerData.pd.p2;
        }
        else
        {
            nowPlayer = CPlayerData.pd.p3;
        }

        AttrText[0].text = nowPlayer.PersonID.ToString();
        AttrText[1].text = nowPlayer.BloodMax.ToString();
        AttrText[2].text = nowPlayer.BlueMax.ToString();
        AttrText[3].text = nowPlayer.PhysicsAttack.ToString();
        AttrText[4].text = nowPlayer.PhysicsDefense.ToString();
        AttrText[5].text = nowPlayer.SpecialAttack.ToString();
        AttrText[6].text = nowPlayer.SpecialDefense.ToString();
        AttrText[7].text = nowPlayer.Speed.ToString();

        if (nowPlayer.GetInventory()["Heads"] != null)
        {
            EquipText[0].text = nowPlayer.GetInventory()["Heads"].EquipmentName;
            EquipImg[0].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Heads"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[0].text = "无";
            EquipImg[0].sprite = Resources.Load<Sprite>("myimport/Icon/011-Head02");
        }

        if (nowPlayer.GetInventory()["Top"] != null)
        {
            EquipText[1].text = nowPlayer.GetInventory()["Top"].EquipmentName;
            EquipImg[1].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Top"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[1].text = "无";
            EquipImg[1].sprite = Resources.Load<Sprite>("myimport/Icon/015-Body03");
        }

        if (nowPlayer.GetInventory()["Bottom"] != null)
        {
            EquipText[2].text = nowPlayer.GetInventory()["Bottom"].EquipmentName;
            EquipImg[2].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Bottom"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[2].text = "无";
            EquipImg[2].sprite = Resources.Load<Sprite>("myimport/Icon/020-Accessory05");
        }

        if (nowPlayer.GetInventory()["Weapon"] != null)
        {
            EquipText[3].text = nowPlayer.GetInventory()["Weapon"].EquipmentName;
            EquipImg[3].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Weapon"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[3].text = "无";
            EquipImg[3].sprite = Resources.Load<Sprite>("myimport/Icon/005-Weapon05");
        }

        if (nowPlayer.GetInventory()["Armor"] != null)
        {
            EquipText[4].text = nowPlayer.GetInventory()["Armor"].EquipmentName;
            EquipImg[4].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Armor"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[4].text = "无";
            EquipImg[4].sprite = Resources.Load<Sprite>("myimport/Icon/009-Shield01");
        }

        if (nowPlayer.GetInventory()["Accessorie"] != null)
        {
            EquipText[5].text = nowPlayer.GetInventory()["Accessorie"].EquipmentName;
            EquipImg[5].sprite = Resources.Load<Sprite>(nowPlayer.GetInventory()["Accessorie"].ImagePath.Split('.')[0]);
        }
        else
        {
            EquipText[5].text = "无";
            EquipImg[5].sprite = Resources.Load<Sprite>("myimport/Icon/017-Accessory02");
        }
        
    }

    public void SetType(int i)
    {
        type = i;
        Refresh();
    }

    public void Discharge(string str)
    {
        Person nowPlayer = null;
        if (type == 0)
        {
            nowPlayer = CPlayerData.pd.p1;
        }
        else if (type == 1)
        {
            nowPlayer = CPlayerData.pd.p2;
        }
        else
        {
            nowPlayer = CPlayerData.pd.p3;
        }

        if(nowPlayer.Inventory[str] != null)
        {
            Equipment eq = nowPlayer.RemoveInventory(str);
            CPlayerData.pd.bag.SetGoods(eq);

        }
            

        Refresh();
    }
}
