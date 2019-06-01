using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightMonster
{

    public List<Person> FightMonsterFactory(int fightNumber)
    {
        List<Person> monsterList = new List<Person>();
        //野猪(2-4)
        if (fightNumber == 1)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber*100+i,4));
            }

        }//黑野猪(2-4)
        else if(fightNumber == 2)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 5));
            }
        }//劲敌
        else if (fightNumber == 3)
        {
            monsterList.Add(MonsterFactory(fightNumber * 100 + 0, 1));
            monsterList.Add(MonsterFactory(fightNumber * 100 + 1, 2));
            monsterList.Add(MonsterFactory(fightNumber * 100 + 2, 3));
        }//幽灵(2-4)
        else if (fightNumber == 4)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i,6));
            }
        }//小恶魔(2-4)
        else if (fightNumber == 5)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 7));
            }
        }//士兵甲、乙(2-4)
        else if (fightNumber == 7)
        {
            for(int j = 0; j < 2; j++)
            {
                int monsterNumber = Random.Range(1, 3);
                for (int i = 0; i < monsterNumber; i++)
                {
                    monsterList.Add(MonsterFactory(fightNumber * 100 + i+j, 8+j));
                }
            }
        }//士兵4、将军
        else if (fightNumber == 8)
        {
            monsterList.Add(MonsterFactory(fightNumber * 100, 10));

            for (int i = 0; i < 4; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i+1 , 9));
            }
        }//魔狼（2-4）
        else if (fightNumber == 9)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i , 11));
            }
        }//魔狼（2-4）龙1
        else if (fightNumber == 10)
        {
            int monsterNumber = Random.Range(2, 5);
            for (int i = 0; i < monsterNumber; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 11));
            }
            monsterList.Add(MonsterFactory(fightNumber * 105, 12));
        }//精灵45N
        else if (fightNumber == 11)
        {
            for (int i = 0; i < 4; i++)
            {
                monsterList.Add(MonsterFactory(fightNumber * 100 + i, 13));
            }
        }
        return monsterList;
    }

    public Person MonsterFactory(int ID,int type)
    {
        Person person = null;

        if (type == 1)
        {
            person = new Person(ID, "男主一", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "020-Hunter01", 2, 0, 0);
        }
        else if (type == 2)
        {
            person = new Person(ID, "女主一", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "040-Mage08", 2, 0, 0);
        }
        else if (type == 3)
        {
            person = new Person(ID, "女主二", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "007-Fighter07", 2, 0, 0);
        }
        else if (type == 4)
        {
            person = new Person(ID, "野猪", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05", 1, 8, 10);
        }
        else if (type == 5)
        {
            person = new Person(ID, "黑野猪", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05-1", 1, 25, 30);
        }
        else if (type == 6)
        {
            person = new Person(ID, "幽灵", 400, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "051-Undead01", 2, 50, 50);
        }
        else if (type == 7)
        {
            person = new Person(ID, "小恶魔", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "075-Devil01", 2, 90, 90);
        }
        else if (type == 8)
        {
            person = new Person(ID, "士兵甲", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "049-Soldier01", 2, 150, 150);
        }
        else if (type == 9)
        {
            person = new Person(ID, "士兵乙", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "050-Soldier02", 2, 150, 150);
        }
        else if (type == 10)
        {
            person = new Person(ID, "将军", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "003-Fighter03", 2, 150, 150);
        }
        else if (type == 11)
        {
            person = new Person(ID, "魔狼", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "063-Beast01", 1, 225, 225);
        }
        else if (type == 12)
        {
            person = new Person(ID, "龙", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "099-Monster13", 1, 300, 300);
        }
        else if (type == 13)
        {
            person = new Person(ID, "精灵", 30, 200, 20, 30, 11, 18, 8, 1, 0, 3, 2, 2, 3, 4, 1, 1, "080-Angel02", 1, 1000, 300);
        }
        

        //实际设定
        if (type == 1)
        {
            Person p = CPlayerData.pd.p3;
            person = new Person(ID, "男主一", p.BloodMax, p.BlueMax, p.PhysicsAttack, p.SpecialAttack, p.Speed, p.PhysicsDefense, p.SpecialDefense, 1, 0, 3, 2, 2, 3, 4, 1, 1, "020-Hunter01", 2, 0, 0);

            person.AddSkill(person.skillFactory.CreateSkill("瞬劈"));
            person.AddSkill(person.skillFactory.CreateSkill("生死不觉"));
            person.AddSkill(person.skillFactory.CreateSkill("临危不惧"));
        }
        else if(type == 2)
        {
            Person p = CPlayerData.pd.p1;
            person = new Person(ID, "女主一", p.BloodMax, p.BlueMax, p.PhysicsAttack, p.SpecialAttack, p.Speed, p.PhysicsDefense, p.SpecialDefense, 1, 0, 3, 2, 2, 3, 4, 1, 1, "040-Mage08", 2, 0, 0);
            person.AddSkill(person.skillFactory.CreateSkill("无限剑制"));
            person.AddSkill(person.skillFactory.CreateSkill("六脉神剑"));
            person.AddSkill(person.skillFactory.CreateSkill("八荒六合"));
        }
        else if(type == 3)
        {
            Person p = CPlayerData.pd.p2;
            person = new Person(ID, "女主二", p.BloodMax, p.BlueMax, p.PhysicsAttack, p.SpecialAttack, p.Speed, p.PhysicsDefense, p.SpecialDefense, 1, 0, 3, 2, 2, 3, 4, 1, 1, "007-Fighter07", 2, 0, 0);
            person.AddSkill(person.skillFactory.CreateSkill("大火球"));
            person.AddSkill(person.skillFactory.CreateSkill("岩浆爆破"));
            person.AddSkill(person.skillFactory.CreateSkill("烈焰风暴"));
        }
        
        else if (type == 4)
        {
            person = new Person(ID, "野猪", 108, 500, 41, 41, 50, 15, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, "155-Animal05", 1, 8, 10);
        }
        else if (type == 5)
        {
            person = new Person(ID, "黑野猪", 348, 680, 95, 95, 68, 24, 14, 1, 0, 3, 2, 2, 3, 4, 1, 1, "155-Animal05-1", 1, 25, 30);
        }
        else if (type == 6)
        {
            person = new Person(ID, "幽灵", 588, 860, 149, 149, 86, 33, 23, 1, 0, 3, 2, 2, 3, 4, 1, 1, "051-Undead01", 2, 50, 50);
        }
        else if (type == 7)
        {
            person = new Person(ID, "小恶魔", 828, 1040, 203, 203, 104, 42, 32, 1, 0, 3, 2, 2, 3, 4, 1, 1, "075-Devil01", 2, 90, 90);
        }
        else if (type == 8)
        {
            person = new Person(ID, "士兵甲", 1068, 1220, 257, 257, 122, 51, 41, 1, 0, 3, 2, 2, 3, 4, 1, 1, "049-Soldier01", 2, 150, 150);
        }
        else if (type == 9)
        {
            person = new Person(ID, "士兵乙", 1068, 1200, 253, 253, 123, 51, 41, 1, 0, 3, 2, 2, 3, 4, 1, 1, "050-Soldier02", 2, 150, 150);
        }
        else if (type == 10)
        {
            person = new Person(ID, "将军", 1808, 1200, 311, 311, 140, 60, 50, 1, 0, 3, 2, 2, 3, 4, 1, 1, "003-Fighter03", 2, 150, 150);
        }
        else if (type == 11)
        {
            person = new Person(ID, "魔狼", 1548, 1200, 365, 365, 158, 69, 59, 1, 0, 3, 2, 2, 3, 4, 1, 1, "063-Beast01", 1, 225, 225);
        }
        else if (type == 12)
        {
            person = new Person(ID, "龙", 3088, 1200, 419, 419, 176, 78, 68, 1, 0, 3, 2, 2, 3, 4, 1, 1, "099-Monster13", 1, 300, 300);
        }
        else if (type == 13)
        {
            person = new Person(ID, "精灵", 3028, 1200, 473, 473, 194, 87, 77, 1, 0, 3, 2, 2, 3, 4, 1, 1, "080-Angel02", 1, 1000, 300);
        }
        
        return person;
    }

   
}