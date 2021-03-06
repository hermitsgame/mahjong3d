﻿using UnityEngine;
using System.Collections;


public class GameOverState : GameStateBase 
{
    public override void Enter() 
    {
        base.Enter();

        logicOwner.EndGame();

		EventManager.Instance.RpcSendEvent(UIEventType.End_Game, logicOwner.AgariUpdateInfoList);
    }

}
