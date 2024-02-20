using System;
using OpenPop.Mime;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using OpenPop.Pop3;
using System.Text.RegularExpressions;

namespace EmailReader
{
    class Program
    {
        static void Main(string[] args)
        {
            String verificationCode = "";

            try
            {
                Pop3Client pop3Client = new Pop3Client();//create an object for pop3client

                var username = "vanducpham0022@outlook.com";
                var Password = "Duong@123";

                pop3Client.Connect("outlook.office365.com", 995, true);
                pop3Client.Authenticate(username, Password, AuthenticationMethod.UsernameAndPassword);

                int count = pop3Client.GetMessageCount(); //total count of email in MessageBox  ie our inbox



                for (int i = 1; i <= count; i++)//going to read mails from last till total number of mails received
                {
                    Message message = pop3Client.GetMessage(i);//assigning messagenumber to get detailed mail.//each mail having messagenumber

                    String from = message.Headers.From.Address;//from address
                    if (from == "noreply@account.tiktok.com")
                    {
                        String subject = message.Headers.Subject;//subject of mail
                        if (subject.Contains("verification code"))
                        {
                            // Use regular expression to match numbers
                            MatchCollection matches = Regex.Matches(subject, @"\d+");

                            // Print matched numbers
                            foreach (Match match in matches)
                            {
                                verificationCode = match.Value;
                            }

                            break;
                        }
                    }

                }
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Verification Code: " + verificationCode);
            }

        }
    }
}




