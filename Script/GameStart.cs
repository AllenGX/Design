using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;



public class GameStart : MonoBehaviour
{
	  
	private List<Person> enemyList;
	private List<Person> playerList;
	private List<Person> allList;
	private List<Person> speedList;
	private List<SkillUseStruct> orderList;

	public void Init(){
		Person p1=new Person(1,100,20,20,21,10,10,1,11,3,2,2,1,4,2);
		Person p2=new Person(2,100,20,21,21,10,10,1,11,3,2,2,1,4,2);
		Person p3=new Person(3,100,20,10,21,10,10,1,11,3,2,2,1,4,2);
		playerList = new List<Person>{ p1, p2, p3 };


		Person p4=new Person(4,100,20,11,21,10,10,1,11,3,2,2,1,4,2);
		Person p5=new Person(5,100,20,12,21,10,10,1,11,3,2,2,1,4,2);
		Person p6=new Person(6,100,20,22,21,10,10,1,11,3,2,2,1,4,2);
		enemyList = new List<Person>{ p4, p5, p6 };
		allList= new List<Person>{ p1,p2,p3,p4, p5, p6 };
		speedList = allList.Sort (compareSpeed);
	}



	public List<Person> PlayerAlivePersonNumber(int flag,List<Person> playerList,List<Person> enemyList,List<Person> allList){
		List<Person> p = new List<Person>{ };
		if (flag == 0) {
			foreach (var person in allList) {
				if(!person.IsDie()){
					p.Add (person);
				}
			}
		} else if (flag == 1) {
			foreach (var person in playerList) {
				if(!person.IsDie()){
					p.Add (person);
				}
			}
		} else {
			foreach (var person in enemyList) {
				if(!person.IsDie()){
					p.Add (person);
				}
			}
		}
		return p;
	}


	public bool IsEnemy(Person p, List<Person> enemyList){
		foreach (var person in enemyList) {
			if (person.GetID == p.GetID ()) {
				return true;
			}
		}
		return false;
	}

	public List<Person> GetRandomList(List<Person> p ,int cnt){
		List<Person> person = new List<Person>{ };
		if (p.Count <= cnt) {
			person = p; 
		} else{
			for (int i = 0; i < cnt; i++) {
				int ranNumber = Random.Range (0, p.Count - 1);
				person.Add (p [ranNumber]);
				p.Remove (p [ranNumber]);
			}
		}
		return person;
	}

	public List<SkillUseStruct> RandomOrder(List<Person> allList,List<Person> playerList,List<Person> enemyList){
		List<SkillUseStruct> orderList = new List<SkillUseStruct>{ };
		List<Person> enemyAliveList = PlayerAlivePersonNumber (-1, allList, playerList, enemyList);
		List<Person> playerAliveList = PlayerAlivePersonNumber (1, allList, playerList, enemyList);

		foreach (var person in allList) {
			List<Skill> skillList=person.GetSkillList ();
			int skillID=Random.Range(0,skillList.Count()-1);
			Skill skill = skillList [skillID];
			int targetNumber = skill.GetTargetNumber ();
			int skillType=skill.GetType();
			List<Person> targetList;

			if (IsEnemy (person, enemyList)) {
				if (skillType == 1) {
					targetList = playerAliveList;
				} else {
					targetList = enemyAliveList;
				}
			} else {
				if (skillType == 1) {
					targetList = enemyAliveList;
				} else {
					targetList = playerAliveList;
				}
			}
			targetList = GetRandomList (targetList,targetNumber);
			SkillUseStruct s = new SkillUseStruct (person, skill, targetList);
			orderList.Add (s);
		}
		return orderList;
	}

	public void GetInput(){
		
	}
		
	private int compareSpeed(Person a,Person b){
		if (a.GetSpeed () > b.GetSpeed ()) {
			return 1;
		} else if (a.GetSpeed () == b.GetSpeed ()) {
			return 0;
		} else {
			return -1;
		}
	}


}

