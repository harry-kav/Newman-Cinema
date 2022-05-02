using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Newman_Cinema
{
    public class Members
    {
        public string FName { get; private set; }
        string SName;
        public string Email { get; private set; }
        public string Password { get; private set; }
        public static int i=-1;

        public Members(string FName_, string SName_, string Email_, string Password_)
        {
            FName = FName_;
            SName = SName_;
            Email = Email_;
            Password = Password_;
            i++;
        }
    }
}
