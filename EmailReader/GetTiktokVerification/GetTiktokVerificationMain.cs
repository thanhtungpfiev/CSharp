using OpenPop.Mime;
using OpenPop.Pop3;
using System;
using System.Text.RegularExpressions;

namespace GetTiktokVerification
{
    public class GetTiktokVerificationMain
    {
        public static string GetVerificationCode(string username, string password)
        {
            String verificationCode = "";

            try
            {
                Pop3Client pop3Client = new Pop3Client();//create an object for pop3client


                pop3Client.Connect("outlook.office365.com", 995, true);
                pop3Client.Authenticate(username, password, AuthenticationMethod.UsernameAndPassword);

                int count = pop3Client.GetMessageCount(); //total count of email in MessageBox  ie our inbox
                Console.WriteLine("Total Messages: " + count.ToString());



                for (int i = count; i >= 1; i--)//going to read mails from last till total number of mails received
                {
                    Message message = pop3Client.GetMessage(i);//assigning messagenumber to get detailed mail.//each mail having messagenumber
                    //Console.WriteLine(message.Headers.From.Address);
                    //Console.WriteLine(message.Headers.Subject);
                    //Console.WriteLine(message.Headers.DateSent);
                    //Console.WriteLine(message.Headers.Date);
                    //Console.WriteLine("--------------------");

                    String from = message.Headers.From.Address;//from address
                    if (from == "noreply@account.tiktok.com")
                    {
                        String subject = message.Headers.Subject;//subject of mail
                        if (subject.Contains("verification code") || subject.Contains("mã TikTok"))
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
            return verificationCode;
        }
    }
}
