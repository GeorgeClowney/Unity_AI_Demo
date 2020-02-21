using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameDebugConsole;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;
using System;
public class ConsoleCommands : MonoBehaviour
{
    [ConsoleMethod("-quit", "Quit the game")]
    public static void quit()
    {
        Application.Quit();
    }
    [ConsoleMethod("-patrol", "Start Patrol")]
    public static void startPatrol()
    {
        GameObject go = GameObject.Find("Ian");
        BasicAI script = (BasicAI)go.GetComponent(typeof(BasicAI));
        script.speedReset = true;
        script.StateMachine = 1;
    }
    [ConsoleMethod("-chase", "Run at player")]
    public static void chasePlayer()
    {
        GameObject go = GameObject.Find("Ian");
        BasicAI script = (BasicAI)go.GetComponent(typeof(BasicAI));
        script.StateMachine = 2;
    }
    [ConsoleMethod("-speed", "Make AI run faster")]
    public static void speed()
    {
        GameObject go = GameObject.Find("Ian");
        BasicAI script = (BasicAI)go.GetComponent(typeof(BasicAI));
        script.speedUp = true;
    }
}
