using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillUseStruct : MonoBehaviour
{
	public Person me;
	public Skill s;
	public List<Person>  targets;
	public SkillUseStruct(Person me,Skill s, List<Person> targets){
		this.me = me;
		this.s = s;
		this.targets = targets;
	}
}

