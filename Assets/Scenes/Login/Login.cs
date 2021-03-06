﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Login : MonoBehaviour,
	FirebaseManager.OnFinishConnectionCallback {

	public InputField email, pwd;

	public void ConnectionFinished(FirebaseManager.CallbackResult result,
		string message) {
		switch(result) {
			case FirebaseManager.CallbackResult.Canceled:
			case FirebaseManager.CallbackResult.Faulted:
			case FirebaseManager.CallbackResult.Invalid:
				Debug.LogError(message);
				break;
			case FirebaseManager.CallbackResult.Success:
			default:
				Debug.Log(message);
				UnityMainThreadDispatcher
					.Instance ()
					.EnqueueNextScene ("1Game_Intro");
				break;
		}
	}

	public void OnLogin() {
		FirebaseManager.LoginPlayer(email.text, pwd.text, this);
	}

}
