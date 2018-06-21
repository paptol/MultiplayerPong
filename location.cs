
using System;
using System.Net.Sockets;
using System.IO;
using System.Collections.Generic;
using System.Linq;
/// <summary>
/// Name: location
/// A client to implement protocol for a client serverc assigment
/// Autor: 491564
/// History: Version 2: 3 March 2016
/// </summary>
/// 

namespace PongGame
{
    public class Whois
    {
        /// class setting up protocol, user name and location to null and
        /// also specifie port to 43 and address to  whois server
        /// 
        public static Dictionary<string, int> topSingle = new Dictionary<string, int>();
        public static Dictionary<string, int> topMulti = new Dictionary<string, int>();
        public static int port = 43;
        public static string address = "localhost";

        //public static int score = 0;
        public static void DisplayTopSingle()
        {
            int x = 1;
            var Display = topSingle.OrderByDescending(dic => dic.Value);
            Console.Clear();
            Console.WriteLine("TOP 5 SINGLE PLAYERS");
            foreach (var item in Display)
            {
                
                Console.WriteLine(x + "." + item.Key + " " + item.Value);
                ++x;
            }
        }
        public static void DisplayTopMulti()
        {
            int x = 1;
            var Dic = topMulti.OrderByDescending(dic => dic.Value);
            Console.Clear();
            Console.WriteLine("TOP 5 MULTI PLAYERS");
            foreach (var item in Dic)
            {
               
                Console.WriteLine(x + "." + item.Key + " " + item.Value);
                ++x;
            }
        }
        public static int GetRandom()
        {          
            Random rnd = new Random();
            int value = rnd.Next(0, 4);
            return value;
        }
        public static bool MakeATest(string inAddress)
        {
            TcpClient client = new TcpClient();

            //set time out for 1 second
            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            try
            {
                address = inAddress;
                client.Connect(address, 43);
                //Streamwriter for a program
                StreamWriter sw = new StreamWriter(client.GetStream());

                StreamReader sr = new StreamReader(client.GetStream());
                sw.WriteLine("Test");
                sw.Flush();
                string lines = sr.ReadLine();
               
                if (lines == "OK")
                {
                    return true;
                }
                return false;

            }
            catch (Exception e)
            { Console.WriteLine("Wrong"); return false; }

        }
        public static bool ExistIn(string name)
        {
            if(topSingle.ContainsKey(name))
            {
                return true;
            }
            return false;
            
        }
        public static bool ExistInMulti(string name)
        {
            if (topMulti.ContainsKey(name))
            {
                return true;
            }
            return false;

        }
        public static void GetTopSingle()
        {
            TcpClient client = new TcpClient();

            //set time out for 1 second
            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            try
            {
                client.Connect(address, 43);
                //Streamwriter for a program
                StreamWriter sw = new StreamWriter(client.GetStream());

                StreamReader sr = new StreamReader(client.GetStream());
                sw.WriteLine("GetSingle");
                sw.Flush();
                topSingle.Clear();
                string lines = sr.ReadLine();
                if (lines != "Empty")
                {
                    int counter = 0;
                    string[] splitAll = lines.Split(new char[] { '|' });
                    foreach (var item in splitAll)
                    {
                        if(splitAll[counter]=="")
                        {
                            break;
                        }
                        string[] split = item.Split(new char[] { ' ' });
                        if(ExistIn(split[0]))
                        {
                            topSingle.Add(split[0]+counter, int.Parse(split[1]));
                            
                        }
                        else
                        topSingle.Add(split[0], int.Parse(split[1]));
                        ++counter;
                    }
                    if (topSingle.Count < 5)
                    {
                        int diff = 5 - topSingle.Count;
                        for (int i = 0; i < diff; ++i)
                        {
                            topSingle.Add("test" + i, GetRandom());
                        }
                    }
                }
                else
                {
                    topSingle.Clear();
                    for (int i = 0; i < 5; ++i)
                    {
                        topSingle.Add("test" + i, GetRandom());
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static void GetTopMulti()
        {
            TcpClient client = new TcpClient();

            //set time out for 1 second
            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            try
            {
                client.Connect(address, 43);
                //Streamwriter for a program
                StreamWriter sw = new StreamWriter(client.GetStream());

                StreamReader sr = new StreamReader(client.GetStream());
                sw.WriteLine("GetMulti");
                sw.Flush();
                topMulti.Clear();
                string elines = sr.ReadLine();
                if (elines != "Empty")
                {
                    int counter = 0;
                    string[] splitAll = elines.Split(new char[] { '|' });
                    foreach (var item in splitAll)
                    {
                        if (splitAll[counter] == "")
                        {
                            break;
                        }
                        string[] split = item.Split(new char[] { ' ' });
                        if (ExistInMulti(split[0]))
                        {
                            topMulti.Add(split[0] + counter, int.Parse(split[1]));

                        }
                        else
                            topMulti.Add(split[0], int.Parse(split[1]));
                        ++counter;
                    }
                    if (topMulti.Count < 5)
                    {
                        int diff = 5 - topMulti.Count;
                        for (int i = 0; i < diff; ++i)
                        {
                            topMulti.Add("test" + i, GetRandom());
                        }
                    }
                }
                else
                {
                    topMulti.Clear();
                    for (int i = 0; i < 5; ++i)
                    {
                        topMulti.Add("test" + i, GetRandom());
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        public static bool CheckScore(int score, string status)
        {

            TcpClient client = new TcpClient();

            //set time out for 1 second
            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            try
            {
                client.Connect(address, 43);
                //Streamwriter for a program
                StreamWriter sw = new StreamWriter(client.GetStream());
                StreamReader sr = new StreamReader(client.GetStream());

                sw.WriteLine(score + " " + status);
                sw.Flush();
                string response = sr.ReadLine();
                if (response == "Yes")
                {
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public static void SendScore(int score, string userName, string status)
        {
            TcpClient client = new TcpClient();

            //set time out for 1 second
            client.ReceiveTimeout = 1000;
            client.SendTimeout = 1000;

            try
            {
                client.Connect(address, 43);
                //Streamwriter for a program
                StreamWriter sw = new StreamWriter(client.GetStream());
                StreamReader sr = new StreamReader(client.GetStream());
                string lines = null;
                sw.WriteLine(score + " " + userName.TrimEnd() + " " + status);
                sw.Flush();
                topSingle.Clear();
                topMulti.Clear();
                lines = sr.ReadToEnd();
                string[] splitAll = lines.Split(new char[] { '|' });
                for (int i = 0; i < splitAll.Length; i++)
                {
                    if(splitAll[i]=="")
                    {
                        break;
                    }
                    string[] split = splitAll[i].Split(new char[] { ' ' });
                    if (status == "Single")
                        topSingle.Add(split[0], int.Parse(split[1]));
                    else if (status == "Multi")
                        topMulti.Add(split[0], int.Parse(split[1]));
                }
                    
            }
            catch (Exception e)
            { Console.WriteLine(e); }

        }
       
    }
    
}