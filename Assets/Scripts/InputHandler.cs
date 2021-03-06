﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class InputHandler : MonoBehaviour
{

	//The different keys we need
	private Command w, a, s, d,space;
	//Stores all commands for replay and undo
	public static List<Command> oldCommands = new List<Command>();

	GameObject Player;
	PlayerController pc;
	MovementBehaviour mb;

	void Start()
	{
		//Bind keys with commands
		w = new MoveUp();
		a = new MoveLeft();
		s = new MoveDown();
		d = new MoveRight();
		space =  new Jump();
		Player = GameObject.FindWithTag("Player");
		pc = Player.GetComponent<PlayerController>();
		mb = Player.GetComponent<MovementBehaviour>();
	}



	void Update()
	{
			HandleInput();
	}


	//Check if we press a key, if so do what the key is binded to 
	public void HandleInput()
	{
		if (Input.GetKey(KeyCode.W) && pc.Grounded)
		{
			w.Execute(Player);
		}
		else if (Input.GetKey(KeyCode.A))
		{
			a.Execute(Player);
		}
		else if (Input.GetKey(KeyCode.S) && pc.Grounded)
		{
			s.Execute(Player);
		}
		else if (Input.GetKey(KeyCode.D))
		{
			d.Execute(Player);
		}
		else if (Input.GetKeyDown(KeyCode.Space))
		{
			space.Execute(Player);
		}
		else 
		{
			mb.beingInputed = false;
		}
	}
}

