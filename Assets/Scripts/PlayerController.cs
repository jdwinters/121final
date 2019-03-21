using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using InControl;

public class PlayerController : PlayerActionSet
{
    public PlayerAction LeftStickLeft;
    public PlayerAction LeftStickRight;
    public PlayerAction LeftStickUp;
    public PlayerAction LeftStickDown;

    public PlayerAction RightStickLeft;
    public PlayerAction RightStickRight;
    public PlayerAction RightStickUp;
    public PlayerAction RightStickDown;

    public PlayerTwoAxisAction Movement;
    public PlayerTwoAxisAction Looking;

    public PlayerController(){
      LeftStickLeft = CreatePlayerAction("LeftStick Left");
      LeftStickRight = CreatePlayerAction("LeftStick Right");
      LeftStickUp = CreatePlayerAction("LeftStick Up");
      LeftStickDown = CreatePlayerAction("LeftStick Down");

      RightStickLeft = CreatePlayerAction("RightStick Left");
      RightStickRight = CreatePlayerAction("RightStick Right");
      RightStickUp = CreatePlayerAction("RightStick Up");
      RightStickDown = CreatePlayerAction("RightStick Down");

      Movement = CreateTwoAxisPlayerAction(LeftStickLeft, LeftStickRight, LeftStickDown, LeftStickUp);
      Looking = CreateTwoAxisPlayerAction(RightStickLeft, RightStickRight, RightStickDown, RightStickUp);
    }
    public static PlayerController CreateDefaultBindings(){
      var playerController = new PlayerController();

      playerController.LeftStickLeft.AddDefaultBinding( InputControlType.LeftStickLeft);
      playerController.LeftStickRight.AddDefaultBinding( InputControlType.LeftStickRight);
      playerController.LeftStickDown.AddDefaultBinding( InputControlType.LeftStickDown);
      playerController.LeftStickUp.AddDefaultBinding( InputControlType.LeftStickUp);

      playerController.RightStickLeft.AddDefaultBinding( InputControlType.RightStickLeft);
      playerController.RightStickRight.AddDefaultBinding( InputControlType.RightStickRight);
      playerController.RightStickDown.AddDefaultBinding( InputControlType.RightStickDown);
      playerController.RightStickUp.AddDefaultBinding( InputControlType.RightStickUp);

      return playerController;
    }
}
