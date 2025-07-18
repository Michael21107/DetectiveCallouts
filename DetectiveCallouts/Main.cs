using LSPD_First_Response.Mod.API;
using Rage;
using System;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime;
using System.Threading;

[assembly: Rage.Attributes.Plugin("DetectiveCallouts", Description = "Callouts which take you on an mystery. Your job is to solve the case. What's next detective?", Author = "Seerside Studios")]

namespace DetectiveCallouts
{
    public class Main : Plugin
    {
        public static Version LatestVersion = new Version();
        public static Version UserVersion = new Version("0.0.0"); 
        public static bool UpToDate;
        public static bool CalloutInterface;
        public static bool Beta = false;

        public override void Initialize()
        {
            try
            {
                Functions.OnOnDutyStateChanged += OnOnDutyStateChangedHandler;
                Game.LogTrivial("DetectiveCallouts: Version " + UserVersion + " has been loaded.");
            }
            catch (Exception ex)
            {
                Game.LogTrivial("DetectiveCallouts: An error occurred while initializing the plugin: " + ex.Message);
            }
        }

        public override void Finally()
        {
            Game.LogTrivial("DetectiveCallouts: Plugin has been cleaned up.");
        }

        private static void OnOnDutyStateChangedHandler(bool OnDuty)
        {
            if (OnDuty)
            {
                int num = (int)Game.DisplayNotification("3dtextures", "mpgroundlogo_cops", "Detective Callouts", "~y~v." + UserVersion + " ~b~by Seerside Studios", " ~g~Loaded Successfully. ~b~Time to solve a case.");
                GameFiber.StartNew(delegate
                {
                    Game.LogTrivial("DetectiveCallouts: Plugin initialized, checking for updates.");
                    try
                    {
                        Thread FetchVersionThread = new Thread(() =>
                        {
                            using (WebClient client = new WebClient())
                            {
                                try
                                {
                                    string s = client.DownloadString("https://raw.githubusercontent.com/SeersideStudios/DetectiveCallouts/refs/heads/master/version.txt");
                                    LatestVersion = new Version(s);
                                }
                                catch (Exception) { Game.LogTrivial("DetectiveCallouts: GitHub version link down. Version UNVERIFIED."); }
                            }
                        });
                        FetchVersionThread.Start();
                        while (FetchVersionThread.ThreadState != ThreadState.Stopped)
                        {
                            GameFiber.Yield();
                        }

                        if (UserVersion.CompareTo(LatestVersion) < 0)
                        {
                            Game.LogTrivial("DetectiveCallouts: Update available. Installed Version " + UserVersion + ", New Version " + LatestVersion);
                            Game.DisplayNotification("~r~IMPORTANT:~w~ A new version of ~b~DetectiveCallouts~w~ is available.\n\n~y~Installed:~w~ v" + UserVersion + "\n~y~Latest:~w~ v" + LatestVersion + "\n\n~r~Please update to ensure optimal performance and prevent issues.");
                            UpToDate = false;
                        }
                        else if (UserVersion.CompareTo(LatestVersion) > 0)
                        {
                            Game.LogTrivial("DetectiveCallouts: DETECTED BETA RELEASE. DO NOT REDISTRIBUTE. PLEASE REPORT ALL ISSUES.");
                            Game.DisplayNotification("DetectiveCallouts: ~r~DETECTED BETA RELEASE. ~w~DO NOT REDISTRIBUTE. PLEASE REPORT ALL ISSUES.");
                            UpToDate = true;
                            Beta = true;
                        }
                        else
                        {
                            Game.LogTrivial("DetectiveCallouts: Latest version is downloaded!");
                            Game.DisplayNotification("You are on the ~g~Latest Version~w~ of ~b~DetectiveCallouts.");
                            UpToDate = true;
                        }
                    }
                    catch (Exception)
                    {
                        Game.LogTrivial("DetectiveCallouts: Error while checking version.");
                    }
                });

                RegisterCallouts();
            }
        }

        private static void RegisterCallouts()
        {
            Game.LogTrivial("====================DETECTIVECALLOUTS CALLOUTS REGISTRATION====================");

            string gtaFolder = System.IO.Directory.GetCurrentDirectory();
            string calloutInterfacePath = System.IO.Path.Combine(gtaFolder, "CalloutInterfaceAPI.dll");
            string naudioPath = System.IO.Path.Combine(gtaFolder, "NAudio.dll");

            if (System.IO.File.Exists(calloutInterfacePath))
                Game.LogTrivial("DetectiveCallouts: CalloutInterfaceAPI.dll found.");
            else
                Game.LogTrivial("DetectiveCallouts: CalloutInterfaceAPI.dll NOT found.");

            if (System.IO.File.Exists(naudioPath))
                Game.LogTrivial("DetectiveCallouts: NAudio.dll found.");
            else
                Game.LogTrivial("DetectiveCallouts: NAudio.dll NOT found.");

            if (Functions.GetAllUserPlugins().ToList().Any(p => p?.FullName.Contains("CalloutInterface") == true))
            {
                Game.LogTrivial("User has Callout Interface installed.");
                CalloutInterface = true;
            }
            else
            {
                Game.LogTrivial("User does NOT have CalloutInterface installed.");
                CalloutInterface = false;
            }

            if (Settings.ini.Exists()) Game.LogTrivial("DetectiveCallouts.ini is installed.");
            else Game.LogTrivial("DetectiveCallouts.ini is NOT installed");

            if (Settings.UseBluelineAudio)
                Game.LogTrivial("DetectiveCallouts: Using BluelineAudio.");
            else
                Game.LogTrivial("DetectiveCallouts: Using LSPDFR/Default audio.");

            // REGISTER YOUR CALLOUTS HERE
            Game.LogTrivial("Started Registering Callouts.");
            if (Settings.DesertMurder || !Settings.ini.Exists()) Functions.RegisterCallout(typeof(Callouts.DesertMurder));
            Game.LogTrivial("====================DETECTIVECALLOUTS CALLOUTS REGISTRATION====================");
        }
    }
}
