using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ExecuteProcessTerminal("node leap.js");
    }


    private string ExecuteProcessTerminal(string argument)
    {
        try
        {
            UnityEngine.Debug.Log("============== Start Executing [" + argument + "] ===============");
            ProcessStartInfo startInfo = new ProcessStartInfo()
            {
                FileName = "/bin/zsh",
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                CreateNoWindow = true,
                Arguments = " -c \"" + argument + " \""
            };
            Process myProcess = new Process
            {
                StartInfo = startInfo
            };
            myProcess.Start();
            string output = myProcess.StandardOutput.ReadToEnd();
            UnityEngine.Debug.Log(GetStringResult(output));
            myProcess.WaitForExit();
            UnityEngine.Debug.Log("============== End ===============");

            return output;
        }
        catch (Exception e)
        {
            print(e);
            return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
