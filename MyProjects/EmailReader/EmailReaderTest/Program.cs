using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Text.RegularExpressions;

namespace EmailReaderTest
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var username = "kateclain301@outlook.com";
            var password = "Duong@123";
            GetTiktokVerification.GetTiktokVerificationMain.GetVerificationCode(username, password);

        }
    }
}
