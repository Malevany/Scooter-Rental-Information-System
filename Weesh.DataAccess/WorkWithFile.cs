using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Weesh.BusinessLogic;

namespace Weesh.DataAccess
{
    public class WorkWithFile
    {
        private string dbScooterFilePath;
        private string dbUsersFilePath;
        private string pricingPolicyFilePath;
        private string[] dbScooter;
        private string[] pricingPolicy;
        private string[] dbUsers;
        private Dictionary<Scooter, string> dbScooterDict;
        private Dictionary<string, double> pricingPolicyDict;
        private List<User> dbUsersDic;

        public string DbScooterFilePath { get { return dbScooterFilePath; } }

        public string DbUsersFilePath { get { return dbUsersFilePath; } }

        public string[] DbScooter { get { return dbScooter; } }

        public Dictionary<Scooter, string> DbScooterDic { get { return dbScooterDict; } }

        public Hire InitializationHire(string dbScooterFilePath, string dbUsersFilePath)
        {
            this.dbScooterFilePath = dbScooterFilePath;
            dbScooter = ReadFile(dbScooterFilePath);
            dbScooterDict = ConvertStringFileToDictScooter(dbScooter);
            this.dbUsersFilePath = dbUsersFilePath;
            dbUsers = ReadFile(dbUsersFilePath);
            dbUsersDic = ConvertStringFileToListOfUser(dbUsers);
            return new Hire(dbScooterDict, dbUsersDic);
        }

        public Payment InitializationPayment(string filePath)
        {
            pricingPolicyFilePath = filePath;
            pricingPolicy = ReadFile(pricingPolicyFilePath);
            pricingPolicyDict = ConvertStringFileToDictPricePolicy(pricingPolicy);
            return new Payment(pricingPolicyDict);
        }

        private string[] ReadFile(string filePath)
        {
            string[] textFile = File.ReadAllLines(filePath);
            return textFile;
        }

        private Dictionary<string, double> ConvertStringFileToDictPricePolicy(string[] textFile)
        {
            Dictionary<string, double> pricingPolicy = new Dictionary<string, double>();
            for(int i = 0; i < textFile.Length; i++)
            {
                string [] tempTextFile = textFile[i].Split('\t');
                 pricingPolicy.Add(tempTextFile[0], Convert.ToDouble(tempTextFile[1]));
            }
            return pricingPolicy;
        }
        
        private List<User> ConvertStringFileToListOfUser(string[] textFile)
        {
            List<User> users = new List<User>();

            for (int i = 1; i < textFile.Length; i++)
            {
                string[] tempString = textFile[i].Split(' ');
                User user = new User(tempString[0], tempString[1], Convert.ToDouble(tempString[2]));
                if (tempString.Contains("SubForWeek"))
                    user.GetCard(new Subscription(50, 0.05), "SubForWeek");
                else if (tempString.Contains("SubForMonth"))
                    user.GetCard(new Subscription(100, 0.07), "SubForMonth");

                users.Add(user);
            }
            return users;
        }

        private Dictionary<Scooter, string> ConvertStringFileToDictScooter(string[] textFile)
        {
            Dictionary<Scooter, string> scooters = new Dictionary<Scooter, string>();
            for (int i = 1; i < textFile.Length; i++)
            {
               
                string[] tempString = textFile[i].Split("\t");
                if (tempString[tempString.Length - 1] == "Free")
                    scooters.Add(new Scooter(tempString[0] ,new Equipment(tempString[1], tempString[2], tempString[3])), "Free");
                else
                    scooters.Add(new Scooter(tempString[0], new Equipment(tempString[1], tempString[2], tempString[3])), "Busy");
            }
            return scooters;
        }
        
        public void FormNewScooterBase(string scooterID)
        {
            for (int i = 1; i < dbScooter.Length; i++)
            {
                if (dbScooter[i].Contains(scooterID))
                {
                    dbScooter[i] = dbScooter[i].Substring(0, dbScooter[i].LastIndexOf("\t") + 1) + "Busy";
                    break;
                }
            }
        }
        
        public void WriteFile(Dictionary<Scooter, string> scooters, string Path)
        {
            using (StreamWriter SW = new StreamWriter(Path))
            {
                SW.WriteLine(dbScooter[0]);
                foreach (Scooter scooter in scooters.Keys)
                {
                    SW.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", 
                        scooter.ID, 
                        scooter.Equipment.BatteryCapacity, 
                        scooter.Equipment.AgeTypeOfScooter, 
                        scooter.Equipment.Seat, 
                        scooters[scooter]);
                }
            }
        }

        public void WriteFile(List<User> users, string Path)
        {
            using (StreamWriter SW = new StreamWriter(Path))
            {
                SW.WriteLine(dbUsers[0]);
                foreach(User user in users)
                {
                    SW.WriteLine(string.Join(' ', new string[] { user.Login, user.Password, Convert.ToString(user.BonusQuantity), user.TypeOfSub}));
                }
            }
        }

        public void WriteFile(string check, string Path)
        {
            using (StreamWriter SW = new StreamWriter(Path))
                SW.WriteLine(check);
        }

    }
}
