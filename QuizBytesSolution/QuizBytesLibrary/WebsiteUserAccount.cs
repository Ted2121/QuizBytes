using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesObjects
{
    public class WebsiteUserAccount : IAccount
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TotalPoints { get; set; }
        public int PointsInWallet { get; set; }

        public WebsiteUserAccount(int id, string userName, string password, int totalPoints, int pointsInWallet)
        {
            Id = id;
            UserName = userName;
            Password = password;
            TotalPoints = totalPoints;
            PointsInWallet = pointsInWallet;
        }

        public WebsiteUserAccount(string userName, string password, int totalPoints, int pointsInWallet)
        {
            UserName = userName;
            Password = password;
            TotalPoints = totalPoints;
            PointsInWallet = pointsInWallet;
        }

        public WebsiteUserAccount(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public WebsiteUserAccount(int id, string userName, string password)
        {
            UserName = userName;
            Password = password;
            Id = id;
        }
    }
}
